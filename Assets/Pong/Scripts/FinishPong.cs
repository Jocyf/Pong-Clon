using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPong : MonoBehaviour {

    // Finaliza la paretida detectando la tecla Escape. Solo funciona en PC (no en movil).
	public void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && PongManager.Instance.isPlaying)
            PongManager.Instance.ExitGame();
	}

}
