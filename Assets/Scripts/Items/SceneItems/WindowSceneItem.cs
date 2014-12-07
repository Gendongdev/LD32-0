using UnityEngine;
using System.Collections;

public class WindowSceneItem : SceneItem {
    public override void Use(InventoryItem item)
    {
        if (item is JetpackInventoryItem)
        {
            // TODO
            // The end

        }
        else
        {
            base.Use(item);
        }
    }

}
