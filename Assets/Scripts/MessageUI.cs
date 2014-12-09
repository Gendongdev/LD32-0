using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MessageUI : MonoBehaviour
{
	public Dictionary<string, string> m_translations = new Dictionary<string, string>()
	{
		// Generic messages
		{ "SCENE_ITEM_DESCRIPTION_NONE", "¿Qué es esto? Que raro..." },
		{ "ITEM_INTERACT_NONE", "No sé que hacer con eso." },
        { "NEW_ITEM_CHANGE_CHANNEL", "El cambio de canal ha afectado a algunos objetos de mi inventario." },

        // Prison
        { "PRISON_INTRO_TEXT", "¡Disfruta de tu última comida! ¡Ja ja ja!" },
        { "prisonSteak_text", "Un sabroso filete. Estoy hambriento pero podría ser útil." },
        { "prisonArchiver_text", "Contiene todos los juegos de Wii U y cinco cajones vacíos." },
        { "prisonArchiverInteract_text", "No puedo moverla." },
        { "prisonDoor_text", "Una puerta de madera maciza, cerrada." },
		{ "prisonDoorInteract_text", "Puedo escuchar a mis secuestradores al otro lado." },
		{ "prisonPoster_text", "Este tío es GENIAL." },
        { "prisonBoxState1_text", "Creo que podría usar un octorrope con eso." },
        { "prisonBoxState2_text", "Parece que hay algo dentro." },
        { "prisonWindow_text", "Ojalá pudiera volar para escapar por esa ventana." },
        { "prisonHole_text", "Parece un agujero pero son sólo 6 píxeles."},
        { "prisonHoleInteract_text", "No pienso meter la mano ahí." },
        { "prisonBed_text", "Huele a oveja..."},
        { "prisonBedInteract_text", "No pienso hacer la cama. Soy un tipo duro." },
        { "prisonSubArchiver_text", "Tan vacío como el catálogo de juegos de PS Vita." },
        { "prisonBoxInteract_text", "No la alcanzo."},
        { "SCENE_ITEM_INTERACT_POSTER", "Mejor lo dejo ahí. Él es mi inspiración." },
        { "SCENE_ITEM_INTERACT_WINDOW", "No alcanzo." },

		// Documentary items
		{ "SCENE_ITEM_DESCRIPTION_ROPE", "Parece una liana... o una serpiente." },
		{ "SCENE_ITEM_DESCRIPTION_TIGER_HUNGRY", "Mejor no acercarse, parece muy hambriento..." },
		{ "SCENE_ITEM_DESCRIPTION_TIGER_DISTRACTED", "El tigre se ha quedado dormido tras devorar el filete." },
		{ "SCENE_ITEM_DESCRIPTION_TIGER_CAGED", "¡No puedo creer que haya sido capaz de enjaular a esa bestia!" },
		{ "SCENE_ITEM_INTERACT_TIGER_NO", "'Ey, gatito, gatito...'" },

		// Game items
		{ "SCENE_ITEM_DESCRIPTION_KNIFE", "Un cuchillo afilado y brillante." },
		{ "SCENE_ITEM_DESCRIPTION_BOSS_ALIVE", "El enemigo está volando al fondo con su jetpack." },
		{ "SCENE_ITEM_DESCRIPTION_BOSS_DEAD", "La inmensa explosión le ha incapacitado." },
		{ "SCENE_ITEM_DESCRIPTION_BOSS_LOOTED", "La inmensa explosión le ha incapacitado" },
		{ "SCENE_ITEM_DESCRIPTION_BOSS_GLITCHED", "'Sí, tengo un glitch, ¡pero al menos no puedes ver a través de mi cara!'" },
		{ "SCENE_ITEM_INTERACT_BOSS_ALIVE", "'¡Muajajajá! ¡No puedes vencerme!'" },
		{ "SCENE_ITEM_INTERACT_BOSS_DEAD", "Me quedaré su jetpack." },
		{ "SCENE_ITEM_INTERACT_BOSS_NO_LIGHTER", "Necesito algo para prender el cañón." },

        // Pirate scene
        { "song_text", "'La vida pirata es la vida mejor.'"},
        { "lookPirate_text", "Está vigilando el cañón."},
        { "lookPirateSing_text", "El pirata está cantado."},
        { "lookLoveCat_text", "Estará distraído un rato."},
        { "pirate_text", "'¡Eh, tú! ¿Qué estás haciendo aquí?'"},
        { "cat_text", "'Adoro los gatos.'"},
        { "inside_text", "La sala del tesoro está llena de caramelos."}, 
        { "barrel_text", "Un barríl vacío."},
        { "canyon_text", "El pirata está vigilando el cañón, no puedo llevarmelo."},
        { "lookCanyon_text", "Un arma poderosa, sin duda."},
        { "lookGrid_text", "La red está llena de pescado."},
        { "lookOctopus_text", "Quizás podría fabricar un octorrope con él."},
        { "grid_text", "He cortado la red con el cuchillo."},
        { "lookGetCanyon_text", "Ya no hay nadie vigilándolo, ¡pa' la saca!."},
        { "SCENE_ITEM_INTERACT_HATCH", "La escotilla está atrancada." },
        { "SCENE_ITEM_INTERACT_NET", "Quizás podría romperla con algo afilado." },
        { "SCENE_ITEM_PIRATE_SINGER_COMBINE_OCTOROPE", "¡Guau! ¡Un octorrope casero! ¡Qué alucine!" },
        { "SCENE_ITEM_PIRATE_SINGER_COMBINE_OTHER", "'No lo quiero.'" },
        { "SCENE_ITEM_PIRATE_GUARD_COMBINE_NOCAT", "'¡Aléjate o dormirás con los tiburones!'" },
        { "SCENE_ITEM_PIRATE_GUARD_COMBINE_BUSY", "Está ocupado con el gato." },

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
