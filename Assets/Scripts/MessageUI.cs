using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MessageUI : MonoBehaviour
{
	public Dictionary<string, string[]> m_translations = new Dictionary<string, string[]>()
	{
		// Generic messages
		{ "SCENE_ITEM_DESCRIPTION_NONE", new string[] { "What is this? I don't even.", "¿Qué es esto? Que raro..." }},
		{ "ITEM_INTERACT_NONE", new string[] {"I don't know what to do with that.", "No sé que hacer con eso."} },
        { "NEW_ITEM_CHANGE_CHANNEL",  new string[] {"This channel has changed something in my inventory","El cambio de canal ha afectado a algunos objetos de mi inventario." } },

        // Prison
        { "PRISON_INTRO_TEXT", new string[] {"Enjoy your last meal! Ha ha ha!", "¡Disfruta de tu última comida! ¡Ja ja ja!" } },
        { "prisonSteak_text", new string[] {"It's a steak. I'm hungry but it could be useful.", "Un sabroso filete. Estoy hambriento pero podría ser útil." } },
        { "prisonArchiver_text", new string[] {"It's full of Wii U games... Useless.", "Contiene todos los juegos de Wii U y cinco cajones vacíos."} },
        { "prisonArchiverInteract_text", new string[] {"I can't move it.", "No puedo moverla." } },
        { "prisonDoor_text", new string[] {"A closed wooden door.", "Una puerta de madera maciza, cerrada." } },
		{ "prisonDoorInteract_text", new string[] {"I can hear my captors at the other side." , "Puedo escuchar a mis secuestradores al otro lado." }},
		{ "prisonPoster_text", new string[] {"HE is awesome.", "Este tío es GENIAL." } },
        { "prisonBoxState1_text", new string[] {"I think I could use an octorope with that.", "Creo que podría usar un octorrope con eso." } },
        { "prisonBoxState2_text", new string[] {"It seems to have something inside.", "Parece que hay algo dentro." }},
        { "prisonWindow_text", new string[] {"I wish I could fly to escape through that window.", "Ojalá pudiera volar para escapar por esa ventana." } },
        { "prisonHole_text", new string[] {"It looks like a hole but it's just 6 pixels.", "Parece un agujero pero son sólo 6 píxeles."}},
        { "prisonHoleInteract_text", new string[] {"I'm not going to put my hand in there.", "No pienso meter la mano ahí." } },
        { "prisonBed_text", new string[] {"Looks like if a tiger had been sleeping there.", "Huele a oveja..."}},
        { "prisonBedInteract_text", new string[] {"I'm not going to make the bed. I'm a tough guy.", "No pienso hacer la cama. Soy un tipo duro." } },
        { "prisonSubArchiver_text", new string[] {"This is so empty as the catalog of PS Vita.", "Tan vacío como el catálogo de juegos de PS Vita." } },
        { "prisonBoxInteract_text", new string[] {"I can't reach it.", "No la alcanzo."}},
        { "SCENE_ITEM_INTERACT_POSTER", new string[] {"I'll better leave it there, he's my inspiration.", "Mejor lo dejo ahí. Él es mi inspiración." } },
        { "SCENE_ITEM_INTERACT_WINDOW", new string[] {"I can't reach it.", "No alcanzo." } },

		// Documentary items
		{ "SCENE_ITEM_DESCRIPTION_ROPE", new string[] {"Looks like a liana... or a snake.", "Parece una liana... o una serpiente." } },
		{ "SCENE_ITEM_DESCRIPTION_TIGER_HUNGRY", new string[] {"I'd better not approach this tiger, he looks so hungry...", "Mejor no acercarse, parece muy hambriento..." } },
		{ "SCENE_ITEM_DESCRIPTION_TIGER_DISTRACTED", new string[] {"The tiger has fallen asleep after eating that steak.", "El tigre se ha quedado dormido tras devorar el filete." } },
		{ "SCENE_ITEM_DESCRIPTION_TIGER_CAGED", new string[] {"I can't believe I've been able to cage that beast!", "¡No puedo creer que haya sido capaz de enjaular a esa bestia!" } },
		{ "SCENE_ITEM_INTERACT_TIGER_NO", new string[] {"'Hey kitty, kitty, kitty!'", "'Ey, gatito, gatito...'" } },

		// Game items
		{ "SCENE_ITEM_DESCRIPTION_KNIFE", new string[] {"A shiny sharp knife.", "Un cuchillo afilado y brillante." } },
		{ "SCENE_ITEM_DESCRIPTION_BOSS_ALIVE", new string[] {"The boss is flying over there with his jetpack.", "El enemigo está volando al fondo con su jetpack." } },
		{ "SCENE_ITEM_DESCRIPTION_BOSS_DEAD", new string[] {"He's been incapacitated by that big explosion.", "La inmensa explosión le ha incapacitado." } },
		{ "SCENE_ITEM_DESCRIPTION_BOSS_LOOTED", new string[] {"He's been incapacitated by that big explosion.", "La inmensa explosión le ha incapacitado" } },
		{ "SCENE_ITEM_DESCRIPTION_BOSS_GLITCHED", new string[] {"'Yeah, I'm glitched, but at least you can't see through my face!'", "'Sí, tengo un glitch, ¡pero al menos no puedes ver a través de mi cara!'" } },
		{ "SCENE_ITEM_INTERACT_BOSS_ALIVE", new string[] {"'Ha ha ha! You can't defeat me!'", "'¡Muajajajá! ¡No puedes vencerme!'" } },
		{ "SCENE_ITEM_INTERACT_BOSS_DEAD", new string[] {"I'll take his jetpack.", "Me quedaré su jetpack." } },
		{ "SCENE_ITEM_INTERACT_BOSS_NO_LIGHTER", new string[] {"I need something to fire the cannon.", "Necesito algo para prender el cañón." } },

        // Pirate scene
        { "song_text", new string[] {"'Yo ho, yo ho, a pirate's life for me.'", "'La vida pirata es la vida mejor.'"}},
        { "lookPirate_text", new string[] {"He's guarding the cannon.", "Está vigilando el cañón."}},
        { "lookPirateSing_text", new string[] {"The pirate is singing.", "El pirata está cantado."}},
        { "lookLoveCat_text", new string[] {"He will be distracted for a while.", "Estará distraído un rato."}},
        { "pirate_text", new string[] {"'Hey! What are you doing here?'", "'¡Eh, tú! ¿Qué estás haciendo aquí?'"}},
        { "cat_text", new string[] {"'I love cats.'", "'Adoro los gatos.'"}},
        { "inside_text", new string[] {"The treasure room is full of candy.", "La sala del tesoro está llena de caramelos."}}, 
        { "barrel_text", new string[] {"An empty barrel.", "Un barríl vacío."}},
        { "canyon_text", new string[] {"The pirate is guarding the cannon. I can't take it.", "El pirata está vigilando el cañón, no puedo llevarmelo."}},
        { "lookCanyon_text", new string[] {"It's a powerful weapon.", "Un arma poderosa, sin duda."}},
        { "lookGrid_text", new string[] {"There's a lot of fish in the net.", "La red está llena de pescado."}},
        { "lookOctopus_text", new string[] {"Perhaps I could craft an octorope with it.", "Quizás podría fabricar un octorrope con él."}},
        { "grid_text", new string[] {"I've cut the net with my knife.", "He cortado la red con el cuchillo."}},
        { "lookGetCanyon_text", new string[] {"Nobody's guarding it anymore.", "Ya no hay nadie vigilándolo, ¡pa' la saca!."}},
        { "SCENE_ITEM_INTERACT_HATCH", new string[] {"It's closed.", "La escotilla está atrancada." } },
        { "SCENE_ITEM_INTERACT_NET", new string[] {"I could cut it open if I had something sharp.", "Quizás podría romperla con algo afilado." } },
        { "SCENE_ITEM_PIRATE_SINGER_COMBINE_OCTOROPE", new string[] {"Wow! A homemade octorope! Cool!", "¡Guau! ¡Un octorrope casero! ¡Qué alucine!" } },
        { "SCENE_ITEM_PIRATE_SINGER_COMBINE_OTHER", new string[] {"'I don't want that.'", "'No lo quiero.'" } },
        { "SCENE_ITEM_PIRATE_GUARD_COMBINE_NOCAT", new string[] {"'Stay away or I’ll feed thee to the sharks!'", "'¡Aléjate o dormirás con los tiburones!'" } },
        { "SCENE_ITEM_PIRATE_GUARD_COMBINE_BUSY", new string[] {"He's busy with the cat.", "Está ocupado con el gato." } },

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
            if (Application.systemLanguage == SystemLanguage.Spanish)
			    message = m_translations[message][1];
            else
                message = m_translations[message][0];
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
