﻿using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    [SerializeField]
    float bulletSpeed = 30f;

    [SerializeField]
    float bulletLifeTime = 2f;

    float timePassedSinceBorn = 0f;
	
	// Update is called once per frame
	void Update () {
        Movement();
        Death();
	}

    void Movement()
    {
        transform.position += transform.up * Time.deltaTime * bulletSpeed;
    }

    void Death()
    {
        timePassedSinceBorn += Time.deltaTime;

        if(timePassedSinceBorn >= bulletLifeTime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
