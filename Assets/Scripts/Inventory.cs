using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Inventory : MonoBehaviour
{
	public InventoryItem[] m_items;

	public void Start()
	{
		/*
		// FIXME Test
		m_items = new InventoryItem[2];
		GameObject g1 = new GameObject ();
		m_items[0] = g1.AddComponent<InventoryItem> ();
		GameObject g2 = new GameObject ();
		m_items[1] = g2.AddComponent<InventoryItem> ();
		// FIXME ¬Test
		*/
	}

	public void AddItem(GameObject prefab)
	{
        GameObject item = Instantiate(prefab) as GameObject;
        InventoryItem ii = item.GetComponent<InventoryItem>();
		if (!m_items.Contains(ii))
		{
			List<InventoryItem> items = m_items.ToList ();
			items.Add(ii);
			m_items = items.ToArray();
		}
	}

	public void RemoveItem(InventoryItem item)
	{
		m_items = m_items.Where (i => i != item).ToArray ();
	}
}
