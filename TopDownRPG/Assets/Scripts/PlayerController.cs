using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRB;
    EntityStats stats;
    public GameObject myProjectile;
    float timer;
    bool canAttack;
    Animator myAnimator;
    public AudioSource footstepSound;
    public AudioSource weaponAudio;
    public AudioClip weaponSound;
    public float weaponPitch;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<EntityStats>();
        myRB = GetComponent<Rigidbody2D>();
        stats.hp = stats.maxHp;
        timer = stats.attackSpeed;
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

        myRB.velocity = move * stats.baseSpeed;

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
            footstepSound.volume = 1 * OptionsManager.instance.sliderVolume.value;
        }
        else
        {
            myAnimator.Play("Idle");
            footstepSound.volume = 0;
        }
    }

    void Shot()
    {
        if (Input.GetMouseButton(0) && canAttack)
        {
            GameObject projectile = Instantiate(myProjectile, transform.position, Quaternion.identity);
            Vector2 directionProjectile = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            directionProjectile.Normalize();

            float degZ = Mathf.Atan2(directionProjectile.y, directionProjectile.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.Euler(0f, 0f, degZ - 90);
            projectile.GetComponent<Rigidbody2D>().AddForce(directionProjectile * stats.attackRange, ForceMode2D.Impulse);
            projectile.GetComponent<ProjectileDemage>().demage = stats.attackDemage * ((stats.bonusAttackDemage + 100)/100);
            projectile.GetComponent<ProjectileDemage>().life = stats.attackLife;

            weaponAudio.PlayOneShot(weaponSound);
            weaponAudio.pitch = weaponPitch;

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

        if (timer > (stats.attackSpeed - stats.bonusAttackSpeed / 100) && !canAttack)
        {
            canAttack = true;
        }
    }
}
