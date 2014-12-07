using UnityEngine;
using System.Collections;

public class TigerSceneItem : SceneItem {

	public override void Use (InventoryItem item)
	{
		if (state == 0)
		{
			// The tiger is hungry
			if (item is SteakInventoryItem)
			{
				++state;
				// TODO
				// animation
			}
		}
		else if (state==1)
		{
			// The tiger is eating the steak
			if (item is BarrelInventoryItem)
			{
				++state;
				// TODO
				// Animation
				// Change sprite
			}
		}
		else
		{
			if(item == null)
			{
				Object prefab = Resources.Load("Prefabs/Tiger");
				GameObject newItem = Instantiate(prefab) as GameObject;
				GameManager.GetInstance().GetComponent<Inventory>().AddItem(newItem.GetComponent<InventoryItem>());
			}
		}

		base.Use (item);
	}
}
