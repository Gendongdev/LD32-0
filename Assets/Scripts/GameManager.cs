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
        Channels[_currenChannel].SetActive(false);

        if (InputDial.Selector == 0)
            _currenChannel = ChannelDial.Selector + 1;
        else
            _currenChannel = 0;

        Channels[_currenChannel].SetActive(true);
        GetComponent<Inventory>().ChangeChannel(_currenChannel);

    }
}
