using UnityEngine;
using System.Collections;

/// <summary>
/// The spot for place the canyon
/// </summary>
public class CanyonSpotSceneItem : SceneItem {
	
	public override void Use (InventoryItem item)
	{
		if (state == 0)
		{
			// The spot is empty
			if (item is CanyonInventoryItem)
			{
				// Places the canyon inventory in the spot
				++state;
				//TODO
				// Changes the sprite of the spot, with the canyon
				ChangeSprite();
			}
		}
		else if (state == 1)
		{
			// The spot is with the canyon and ready to shoot
			if (item is LighterInventoryItem)
			{
				// Shoots the canyon
				++state;
				// Plays animation
				// Plays sounds
				++m_ItemToActivate.state; // Changes the state of the boss
			}
		}
		base.Use (item);
	}
}
