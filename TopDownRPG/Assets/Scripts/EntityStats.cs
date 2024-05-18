using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    void Death()
    {
        if (hp <= 0)
        {
            if (this.gameObject.tag != "Player")
            {
                InventoryManager.Instance.AddGold(goldCarry);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().AddExp(exp);
            }

            if (this.gameObject.tag == "Enemy")
            {
                spawnManager.enemiesAlive--;
            }

            Destroy(this.gameObject);
        }
    }

    public void RemoveHP(float demage)
    {
        hp -= demage;
        Death();
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
}
