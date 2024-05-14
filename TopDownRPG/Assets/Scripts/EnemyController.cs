using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EntityStats
{
    GameObject player;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = baseSpeed;
        hp = maxHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().hp -= atackDemage;
            hp -= maxHp;
        }
    }
}