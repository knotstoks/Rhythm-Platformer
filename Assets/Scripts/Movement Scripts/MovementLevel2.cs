using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementLevel2 : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpSpeed;
    public float highJumpSpeed;
    public float highJumpTime;
    public float timer;
    public int jumped;
    public Vector3 startingPosition;
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        counter = timer;
        jumped = 1;
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;
        Vector3 characterScale = transform.localScale;
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
        
        if (Input.GetKey(KeyCode.D))
        {
            characterScale.x = 1;
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            characterScale.x = -1;
        }
        transform.localScale = characterScale;

        if (counter <= 0)
        {
            counter += timer;
            velocity.y = jumpSpeed;
            jumped = 1;
        }
        else if (counter < highJumpTime && jumped == 1)
        {
            velocity.y = highJumpSpeed;
            jumped = 0;
        }
        else if (counter > 0)
        {
            counter -= Time.deltaTime;
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
        if (collider.gameObject.tag == "Bullet")
        {
            transform.position = startingPosition;
            Destroy(collider.gameObject);
        }
        if (collider.CompareTag("Key"))
        {
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.tag == "Door") {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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