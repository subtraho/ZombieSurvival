using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    public float howClose;
    public float enemyDamage;
    public float enemyAttackTime;

    private Transform playerPosition;
    private float distance;
    private float oldHowClose;
    private float enemyAttack;
    private Animator animator;
    private float soundDistance;

    private void Start()
    {
        playerPosition = player.transform;
        oldHowClose = howClose;
        enemyAttack = (Time.time + enemyAttackTime);
        animator = gameObject.GetComponent<Animator>();
        soundDistance = 8f;
    }

    private void Update()
    {
        distance = Vector3.Distance(playerPosition.position, transform.position);

        Checkdistance();
        CheckSoundDistance();
    }

    private void Checkdistance()
    {
        if (distance <= howClose)
        {
            transform.LookAt(playerPosition);
            Vector3 pos = Vector3.MoveTowards(transform.position, playerPosition.position, moveSpeed * Time.fixedDeltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
            howClose = 12;
            animator.SetBool("SeesPlayer", true);
        }
        else
        {
            howClose = oldHowClose;
            animator.SetBool("SeesPlayer", false);
        }

        if (distance <= 0.5f)
        {
            if(Time.time >= enemyAttack)
            {
                player.GetComponent<PlayerStats>().health -= enemyDamage;
                enemyAttack = Time.time + enemyAttackTime;
            }
        }
    }

    private void CheckSoundDistance()
    {
        if(gameObject.GetComponent<ZombieSounds>() != null)
        {
            if (distance <= soundDistance)
            {
                gameObject.GetComponent<ZombieSounds>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<ZombieSounds>().enabled = false;
            }
        }  
    }
}
