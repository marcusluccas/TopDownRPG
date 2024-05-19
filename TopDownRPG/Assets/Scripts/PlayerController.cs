using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityStats
{
    Rigidbody2D myRB;
    public GameObject myProjectile;
    float timer;
    bool canAttack;
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        hp = maxHp;
        timer = attackSpeed;
        myAnimator = GetComponent<Animator>();
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

        myRB.velocity = move * baseSpeed;

        if (myRB.velocity != Vector2.zero)
        {
            if (horizontal < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (horizontal > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

            myAnimator.Play("Move");
        }
        else
        {
            myAnimator.Play("Idle");
        }
    }

    void Shot()
    {
        if (Input.GetMouseButton(0) && canAttack)
        {
            GameObject projectile = Instantiate(myProjectile, transform.position, Quaternion.identity);
            Vector2 directionProjectile = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            directionProjectile.Normalize();

            projectile.GetComponent<Rigidbody2D>().AddForce(directionProjectile * attackRange, ForceMode2D.Impulse);
            projectile.GetComponent<ProjectileDemage>().demage = attackDemage * ((bonusAttackDemage + 100)/100);
            projectile.GetComponent<ProjectileDemage>().life = attackLife;

            canAttack = false;
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

        if (timer > (attackSpeed - bonusAttackSpeed / 100) && !canAttack)
        {
            canAttack = true;
        }
    }
}
