using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour
{
	private InventoryItem m_item;

	public InventoryItem Item
	{
		get { return m_item; }
		set
		{
			m_item = value;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
