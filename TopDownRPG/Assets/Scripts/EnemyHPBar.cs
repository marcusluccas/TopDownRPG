using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    Slider hpBar;
    EntityStats entityStats;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = this.gameObject.GetComponentInChildren<Slider>();
        entityStats = this.gameObject.GetComponentInParent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.maxValue = entityStats.maxHp;
        hpBar.value = entityStats.hp;
    }
}
