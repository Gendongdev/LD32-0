using UnityEngine;
using System.Collections;
using System.Linq;

public class PirateSceneItem : SceneItem {

	public override void Use (InventoryItem item)
	{
		if (m_state == 0)
		{
			// Initial State
            if (item is TigerInventoryItem)
            {
                base.Use(item);
                GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(item);

                ++m_state;
                // Activates the canyon
                m_ItemToActivate.state++;

				foreach(Transform t in transform)
				{
					t.gameObject.SetActive(true);
				}

				transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                base.Use(null);
            }

		}
		else
		{
			// The pirate is busy loving the kitten
            base.Use(item);
		}
	}
}
