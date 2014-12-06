using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject[] Channels;
    public Dial ChannelDial;
    public Dial InputDial;

    private int _currenChannel = 1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateDials()
    {
        Channels[_currenChannel].SetActive(false);

        if (InputDial.Selector == 0)
            _currenChannel = ChannelDial.Selector + 1;
        else
            _currenChannel = 0;

        Channels[_currenChannel].SetActive(true);

    }
}
