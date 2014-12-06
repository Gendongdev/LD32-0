using UnityEngine;
using System.Collections;

public class PirateSceneItem : SceneItem {

	public override void Use (InventoryItem item)
	{
		if (m_state == 0)
		{
			// Initial State
			if (item is TigerInventoryItem)
			{
				++m_state;
				// Activates the canyon
				m_ItemToActivate.state++;

				// TODO
				// Play animation for loving the kitten
			}
		}
		else
		{
			// The pirate is busy loving the kitten
		}
	}
}
