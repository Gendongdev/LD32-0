using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryMenu : MonoBehaviour
{
	public GameObject m_gameController;
	public Button[] m_slots;

	private Animator m_animator;
	private Inventory m_inventoryManager;
	private Cursor m_cursorManager;

	public bool Expanded
	{
		get { return m_animator.GetBool("expanded"); }
		set { m_animator.SetBool ("expanded", value);}
	}

	public void Awake()
	{
		m_animator = GetComponent<Animator>();
		m_inventoryManager = m_gameController.GetComponent<Inventory> ();
		m_cursorManager = m_gameController.GetComponent<Cursor> ();
	}

	public void Update()
	{
		for (int i = 0; i < m_slots.Length; ++i)
		{
			Button slot = m_slots[i];

			if(i < m_inventoryManager.m_items.Length)
			{
				AssignItemToSlot(slot, m_inventoryManager.m_items[i]);
			}
			else
			{
				ClearSlot(slot);
			}
		}
	}

	private void AssignItemToSlot(Button slot, InventoryItem item)
	{
		// TODO Change texture to that of the item
		if(item == m_cursorManager.Item)
			slot.image.color = Color.green; // FIXME Test
		else
			slot.image.color = Color.red; // FIXME Test
	}

	private void ClearSlot(Button slot)
	{
		// TODO Change texture to empty slot
		slot.image.color = Color.blue; // FIXME Test
	}

	public void ToggleExpanded()
	{
		Expanded = !Expanded;
	}

	public void SlotClicked(Button slot)
	{
		int slotIndex;
		for(slotIndex = 0; slotIndex < m_slots.Length; ++slotIndex)
		{
			if(m_slots[slotIndex] == slot)
			{
				break;
			}
		}

		InventoryItem item = slotIndex < m_inventoryManager.m_items.Length ? m_inventoryManager.m_items [slotIndex] : null;
		InventoryItem cursorItem = m_cursorManager.Item;

		if (item != null && cursorItem != null && item != cursorItem)
		{
			cursorItem.Use(item);
			m_cursorManager.Item = null;
		}
		else
		{
			m_cursorManager.Item = item;
		}
	}
}
