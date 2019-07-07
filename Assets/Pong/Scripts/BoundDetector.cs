using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundDetector : MonoBehaviour {

    public Transform enemy;
    public AudioClip FailFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Ball"))
        {
            if (other.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                PongManager.Instance.IncreaseEnemyScore();
            }
            else
            {
                PongManager.Instance.IncreasePlayerScore();
            }

            other.gameObject.SendMessage("PlayFailSoundFX");

            //sets enemy's position back to original
            // enemy.position = new Vector3(-6.6f, 0, 0); // esto de volver a poner el enemigo en su posicion inicial es una opcion... pero de momento lo dejo comentado.

            PongManager.Instance.ResetBall();
        }
    }

    IEnumerator LaunchBallAgain(Transform _ball)
    {
        yield return new WaitForSeconds(1.0f);
        _ball.SendMessage("LaunchBallFirstTime");

    }
}
