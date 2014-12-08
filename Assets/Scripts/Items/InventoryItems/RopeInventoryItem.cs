using UnityEngine;
using System.Collections;

public class RopeInventoryItem : InventoryItem
{
    public GameObject m_octoropePrefab;
	public override void Use (InventoryItem item)
	{
		if(item is OctopusInventoryItem)
		{
			GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(item);
			GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(this);
            GameManager.GetInstance().GetComponent<Inventory>().AddItem(m_octoropePrefab);
            
            GameManager.GetInstance().GetComponent<Analytics>().TrackEvent("GotOctorope");

            m_octoropePrefab.audio.Play();
			return;
		}

		base.Use (item);
	}
}
