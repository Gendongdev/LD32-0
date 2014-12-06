using UnityEngine;
using System.Collections;

public abstract class InteractiveItem : MonoBehaviour
{
	public string m_description;

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

public abstract class SceneItem : InteractiveItem {
	protected int m_state;
	public int state
	{
		get { return m_state; }
		set { m_state = value; }
	}
	public SceneItem m_ItemToActivate;
}
