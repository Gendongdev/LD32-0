using UnityEngine;
using System.Collections;

public class SteakSceneItem : SceneItem
{
	public override void Use(InventoryItem item)
	{
		if(item == null)
		{
			Object prefab = Resources.Load("Prefabs/Steak");
			GameObject newItem = Instantiate(prefab) as GameObject;
			GameManager.GetInstance().GetComponent<Inventory>().AddItem(newItem.GetComponent<InventoryItem>());
		}
	}
}
