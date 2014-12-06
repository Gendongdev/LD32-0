using UnityEngine;
using System.Collections;

public abstract class InteractiveItem : MonoBehaviour {
	public string m_description;

	public abstract void Use(InventoryItem item);

	public virtual string Look()
	{
		return m_description;
	}
}

public class InventoryItem : InteractiveItem {
	public override void Use (InventoryItem item)
	{
		throw new System.NotImplementedException ();
	}
}

public class SceneItem : InteractiveItem {

	public override void Use (InventoryItem item)
	{
		//CombineManager.
	}
}
