using UnityEngine;
using System.Collections;
using System.Linq;

public class BossGameSceneItem : SceneItem
{
	public GameObject m_jetpackPrefab;

	public override void Look ()
	{
		if (state > 0 && !GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0).IsName("Boss dead"))
		{
			MessageServer.SendMessage("SCENE_ITEM_DESCRIPTION_BOSS_GLITCHED", Color.red);
		}
		else
		{
			base.Look();
		}
	}

	public override void Use (InventoryItem item)
	{
		if (state == 0 && item is CanyonInventoryItem)
        {
			InventoryItem lighter = FindLighter();

			if(lighter == null)
			{
				MessageServer.SendMessage("SCENE_ITEM_INTERACT_BOSS_NO_LIGHTER", Color.white);
			}
			else
			{
				// TODO Explosion?
				GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(item);
				GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(lighter);
				GetComponent<Animator>().SetBool("killed", true);
				state++;
			}
        }
		else if (state == 0 && item == null)
		{
			MessageServer.SendMessage("SCENE_ITEM_INTERACT_BOSS_ALIVE", Color.red);
		}
        else if (state == 1 && item == null)
        {
			GameManager.GetInstance().GetComponent<Inventory>().AddItem(m_jetpackPrefab);
			base.Use(item);
			state++;
        }
		else
		{
			base.Use (item);
		}
	}

	private InventoryItem FindLighter()
	{
		return GameManager.GetInstance ().GetComponent<Inventory> ().m_items.Where (i => i is LighterInventoryItem).FirstOrDefault ();
	}
}
