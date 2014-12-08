using UnityEngine;
using System.Collections;

public class WindowSceneItem : SceneItem {
    public override void Use(InventoryItem item)
    {
        if (item is JetpackInventoryItem)
        {
            item.audio.Play();

            GameObject.Find("Prison_Octopus").GetComponent<OctoropeAnimations>().OctoropeEndAnimation();

        }
        else
        {
            base.Use(item);
        }
    }

}
