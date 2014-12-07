using UnityEngine;
using System.Collections;

public class CreditsLine : MonoBehaviour 
{
    public UnityEngine.UI.Text  m_position;
    public UnityEngine.UI.Text  m_name;

    public void Show(string name, string position)
    {
        m_name.text = name;
        m_position.text = position;
    }
}