using UnityEngine;
using System.Collections;

public class BoxSceneItem : SceneItem {

	public override void Use (InventoryItem item)
	{
		if (m_state == 0)
		{
			if (item is OctoropeInventoryItem)
			{
				++m_state;
				// TODO
				// play animation
			}
		}
		else
		{
			// TODO 
			// new Lighter
			Destroy(this);
		}
	}
}
