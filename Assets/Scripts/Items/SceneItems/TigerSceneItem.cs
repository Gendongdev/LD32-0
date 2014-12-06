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
			if (item is BarrelIventoryItem)
			{
				++state;
				// TODO
				// Animation
				// Change sprite
			}
		}
		else
		{
			// The tiger is in the cage
		}

		base.Use (item);
	}
}
