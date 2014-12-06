using UnityEngine;
using System.Collections;

public abstract class InteractiveItem : MonoBehaviour
{
	public string m_description;

	public abstract void Use(InventoryItem item);
}

public abstract class InventoryItem : InteractiveItem
{
	public Sprite m_sprite;

	public override void Use(InventoryItem item)
	{
		MessageServer.SendMessage ("I don't know what to do with that", Color.white);
	}
}

public abstract class SceneItem : InteractiveItem {
	
}
