﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MessageUI : MonoBehaviour
{
	public Dictionary<string, string> m_translations = new Dictionary<string, string>()
	{
		// Generic messages
		{ "SCENE_ITEM_DESCRIPTION_NONE", "What is this? I don't even." },
		{ "ITEM_INTERACT_NONE", "I don't know what to do with that." },

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
		{ "SCENE_ITEM_DESCRIPTION_BOSS_ALIVE", "The boss is flying over there with his jetpack." },
		{ "SCENE_ITEM_DESCRIPTION_BOSS_DEAD", "He's been incapacitated by that big explosion." },
		{ "SCENE_ITEM_DESCRIPTION_BOSS_LOOTED", "He's been incapacitated by that big explosion." },
		{ "SCENE_ITEM_DESCRIPTION_BOSS_GLITCHED", "'Yeah, I'm glitched, but at least you can't see through my face!'" },
		{ "SCENE_ITEM_INTERACT_BOSS_ALIVE", "'Ha ha ha! You can't defeat me!'" },
		{ "SCENE_ITEM_INTERACT_BOSS_DEAD", "I'll take his jetpack." },
		{ "SCENE_ITEM_INTERACT_BOSS_NO_LIGHTER", "I need something to fire the cannon." },


	};

	public float m_timePerCharacter = 0.2f;
	public Image m_background;

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
			Debug.LogWarning("Untranslated message: " + message);
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

		m_background.canvasRenderer.SetAlpha (m_text.text == string.Empty ? 0 : 100);
	}
}
