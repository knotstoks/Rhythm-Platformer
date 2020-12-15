using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform prevPosition,prevPlatform;
    public Transform position1, position2;
    public bool movingToLeft;
    public bool moving;
    public float speed;
    public GameObject Key;
    Vector3 nextPosition;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (movingToLeft)
        {
            nextPosition = position1.position;
        }
        else
        {
            nextPosition = position2.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            sprite.color = new Color(1, 1, 1, 1);
            if (transform.position == position1.position)
            {
                nextPosition = position2.position;
            }

            if (transform.position == position2.position)
            {
                nextPosition = position1.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
        } 
        else
        {
            sprite.color = new Color(1, 0, 0, 1);
        }

        if (Key == null)
        {
            moving = true;
        }
        
    }
}
