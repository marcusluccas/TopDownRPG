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
            Destroy(this.gameObject);
        }
    }
}
