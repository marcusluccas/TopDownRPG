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
            }

            Destroy(this.gameObject);
        }
    }

    public void RemoveHP(float demage)
    {
        hp -= demage;
        Death();
    }
}
