using UnityEngine;
using System.Collections;

public class OctopusSceneItem : PickableSceneItem {

    public override void Use(InventoryItem item)
    {
        if (m_state == 0)
        {
            // Initial State
            if (item is KnifeInventoryItem)
            {
                


                // TODO
                // Play animation for loving the kitten

                base.Use(item);
                transform.parent.gameObject.renderer.enabled = false;

                foreach (Transform child in transform.parent)
                    child.gameObject.renderer.enabled = true;

                GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(item);

                ++m_state;
            }

        }
        else
        {
            base.Use(item);
        }
    }
}
