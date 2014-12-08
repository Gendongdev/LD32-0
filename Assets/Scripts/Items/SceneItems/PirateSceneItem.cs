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
                audio.Play();
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
            else if (item == null)
            {
                MessageServer.SendMessage("pirate_text", Color.yellow);
            }
            else
            {
                base.Use(item);
            }

		}
		else
		{
            if (item == null)
            {
                MessageServer.SendMessage("cat_text", Color.yellow);
            }
            else
            {
                base.Use(item);
            }
		}
	}
}
