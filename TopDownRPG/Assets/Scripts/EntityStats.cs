using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public float maxHp;
    public float hp;
    public float baseSpeed;
    public float atackDemage;
    public float atackSpeed;
    public float atackRange;
    public int goldCarry;

    private void Start()
    {

    }

    private void Update()
    {
        Death();
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
}
