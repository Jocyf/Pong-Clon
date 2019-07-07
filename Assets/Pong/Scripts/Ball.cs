using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 10;

    public AudioClip wallHitFX;
    public AudioClip racketHitFX;
    public AudioClip FailFX;

    private Rigidbody2D myRigidbody;
    private AudioSource MyAS;

    public void LaunchBallFirstTime()
    {
        myRigidbody.velocity = Vector2.right * speed;
    }

    void Start()
    {
        MyAS = GetComponent<AudioSource>();
        myRigidbody = GetComponent<Rigidbody2D>();
        LaunchBallFirstTime();
    }

    // Si la bola detecta una colision con la raqueta...
    void OnCollisionEnter2D(Collision2D col)
    {

        MakeHitSound(col.gameObject.name);  // sonido del golpe de la pelota contra la raqueta

        if (!col.gameObject.name.Contains("Racket")) { return; }

        // Calculate hit Factor
        float y = GetHitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = col.gameObject.name.Contains("Left") ? new Vector2(1, y).normalized : new Vector2(-1, y).normalized;

        // Set Velocity with dir * speed
        myRigidbody.velocity = dir * speed;
    }

    private float GetHitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        // ascii art 
        // Dibujito perfecto para explicar como calcular la direccion de la pelota dependiendo de si golpea en el centro de la raqueta o en las esquinas):
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private void MakeHitSound(string _name)
    {
        if (_name.Contains("Racket"))
        {
            MyAS.PlayOneShot(racketHitFX);
        }
        else if (_name.Contains("Wall"))
        {
            MyAS.PlayOneShot(wallHitFX);
        }
    }

    public void PlayFailSoundFX()
    {
        MyAS.PlayOneShot(FailFX);
    }
}
