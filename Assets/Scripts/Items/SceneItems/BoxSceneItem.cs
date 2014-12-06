﻿using UnityEngine;
using System.Collections;

public class BoxSceneItem : SceneItem {
	int m_state;

	public override void Use (InventoryItem item)
	{
		if (m_state == 0)
		{
			if (item is OctAndLianaInventoryItem)
			{
				++m_state;
				// TODO
				// play animation
			}
		}
		else
		{
			// TODO 
			// new Lighter
			Destroy(this);
		}
	}
}
