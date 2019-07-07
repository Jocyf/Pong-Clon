using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPlayingPong : MonoBehaviour {

    private Text buttonText;

    void Start()
    {
        buttonText = GetComponent<Text>();
        buttonText.text = "PLAY";
    }

    public void ChangePlayingMode ()
    {
        if (PongManager.Instance.isPlaying)
        {
            buttonText.text = "PLAY";
            PongManager.Instance.ExitGame();
        }
        else
        {
            buttonText.text = "STOP";
            PongManager.Instance.StartGame();
        }
	}

}
