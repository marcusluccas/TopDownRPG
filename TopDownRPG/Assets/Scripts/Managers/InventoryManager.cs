using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    public GameObject InvBackground;
    public GameObject InvSlot;

    public List<Weapon> Inventory;

    EntityStats playerStats;

    int selectSlot = 0;

    //Gold Manager

    public int goldCoins;
    public Text goldText;

    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
        }
        else {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();

        SelectWeapon(1);
    }

    // Update is called once per frame
    void Update()
    {
        SelectHotKey();
    }

    void Refresh()
    {
        goldText.text = goldCoins.ToString();

        GameObject[] slots = GameObject.FindGameObjectsWithTag("Slot");

        foreach (GameObject slot in slots)
        {
            Destroy(slot);
        }

        int hotKey = 1;

        foreach (Weapon w in Inventory) {
            GameObject slot = Instantiate(InvSlot, InvBackground.transform);
            Image[] slotIcons = slot.GetComponentsInChildren<Image>();

            if (w == null)
            {
                slotIcons[1].GetComponent<Image>().enabled = false;
            }
            else
            {
                slot.GetComponentInChildren<Image>().enabled = true;
                slotIcons[1].GetComponent<Image>().sprite = w.weaponIcon;
                slotIcons[0].GetComponent<Image>().color = Color.white;

                if (selectSlot == hotKey) slotIcons[0].GetComponent<Image>().color = Color.yellow;
            }

            slot.GetComponentInChildren<Text>().text = hotKey.ToString();
            hotKey++;
        }
    }

    void SelectWeapon(int hotKey)
    {
        Weapon selectWeapon = Inventory[hotKey - 1];
        if (selectWeapon != null)
        {
            playerStats.attackDemage = selectWeapon.weaponDemage;
            playerStats.attackSpeed = selectWeapon.weaponSpeed;
            playerStats.attackRange = selectWeapon.weaponRange;
            playerStats.attackLife = selectWeapon.weaponLife;
            playerStats.gameObject.GetComponent<PlayerController>().myProjectile = selectWeapon.weaponProject;
            playerStats.gameObject.GetComponent<PlayerController>().weaponSound = selectWeapon.weaponSound;
            playerStats.gameObject.GetComponent<PlayerController>().weaponPitch = selectWeapon.weaponSoundPitch;
        }

        selectSlot = hotKey;
        Refresh();
    }

    void SelectHotKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectWeapon(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectWeapon(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectWeapon(5);
        }

    }

    public void AddGold(int gold)
    {
        goldCoins += gold;
        Refresh();
    }

    public void DiscardItem()
    {
        if (selectSlot -1 != 0)
        {
            Inventory[selectSlot -1] = null;
            SelectWeapon(1);
            Refresh();
        }
    }
}
