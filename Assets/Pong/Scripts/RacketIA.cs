using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketIA : MonoBehaviour {
    public bool isLeftRacket = true;
    public float speed = 10;
    public float topBound = 3.2f;
    public float bottomBound = -3.2f;

    private Rigidbody2D myRigidbody;
    private Transform ball;

    void Start()
    {
        ball = GameObject.Find("Ball").transform;

        if (ball != null)
        {
            myRigidbody = ball.GetComponent<Rigidbody2D>(); // Get the Rigidbody
        }
    }

    void Update()
    {
        //checking x direction of the ball
        if ((myRigidbody.velocity.x < 0 && isLeftRacket) || (myRigidbody.velocity.x > 0 && !isLeftRacket))
        {
            //checking y direction of ball
            if (ball.position.y < this.transform.position.y - 0.5f)
            {
                //move ball down if lower than paddle
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else if (ball.position.y > this.transform.position.y + 0.5f)
            {
                //move ball up if higher than paddle
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }

        // Security reachung the top/botton of the screen.
        if (transform.position.y > topBound)
        {
            transform.position = new Vector3(transform.position.x, topBound, 0);
        }
        else if (transform.position.y < bottomBound)
        {
            transform.position = new Vector3(transform.position.x, bottomBound, 0);
        }
    }
}
