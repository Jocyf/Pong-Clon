using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour {

    public float speed = 30;
    public bool useMobileInput = true;
    public float sensivity = 0.5f;

    private Transform myTransform;


    private void Start()
    {
        myTransform = transform;
    }

    void FixedUpdate()
    {
        float v = 0;
        
        if (useMobileInput)
        {
            v = Input.GetAxis("Mouse Y") * sensivity;
            if (v > 1)
                v = 1;
            else if (v < -1)
                v = -1;

            //Debug.Log("v: " + v.ToString() + " - Mouse Y: " + Input.GetAxis("Mouse Y").ToString());
        }
        else
        {
            v = Input.GetAxis("Vertical");
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}
