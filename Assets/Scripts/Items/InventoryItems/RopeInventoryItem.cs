using UnityEngine;
using System.Collections;

public class RopeInventoryItem : InventoryItem
{
	public override void Use (InventoryItem item)
	{
		if(item is OctopusInventoryItem)
		{
			GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(item);
			GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(this);
			GameObject prefab = Resources.Load("Prefabs/Octorope");
			GameObject octorope = Instantiate(prefab);
			GameManager.GetInstance().GetComponent<Inventory>().AddItem(octorope);
			return;
		}

		base.Use (item);
	}
}
