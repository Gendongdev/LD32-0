using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject[] Channels;
    public Dial ChannelDial;
    public Dial InputDial;
    public UnityEngine.UI.Text m_channelIndicator;

    public AudioClip m_changeChannelAudio;

	static GameManager m_instance;

    private int _currenChannel = 1;


	public static GameManager GetInstance()
	{
		return m_instance;
	}

	void Awake()
	{
		if (m_instance != null)
			Destroy(m_instance);
		m_instance = this;

        // Print initial message
        MessageServer.SendMessage("PRISON_INTRO_TEXT", Color.green);

        GetComponent<Analytics>().TrackEvent("GameStarted");
	}

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UpdateDials()
    {

        int newChannel = 0;

        if (InputDial.Selector == 0)
        {
            newChannel = ChannelDial.Selector + 1;
        }            
        else
        {
            newChannel = 0;
        }

        string indicatorText;

        if (newChannel == 0)
        {
            indicatorText = "AV";
        }
        else
        {
            indicatorText = string.Format("CH {0}", newChannel);
        }

        m_channelIndicator.text = indicatorText;

        if (newChannel != _currenChannel)
        {
            Channels[_currenChannel].SetActive(false);
            _currenChannel = newChannel;
            Channels[_currenChannel].SetActive(true);
        }
        audio.clip = m_changeChannelAudio;
        audio.Play();
        GetComponent<Inventory>().ChangeChannel(_currenChannel);

    }
}
