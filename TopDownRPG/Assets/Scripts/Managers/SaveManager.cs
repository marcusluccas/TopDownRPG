using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    GameObject player;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveGame()
    {
        if (player != null)
        {
            //Player Position
            PlayerPrefs.SetFloat("posX", player.transform.position.x);
            PlayerPrefs.SetFloat("posY", player.transform.position.y);
            PlayerPrefs.SetFloat("camPosX", Camera.main.transform.position.x);
            PlayerPrefs.SetFloat("camPosY", Camera.main.transform.position.y);

            //Player stats
            PlayerPrefs.SetInt("level", player.GetComponent<EntityStats>().level);
            PlayerPrefs.SetFloat("maxHp", player.GetComponent<EntityStats>().maxHp);
            PlayerPrefs.SetFloat("moveSpeed", player.GetComponent<EntityStats>().baseSpeed);
            PlayerPrefs.SetFloat("bonusAtkDemage", player.GetComponent<EntityStats>().bonusAttackDemage);
            PlayerPrefs.SetFloat("bonusAtkSpeed", player.GetComponent<EntityStats>().bonusAttackSpeed);
            PlayerPrefs.SetInt("exp", player.GetComponent<EntityStats>().exp);
            PlayerPrefs.SetInt("goldCoins", InventoryManager.Instance.goldCoins);

            //Options
            PlayerPrefs.SetFloat("volume", OptionsManager.instance.sliderVolume.value);
        }
    }

    void LoadGame()
    {
        //Player position
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("posX", player.transform.position.x), PlayerPrefs.GetFloat("posY", player.transform.position.y), 0f);
        Camera.main.transform.position = new Vector3(PlayerPrefs.GetFloat("camPosX", player.transform.position.x), PlayerPrefs.GetFloat("camPosY", player.transform.position.y), -10f);

        //Player stats
        player.GetComponent<EntityStats>().level = PlayerPrefs.GetInt("level");
        player.GetComponent<EntityStats>().maxHp = PlayerPrefs.GetFloat("maxHp");
        player.GetComponent<EntityStats>().baseSpeed = PlayerPrefs.GetFloat("moveSpeed");
        player.GetComponent<EntityStats>().bonusAttackDemage = PlayerPrefs.GetFloat("bonusAtkDemage");
        player.GetComponent<EntityStats>().bonusAttackSpeed = PlayerPrefs.GetFloat("bonusAtkSpeed");
        player.GetComponent<EntityStats>().exp = PlayerPrefs.GetInt("exp");
        InventoryManager.Instance.goldCoins = PlayerPrefs.GetInt("goldCoins");

        //Options
        OptionsManager.instance.sliderVolume.value = PlayerPrefs.GetFloat("volume");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
