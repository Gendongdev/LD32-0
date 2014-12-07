using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject[] Channels;
    public Dial ChannelDial;
    public Dial InputDial;

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
	}

    public void UpdateDials()
    {

        int newChannel = 0;
        Channels[_currenChannel].SetActive(false);

        if (InputDial.Selector == 0)
            newChannel = ChannelDial.Selector + 1;
        else
            newChannel = 0;

        if (newChannel != _currenChannel)
        {
            Channels[_currenChannel].SetActive(false);
            _currenChannel = newChannel;
            Channels[_currenChannel].SetActive(true);
        }

        GetComponent<Inventory>().ChangeChannel(_currenChannel);

    }
}
