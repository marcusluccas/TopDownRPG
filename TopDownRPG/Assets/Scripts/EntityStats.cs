using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityStats : MonoBehaviour
{
    public float maxHp;
    public float hp;
    public float baseSpeed;
    public float attackDemage;
    public float attackSpeed;
    public float attackRange;
    public float attackLife;
    public int goldCarry;

    //Apenas os enemies
    public SpawnManager spawnManager;

    //Apenas o player
    public int level = 1;
    public float bonusAttackDemage;
    public float bonusAttackSpeed;

    public int exp = 0;

    public GameObject deathParticle;

    AudioSource hitSound;

    void Start()
    {
        hitSound = GameObject.Find("Hit Sound").GetComponent<AudioSource>();
    }

    void Update()
    {
        DemageBlink();
    }

    void Death()
    {
        if (hp <= 0)
        {
            hitSound.volume = 1;

            if (this.gameObject.tag != "Player")
            {
                InventoryManager.Instance.AddGold(goldCarry);
                GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>().AddExp(exp);
            }

            if (this.gameObject.tag == "Enemy")
            {
                spawnManager.enemiesAlive--;
            }

            Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

    public void RemoveHP(float demage)
    {
        GameObject newPopup = Instantiate(HUD.Instance.demagePopup, this.gameObject.transform.position, Quaternion.identity);
        newPopup.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-2f, 2f), 5), ForceMode2D.Impulse);
        newPopup.GetComponentInChildren<Text>().text = Mathf.RoundToInt(demage * 10).ToString();
        Destroy(newPopup, 1);

        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        hitSound.volume = 0.4f;

        hp -= demage;
        Death();

        hitSound.Play();
    }

    public void AddExp(int e)
    {
        exp += e;

        if (exp >= level * 100)
        {
            HUD.Instance.SetupLevelUpScreen();
            level++;
            exp = 0;
        }
    }

    void DemageBlink()
    {
        if (gameObject.GetComponent<SpriteRenderer>().color != Color.white)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(gameObject.GetComponent<SpriteRenderer>().color, Color.white, 10 * Time.deltaTime);
        }
    }
}
