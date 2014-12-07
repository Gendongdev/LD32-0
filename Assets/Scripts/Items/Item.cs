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

		MessageServer.SendMessage ("I don't know what to do with that", Color.white);
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
		case 1:
			m_sprite = m_spriteChannel1;
			break;
		case 2:
			m_sprite = m_spriteChannel2;
			break;
		case 3:
			m_sprite = m_spriteChannel3;
			break;
		case 4:
			m_sprite = m_spriteChannel4;
			break;
		}
	}
}

public abstract class SceneItem : InteractiveItem
{
    public string[] m_messageKeys;
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
        if (m_messageKeys != null && m_messageKeys.Length > state )
            MessageServer.SendMessage(m_messageKeys[state],Color.white);
        else
            // Default message
            MessageServer.SendMessage ("What is this? I don't even.", Color.white);
	}
}

