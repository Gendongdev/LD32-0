using UnityEngine;
using System.Collections;

public abstract class InteractiveItem : MonoBehaviour
{
	/// <summary>
	/// Use with null is take the object. Use with a parameter is use the item with it
	/// </summary>
	/// <param name="item">Item to use with this item</param>
	public virtual void Use(InventoryItem item)
	{
		MessageServer.SendMessage ("ITEM_INTERACT_NONE", Color.white);
	}
}

public abstract class InventoryItem : InteractiveItem
{
	public Sprite m_spriteChannel1;
	public Sprite m_spriteChannel2;
	public Sprite m_spriteChannel3;
	public Sprite m_spriteChannel4;

	public Sprite m_sprite;

	public void ChangeChannel(int channel)
	{
		switch (channel)
		{
		case 0:
			m_sprite = m_spriteChannel1;
			break;
		case 1:
			m_sprite = m_spriteChannel2;
			break;
		case 2:
			m_sprite = m_spriteChannel3;
			break;
		case 3:
			m_sprite = m_spriteChannel4;
			break;
		}
	}
}

public abstract class SceneItem : InteractiveItem
{
    public string[] m_keysLook;
	public string[] m_keysInteract;
	public string[] m_keysCombine;

	protected int m_state;
	public int state
	{
		get { return m_state; }
		set { m_state = value; }
	}

	/// <summary>
	/// Represents the sprites for each state. The state 0 is the sprite the Render component has.
	/// m_sprites[1] represents the sprite for the state 1 and so on.
	/// </summary>
	public Sprite[] m_sprites;

	public SceneItem m_ItemToActivate;	

	/// <summary>
	/// Changes the sprite according to m_state.
	/// </summary>
	protected void ChangeSprite()
	{
		if ((m_sprites != null) && (m_sprites.Length > state))
		{
			GetComponent<SpriteRenderer>().sprite = m_sprites[state];
		}
	}

	public virtual void Look()
	{
		if (m_keysLook != null && m_keysLook.Length > state)
		{
			MessageServer.SendMessage(m_keysLook[state], Color.white);
		}
        else
		{
            // Default message
			MessageServer.SendMessage("SCENE_ITEM_DESCRIPTION_NONE", Color.white);
		}
	}

	public override void Use (InventoryItem item)
	{
		if(item == null)
		{
			if(m_keysInteract != null && m_keysInteract.Length > state)
			{
				MessageServer.SendMessage(m_keysInteract[state], Color.white);
			}
			else
			{
				base.Use(item);
			}
		}
		else
		{
			if(m_keysCombine != null && m_keysCombine.Length > state)
			{
				MessageServer.SendMessage(m_keysCombine[state], Color.white);
			}
			else
			{
				base.Use(item);
			}
		}
	}
}

