using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Vector3 m_positionToGo;
	public float m_speed;

	// Use this for initialization
	void Start () {
		m_positionToGo = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

		CheckInput ();

		Debug.Log (Vector3.Distance (m_positionToGo, transform.position));
		if (Mathf.Abs(m_positionToGo.x - transform.position.x) > 0.5f) 
		{
			Vector3 dir = Vector3.zero;
			dir.x = m_positionToGo.x - transform.position.x;
			dir.Normalize();
			Debug.Log("Direction: "+dir);
			transform.position += dir * m_speed *Time.deltaTime;
		}

	}

	void MoveTo(Vector3 pos)
	{
		m_positionToGo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	void CheckInput()
	{
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				//if (hit.collider.GetComponent<
			}
		}
		if(Input.GetMouseButtonDown(1))
			Debug.Log("Pressed right click.");
		if(Input.GetMouseButtonDown(2))
			Debug.Log("Pressed middle click.");
	}
}
