using UnityEngine;
using System.Collections;

public class RopeSceneItem : SceneItem {

	public override void Use (InventoryItem item)
	{
		Object prefab = Resources.Load("Prefabs/RopeInventary");
		GameObject rope = Instantiate(prefab) as GameObject;
		GameManager.GetInstance().GetComponent<Inventory>().AddItem(rope.GetComponent<InventoryItem>());
	}
}
