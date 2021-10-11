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

    private void Start()
    {
        playerPosition = player.transform;
        oldHowClose = howClose;
        enemyAttack = (Time.time + enemyAttackTime);
    }

    private void Update()
    {
        distance = Vector3.Distance(playerPosition.position, transform.position);

        Checkdistance();
    }

    private void Checkdistance()
    {
        if (distance <= howClose)
        {
            transform.LookAt(playerPosition);
            Vector3 pos = Vector3.MoveTowards(transform.position, playerPosition.position, moveSpeed * Time.fixedDeltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
            howClose = 12;
        }
        else
        {
            howClose = oldHowClose;
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
}
