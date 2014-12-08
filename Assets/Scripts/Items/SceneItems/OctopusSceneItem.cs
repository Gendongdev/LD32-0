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
                audio.Play();
                base.Use(item);
                transform.parent.gameObject.renderer.enabled = false;

                foreach (Transform child in transform.parent)
                    child.gameObject.renderer.enabled = true;

                GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(item);

                ++m_state;
            }
			else if(item == null)
			{
                MessageServer.SendMessage("SCENE_ITEM_INTERACT_NET", Color.white);
			}
			else
			{
				base.Use(item);
			}
        }
        else
        {
            base.Use(item);
        }
    }
}
