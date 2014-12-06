using UnityEngine;
using System.Collections;

public class RopeInventoryItem : InventoryItem
{
	public OctoropeInventoryItem m_octoropeItem;

	public override void Use (InventoryItem item)
	{
		if(item is OctopusInventoryItem)
		{
			m_inventory.RemoveItem(item);
			m_inventory.RemoveItem(this);
			m_inventory.AddItem(m_octoropeItem);
			return;
		}

		base.Use (item);
	}
}
