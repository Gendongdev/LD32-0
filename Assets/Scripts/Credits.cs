using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Credits : MonoBehaviour
{
    [System.Serializable]
    public class Member
    {
        [SerializeField]
        public string m_name;

        [SerializeField]
        public string m_position;
    }

    public RectTransform m_panel;
    public CreditsLine m_linePrefab;
	public List<Member> m_staff;

    protected List<CreditsLine> m_lines;

	public void Roll()
	{
        string position;
		string name;
        CreditsLine line;

        if (m_lines != null)
        {
            foreach (CreditsLine currentLine in m_lines)
            {
                Destroy(currentLine.gameObject);
            }
            m_lines.Clear();
        }
        else
        {
            m_lines = new List<CreditsLine>(m_staff.Count);
        }

		foreach (Member member in m_staff)
        {
            line = (Instantiate(m_linePrefab.gameObject) as GameObject).GetComponent<CreditsLine>();

            line.Show(member.m_name, member.m_position);

            line.transform.SetParent(m_panel.transform);
            line.transform.localScale = Vector3.one;

            m_lines.Add(line);
		}

        this.gameObject.GetComponent<Animator>().SetBool("isRolling", true);
	}

    public void EndRoll()
    {
        this.gameObject.GetComponent<Animator>().SetBool("isRolling", false);
    }
}
