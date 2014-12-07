using UnityEngine;
using System.Collections;

public class WindowSceneItem : SceneItem {
    public override void Use(InventoryItem item)
    {
        if (item is JetpackInventoryItem)
        {
            Credits credits;

            credits = GameObject.FindWithTag("Credits").GetComponent<Credits>();

            credits.Roll();
        }
        else
        {
            base.Use(item);
        }
    }

}
