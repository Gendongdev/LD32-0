using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MessageUI : MonoBehaviour
{
	public Dictionary<string, string> m_translations = new Dictionary<string, string>()
	{
		{ "Sample original text 1", "Sample translated text 1" },
		{ "Sample original text 2", "Sample translated text 2" },
		{ "Sample original text 3", "Sample translated text 3" },

        // Prison
        { "prisonSteak_text", "It's a steak. I'm hungry but it could be useful" },
        { "prisonArchiver_text", "It's full of Wii U games... Useless." },
        { "prisonArchiverInteract_text", "I can't move it." },
        { "prisonDoor_text", "A closed wooden door." },
		{ "prisonDoorInteract_text", "I can hear my captors at the other side." },
		{ "prisonPoster_text", "HE is awesome." },
        { "prisonBoxState1_text", "I think I could use an octorope with that." },
        { "prisonBoxState2_text", "It seems to have something inside." },
        { "prisonWindow_text", "I can't reach it. I wish I had something to escape." },


		// Documentary items
		{ "SCENE_ITEM_DESCRIPTION_ROPE", "Looks like a liana... or a snake." },
		{ "SCENE_ITEM_DESCRIPTION_TIGER_HUNGRY", "I'd better not approach this tiger, he looks so hungry..." },
		{ "SCENE_ITEM_DESCRIPTION_TIGER_DISTRACTED", "The tiger has fallen asleep after eating that steak." },
		{ "SCENE_ITEM_DESCRIPTION_TIGER_CAGED", "I can't believe I've been able to cage that beast!" },
		{ "SCENE_ITEM_INTERACT_TIGER_NO", "'Hey kitty, kitty, kitty!'" },

		// Game items
		{ "SCENE_ITEM_DESCRIPTION_KNIFE", "A shiny sharp knife." },
	};

	public float m_timePerCharacter = 0.2f;

	private float m_timeRemaining;
	private Text m_text;

	void Awake()
	{
		m_text = GetComponent<Text> ();
	}

	void OnEnable()
	{
		MessageServer.OnMessage += OnMessage;
	}

	void OnDisable()
	{
		MessageServer.OnMessage -= OnMessage;
	}

	void OnMessage(string message, Color color)
	{
		if(m_translations.ContainsKey(message))
		{
			message = m_translations[message];
		}
		else
		{
			Debug.Log("Untranslated message: " + message);
		}

		m_text.text = message;
		m_text.color = color;
		m_timeRemaining = message.Length * m_timePerCharacter;
	}
	
	void Update()
	{
		if (m_timeRemaining > 0)
		{
			m_timeRemaining -= Time.deltaTime;
			if(m_timeRemaining <= 0)
			{
				m_text.text = string.Empty;
			}
		}
	}
}
