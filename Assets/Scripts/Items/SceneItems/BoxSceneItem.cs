using UnityEngine;
using System.Collections;

public class BoxSceneItem : PickableSceneItem
{
	public override void Use (InventoryItem item)
	{
		if (m_state == 0)
		{
			if (item is OctoropeInventoryItem)
			{
				++m_state;
				// TODO
				// play animation
                GetComponent<Animator>().SetTrigger("Fall");
			}
            else if (item != null)
            {
                base.Use(item);
            }
            else
            {
                MessageServer.SendMessage(m_keysInteract[state],Color.white);
            }
		}
		else
		{
			// TODO 
			// new Lighter
            Pick(false);
			Destroy(this);
		}
	}
}
