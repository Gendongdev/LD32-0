using UnityEngine;
using System.Collections;

public class CanyonSceneItem : PickableSceneItem {

	public override void Use (InventoryItem item)
	{
		if (state == 0)
		{
			// The canyon is inacessible because the pirate is using it
            MessageServer.SendMessage(m_keysInteract[state], Color.white);
			return;
		}
        base.Use(item);
	}

}
