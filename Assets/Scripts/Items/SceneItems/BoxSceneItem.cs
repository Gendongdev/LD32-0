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
                GameObject.Find("Prison_Octopus").GetComponent<OctoropeAnimations>().OctoropeBoxAnimation();
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

    public void EndAnimation()
    {
        GameObject.Find("Prison_Octopus").GetComponent<OctoropeAnimations>().EndBoxAnimation();
    }
}
