using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Vector3 m_positionToGo;
	public float m_speed;
    private Animator _myAnim;
    private SceneItem _useItem = null;
    private Cursor _cursorManager;
    private bool _useObject = false;

	// Use this for initialization
	void Start () {
		m_positionToGo = Vector3.zero;
        _myAnim = GetComponent<Animator>();
        _cursorManager = GameManager.GetInstance().GetComponent<Cursor>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Mathf.Abs(m_positionToGo.x - transform.position.x) > 0.5f)
        {
            Vector3 dir = Vector3.zero;
            dir.x = m_positionToGo.x - transform.position.x;
            dir.Normalize();
            Debug.Log("Direction: " + dir);
            transform.position += dir * m_speed * Time.deltaTime;
        }
        else
        {
            _myAnim.SetBool("StartWalk", false);
            _myAnim.SetBool("EndWalk", true);

            if (_useItem != null)
            {
                if (_useObject)
                {
                    _useItem.Use(_cursorManager.Item);
                    _cursorManager.Item = null;
                }
                else
                    Debug.Log("Look");
                        
            }

            enabled = false;
        }

	}

	public void Move(SceneItem item, bool use)
	{
        Vector3 scale = transform.localScale;
        _useObject = use;
        _useItem = item;
		m_positionToGo = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _myAnim.SetBool("StartWalk",true);
        _myAnim.SetBool("EndWalk", false);

        if (m_positionToGo.x < transform.position.x)
            scale.x = 1;
        else
            scale.x = -1;

        transform.localScale = scale;

        enabled = true;
	}

}
