using UnityEngine;
using System.Collections;

public class TigerSceneItem : PickableSceneItem {

	public override void Use (InventoryItem item)
	{
		if (state == 0)
		{
			// The tiger is hungry
			if (item is SteakInventoryItem)
			{
				++state;
                ChangeSprite();
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
                ChangeSprite();
				// TODO
				// Animation
				// Change sprite
			}
		}
		else
		{
			if(item == null)
			{
				GameManager.GetInstance().GetComponent<Inventory>().AddItem(m_inventoryPrefab);
			}
		}

		base.Use (item);
	}
}
