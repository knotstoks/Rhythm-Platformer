using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" && Input.GetKey(KeyCode.F))
        {
            MovingPlatform script = platform.GetComponent<MovingPlatform>();
            script.moving = true;
        }
    }
}
