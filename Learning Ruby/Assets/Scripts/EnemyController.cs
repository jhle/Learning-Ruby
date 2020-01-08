﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public float speed = 3.0f;

    public bool vertical;
    public float changeTime = 3.0f;
    public bool broken = true;
    Rigidbody2D rigidbody2D;
    public ParticleSystem smokeEffect;

    float timer;

    int direction = 1;
    Animator animator;
    //public AudioClip hitEnemy;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
            {
                return;
            }
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        Vector2 position = GetComponent<Rigidbody2D>().position;
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);

        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);

      
        }

        GetComponent<Rigidbody2D>().MovePosition(position);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            //player.PlaySound(hitEnemy);
            player.ChangeHealth(-1);
        }
    }
    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");
        smokeEffect.Stop();
    }
}
