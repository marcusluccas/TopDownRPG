using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance { get; private set; }

    public Slider myHpBar;
    public Slider myExpBar;
    EntityStats player;

    public GameObject levelUpScreen;
    public Text[] levelUpScreenValues;

    public GameObject demagePopup;

    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHUD();
    }

    void PlayerHUD()
    {
        myHpBar.maxValue = player.maxHp;
        myHpBar.value = player.hp;
        myExpBar.maxValue = player.level * 100;
        myExpBar.value = player.exp;
    }

    public void SelectStat(string stat)
    {
        if (stat == "hp")
        {
            player.maxHp += 5;
            player.hp += 5;
        }

        if (stat == "demage")
        {
            player.bonusAttackDemage++;
        }

        if (stat == "atk speed")
        {
            player.bonusAttackSpeed += 2.5f;
        }

        if (stat == "move speed")
        {
            player.baseSpeed += 2;
        }

        levelUpScreen.SetActive(false);
    }

    public void SetupLevelUpScreen()
    {
        levelUpScreen.SetActive(true);

        levelUpScreenValues[0].text = player.maxHp.ToString();
        levelUpScreenValues[1].text = (player.attackDemage * ((player.bonusAttackDemage + 100)/100)).ToString();
        levelUpScreenValues[2].text = (player.attackSpeed - player.bonusAttackSpeed / 100).ToString();
        levelUpScreenValues[3].text = player.baseSpeed.ToString();
    }
}
