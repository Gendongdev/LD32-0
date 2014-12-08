﻿using UnityEngine;
using System.Collections;

public class TigerSceneItem : PickableSceneItem
{
	public override void Use (InventoryItem item)
	{
		if(item == null && state < 2)
		{
            audio.Play();
			MessageServer.SendMessage("SCENE_ITEM_INTERACT_TIGER_NO", Color.white);
		}
		else if(item is SteakInventoryItem && state == 0)
		{
			state = 1;
			GetComponentsInChildren<ParticleSystem>(true)[0].gameObject.SetActive(true);
			GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(item);
		}
		else if(item is BarrelInventoryItem && state == 1)
		{
            audio.Play();
			state = 2;
			// TODO Show animation caging the tiger
			GetComponentsInChildren<ParticleSystem>(true)[0].gameObject.SetActive(false);
			GameManager.GetInstance().GetComponent<Inventory>().RemoveItem(item);
			GetComponent<SpriteRenderer>().sprite = m_sprites[state];
			transform.localPosition = new Vector3(-492, -223, 0);
			Destroy(GetComponent<BoxCollider2D>());
			gameObject.AddComponent<BoxCollider2D>();
		}
		else
		{
			base.Use(item);
		}
	}

    public override void Look()
    {
        audio.Play();
        base.Look();
    }
}
