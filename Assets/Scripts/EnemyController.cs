﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;

    public Animator enemyanimator;


    [SerializeField] private int enemyDamage;
    public HealthController healthcontroller;
    public PlayerController playerController;
    
    void Update()
    {
        patrolEnemy();
    }

    private void patrolEnemy()
    {
        //Animator enemyanimator1 = enemyanimator;
        enemyanimator.SetBool("IsPatrol", true);        
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);    //origin, direction, distance

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playercontroller = collision.gameObject.GetComponent<PlayerController>();
            Damage();            
        }
    }

    void Damage()
    {
        healthcontroller.playerHealth = healthcontroller.playerHealth - enemyDamage;
        if(healthcontroller.playerHealth > 0)
        {
            healthcontroller.UpdateHealth();
        }
        else
        {
            healthcontroller.UpdateHealth();
            playerController.killPlayer();
        }
        
    }
}
