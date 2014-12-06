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
			Object prefab = Resources.Load("Prefabs/Octorope");
			GameObject octorope = Instantiate(prefab) as GameObject;
			GameManager.GetInstance().GetComponent<Inventory>().AddItem(octorope.GetComponent<InventoryItem>());
			return;
		}

		base.Use (item);
	}
}
