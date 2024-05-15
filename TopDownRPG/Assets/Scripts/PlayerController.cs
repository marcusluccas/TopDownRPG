using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityStats
{
    float speed;
    Rigidbody2D myRB;
    public GameObject myProjectile;
    float timer;
    bool canAtack;

    // Start is called before the first frame update
    void Start()
    {
        speed = baseSpeed;
        myRB = GetComponent<Rigidbody2D>();
        speed = baseSpeed;
        hp = maxHp;
        timer = atackSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Shot();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        move.Normalize();

        myRB.velocity = move * speed;
    }

    void Shot()
    {
        if (Input.GetMouseButton(0) && canAtack)
        {
            GameObject projectile = Instantiate(myProjectile, transform.position, Quaternion.identity);
            Vector2 directionProjectile = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            directionProjectile.Normalize();

            projectile.GetComponent<Rigidbody2D>().AddForce(directionProjectile * atackRange, ForceMode2D.Impulse);
            projectile.GetComponent<ProjectileDemage>().demage = atackDemage;

            canAtack = false;
            timer = 0;
        }

        Cooldown();

        if (Input.GetKeyDown(KeyCode.G))
        {
            InventoryManager.Instance.DiscardItem();
        }
    }

    void Cooldown()
    {
        timer += Time.deltaTime;

        if (timer > atackSpeed && !canAtack)
        {
            canAtack = true;
        }
    }
}
