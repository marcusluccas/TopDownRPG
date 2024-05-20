using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedController : MonoBehaviour
{
    public GameObject myProjectile;
    bool canAttack;
    float timer;
    EntityStats stats;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<EntityStats>();
        stats.hp = stats.maxHp;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Shot();   
    }

    void Shot()
    {
        if (canAttack)
        {
            GameObject projectile = Instantiate(myProjectile, transform.position, Quaternion.identity);
            Vector2 directionProjectile = player.transform.position - transform.position;
            directionProjectile.Normalize();

            projectile.GetComponent<Rigidbody2D>().AddForce(directionProjectile * stats.attackRange, ForceMode2D.Impulse);
            projectile.GetComponent<ProjectileDemage>().demage = stats.attackDemage;
            projectile.GetComponent<ProjectileDemage>().life = stats.attackLife;

            canAttack = false;
            timer = 0;
        }

        Cooldown();
    }

    void Cooldown()
    {
        timer += Time.deltaTime;

        if (timer > stats.attackSpeed && !canAttack)
        {
            canAttack = true;
        }
    }
}
