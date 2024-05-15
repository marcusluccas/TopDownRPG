using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedController : EntityStats
{
    public GameObject myProjectile;
    bool canAttack;
    float timer;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        timer = attackSpeed;
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

            projectile.GetComponent<Rigidbody2D>().AddForce(directionProjectile * attackRange, ForceMode2D.Impulse);
            projectile.GetComponent<ProjectileDemage>().demage = attackDemage;
            projectile.GetComponent<ProjectileDemage>().life = attackLife;

            canAttack = false;
            timer = 0;
        }

        Cooldown();
    }

    void Cooldown()
    {
        timer += Time.deltaTime;

        if (timer > attackSpeed && !canAttack)
        {
            canAttack = true;
        }
    }
}
