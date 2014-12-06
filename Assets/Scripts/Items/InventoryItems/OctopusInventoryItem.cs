using UnityEngine;
using System.Collections;

public class OctopusInventoryItem : InventoryItem
{
	public override void Use (InventoryItem item)
	{
		if (item is RopeInventoryItem)
		{
			item.Use(this);
			return;
		}

		base.Use (item);
	}
}
