using UnityEngine;
using System.Collections;

public class BossGameSceneItem : SceneItem {

	public override void Use (InventoryItem item)
	{
		if (state == 0)
        {
            // The boss is flying so is impossible to do anything but shoot
            MessageServer.SendMessage("I think I can try to shoot him with something", Color.white);
            return;
        }
        else if (state == 1)
        {
            // The boss is dead and you can take the jetpack
            // TODO
            // Add jetpack inventory item to the inventory
            return;
        }

		base.Use (item);
	}
}
