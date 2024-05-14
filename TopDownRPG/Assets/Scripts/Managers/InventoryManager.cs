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

    void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(Instance);
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
        GameObject[] slots = GameObject.FindGameObjectsWithTag("Slot");

        foreach (GameObject slot in slots)
        {
            Destroy(slot);
        }

        int hotKey = 1;

        foreach (Weapon w in Inventory) {
            GameObject slot = Instantiate(InvSlot, InvBackground.transform);
            slot.GetComponentInChildren<Image>().sprite = w.weaponIcon;
            slot.GetComponentInChildren<Outline>().enabled = false;

            if (selectSlot == hotKey) slot.GetComponentInChildren<Outline>().enabled = true;

            slot.GetComponentInChildren<Text>().text = hotKey.ToString();
            hotKey++;
        }
    }

    void SelectWeapon(int hotKey)
    {
        Weapon selectWeapon = Inventory[hotKey - 1];
        playerStats.atackDemage = selectWeapon.weaponDemage;
        playerStats.atackSpeed = selectWeapon.weaponSpeed;
        playerStats.atackRange = selectWeapon.weaponRange;

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
}
