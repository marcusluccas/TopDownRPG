using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    float speed;
    EntityStats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<EntityStats>();
        player = GameObject.FindGameObjectWithTag("Player");
        speed = stats.baseSpeed;
        stats.hp = stats.maxHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<EntityStats>().RemoveHP(stats.attackDemage);
            stats.RemoveHP(stats.maxHp);
        }
    }
}