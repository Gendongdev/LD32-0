using UnityEngine;
using System.Collections;

public class RopeInventoryItem : InventoryItem
{
	public OctoropeInventoryItem m_octoropeItem;

	public override void Use (InventoryItem item)
	{
		if(item is OctopusInventoryItem)
		{
			GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(item);
			GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(this);
			GameManager.GetInstance().GetComponent<Inventory>().AddItem(m_octoropeItem);
			return;
		}

		base.Use (item);
	}
}
