using UnityEngine;
using System.Collections;

/// <summary>
/// Item that is pickable for the player and has an IventoryItem prefab reference to load when
/// the player picks it.
/// </summary>
public class PickableSceneItem : SceneItem
{
    public GameObject m_inventoryPrefab;
    
    protected void Pick()
    {
        GameManager.GetInstance().GetComponent<Inventory>().AddItem(m_inventoryPrefab);
        Destroy(this.gameObject);
    }
    
    public override void Use(InventoryItem item)
    {
        Pick();
    }
}
