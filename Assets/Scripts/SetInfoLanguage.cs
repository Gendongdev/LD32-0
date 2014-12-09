using UnityEngine;
using System.Collections;

public class SetInfoLanguage : MonoBehaviour {

    public string m_Spanish;
    public string m_English;

	// Use this for initialization
	void Start () {

        if (Application.systemLanguage == SystemLanguage.Spanish)
            GetComponent<UnityEngine.UI.Text>().text = m_Spanish;
        else
            GetComponent<UnityEngine.UI.Text>().text = m_English;
	}
	
}
