using UnityEngine;
using System.Collections;

public abstract class InteractiveItem : MonoBehaviour {
	string m_description;

	protected abstract void Use(InventoryItem item);
	public virtual string Look()
	{
		return m_description;
	}
}

public class InventoryItem : InteractiveItem {
	protected override void Use (InventoryItem item)
	{
		throw new System.NotImplementedException ();
	}
}

public class SceneItem : InteractiveItem {

	protected override void Use (InventoryItem item)
	{
		//CombineManager.
	}
}
