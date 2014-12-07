using UnityEngine;
using System.Collections;

public class CanyonSceneItem : SceneItem {

    public GameObject m_canyonInventoryPrefab;
	public override void Use (InventoryItem item)
	{
		if (state == 0)
		{
			// The canyon is inacessible because the pirate is using it
			MessageServer.SendMessage("I think the pirate will kill me if I try to take the canyon", Color.white);
			return;
		}
        GameManager.GetInstance().GetComponent<Inventory>().AddItem(m_canyonInventoryPrefab);
	}
}
