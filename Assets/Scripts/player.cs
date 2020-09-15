﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpSpeed;
    public float timer;
    public Vector3 startingPosition;
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -speed;
        }
        else
        {
            velocity.x = 0;
        }
        

        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }
        else
        {
            counter = timer;
            velocity.y = jumpSpeed;
        }
        rb.velocity = velocity;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Boundary")
        {
            
            transform.position = startingPosition;
        }
        if(collider.gameObject.tag == "Checkpoint")
        {
            startingPosition = collider.transform.position;
        }
        if(collider.gameObject.tag == "MovingPlatform")
        {
            transform.parent = collider.gameObject.transform;
        }
        if(collider.gameObject.tag == "Bullet")
        {
            print("collided with bullet");
            transform.position = startingPosition;
            Destroy(collider.gameObject);

        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
