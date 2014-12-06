using UnityEngine;
using System.Collections;

public abstract class InteractiveItem : MonoBehaviour {
	string m_description;

	public abstract void Use(InventoryItem item);
	public virtual string Look()
	{
		return m_description;
	}
}

public abstract class InventoryItem : InteractiveItem {

}

public abstract class SceneItem : InteractiveItem {
	
}
