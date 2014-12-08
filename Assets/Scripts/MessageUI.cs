using UnityEngine;
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
        { "NEW_ITEM_CHANGE_CHANNEL", "This channel has changed something in my inventory" },

        // Prison
        { "PRISON_INTRO_TEXT", "Enjoy your last meal! Ha ha ha!" },
        { "prisonSteak_text", "It's a steak. I'm hungry but it could be useful." },
        { "prisonArchiver_text", "It's full of Wii U games... Useless." },
        { "prisonArchiverInteract_text", "I can't move it." },
        { "prisonDoor_text", "A closed wooden door." },
		{ "prisonDoorInteract_text", "I can hear my captors at the other side." },
		{ "prisonPoster_text", "HE is awesome." },
        { "prisonBoxState1_text", "I think I could use an octorope with that." },
        { "prisonBoxState2_text", "It seems to have something inside." },
        { "prisonWindow_text", "I wish I could fly to escape through that window." },
        { "prisonHole_text", "It looks like a hole but it's just 6 pixels."},
        { "prisonHoleInteract_text", "I'm not going to put my hand in there." },
        { "prisonBed_text", "Looks like if a tiger had been sleeping there."},
        { "prisonBedInteract_text", "I'm not going to make the bed. I'm a tough guy." },
        { "prisonSubArchiver_text", "It is empty of PS-Vita games as normal." },
        { "prisonBoxInteract_text", "I can't reach it."},
        { "SCENE_ITEM_INTERACT_POSTER", "I'll better leave it there, he's my inspiration." },
        { "SCENE_ITEM_INTERACT_WINDOW", "I can't reach it." },

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

        // Pirate scene
        { "song_text", "'Yo ho, yo ho, a pirate's life for me.'"},
        { "lookPirate_text", "He's guarding the cannon."},
        { "lookPirateSing_text", "The pirate is singing."},
        { "lookLoveCat_text", "He will be distracted for a while."},
        { "pirate_text", "'Hey! What are you doing here?'"},
        { "cat_text", "'I love cats.'"},
        { "inside_text", "The treasure room is full of candy."}, 
        { "barrel_text", "An empty barrel."},
        { "canyon_text", "The pirate is guarding the cannon. I can't take it."},
        { "lookCanyon_text", "It's a powerful weapon."},
        { "lookGrid_text", "There's a lot of fish in the net."},
        { "lookOctopus_text", "Perhaps I could craft an octorope with it."},
        { "grid_text", "I've cut the net with my knife."},
        { "lookGetCanyon_text", "Nobody's guarding it anymore."},
        { "SCENE_ITEM_INTERACT_HATCH", "It's closed." },
        { "SCENE_ITEM_INTERACT_NET", "I could cut it open if I had something sharp." },
        { "SCENE_ITEM_PIRATE_SINGER_COMBINE_OCTOROPE", "Wow! A homemade octorope! Cool!" },
        { "SCENE_ITEM_PIRATE_SINGER_COMBINE_OTHER", "'I don't want that.'" },
        { "SCENE_ITEM_PIRATE_GUARD_COMBINE_NOCAT", "'Stay away or I’ll feed thee to the sharks!'" },
        { "SCENE_ITEM_PIRATE_GUARD_COMBINE_BUSY", "He's busy with the cat." },

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
