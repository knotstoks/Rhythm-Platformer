using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float TimeBtnShots;
    private float MaxTimeBtnShots;
    public GameObject Projectile;
    public Transform BulletTarget;
    // Start is called before the first frame update
    void Start()
    {
        MaxTimeBtnShots = TimeBtnShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(MaxTimeBtnShots <= 0)
        {
            GameObject thing = Instantiate(Projectile,transform.position,Quaternion.identity) as GameObject;
            Bullet script = thing.GetComponent<Bullet>();
            script.target = BulletTarget;
            script.cannon = gameObject.transform;
            MaxTimeBtnShots = TimeBtnShots;
        }
        else
        {
            MaxTimeBtnShots -= Time.deltaTime; 
        }
    }
}
