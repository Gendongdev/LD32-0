using UnityEngine;
using System.Collections;

public enum InventoryItemEnum
{
	STEAK=0,
	BARREL,
	KNIFE,
	OCTOPUS,
	LIANA,
	TIGER,
	CANYON,
	JETPACK,
	LIGTHTER,
	COUNT
}

public enum SceneItemEnum
{
	BOX = 0,
	WINDOW,
	COUNT
}


public class CombineManager : MonoBehaviour {

	public class Recipe{
		InventoryItemEnum m_obj1;
		InventoryItemEnum m_obj2;
		InventoryItemEnum m_result;

		bool CheckRecipe(InventoryItemEnum obj1, InventoryItemEnum obj2, InventoryItemEnum result)
		{
			if (obj1 == m_obj1) {
				if (obj2 == m_obj2)
				{
					result = m_result;
					return true;
				}
			}
			else if (obj1 == m_obj2)
			{
				if (obj2 == m_obj1)
				{
					result = m_result;
					return true;
				}
			}
			return false;
		}
	}

	public class Action{
	}
	
}
