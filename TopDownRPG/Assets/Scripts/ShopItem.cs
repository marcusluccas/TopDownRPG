using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Text itemNameHolder;
    public Text itemValueHolder;
    public Image itemIconHolder;
    public Text itemInfoHolder;

    public Weapon weapon;

    public Button itemButton;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryManager.Instance.goldCoins < weapon.weaponValue)
        {
            itemButton.interactable = false;
        }
        else
        {
            itemButton.interactable = true;
        }
    }

    public void Setup(Weapon weapon)
    {
        itemNameHolder.text = weapon.weaponName;
        itemValueHolder.text = weapon.weaponValue.ToString();
        itemIconHolder.sprite = weapon.weaponIcon;
        itemInfoHolder.text = "Attack Demage: " + weapon.weaponDemage + "\n"
        + "Attack Speed: " + weapon.weaponSpeed + "\n" + "Range: " + weapon.weaponRange;
    }

    public void BuyWeapon()
    {
        if (InventoryManager.Instance.Inventory[InventoryManager.Instance.Inventory.Count -1] == null)
        {
            for (int i = 0; i < InventoryManager.Instance.Inventory.Count; i++)
            {
                if (InventoryManager.Instance.Inventory[i] == null)
                {
                    InventoryManager.Instance.Inventory[i] = weapon;
                    break;
                }
            }

            InventoryManager.Instance.AddGold(weapon.weaponValue * -1);
            RefreshShop();
            Destroy(this.gameObject);
        }
    }

    void RefreshShop()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("ShopItem");
        foreach (GameObject i in items)
        {
            i.GetComponent<ShopItem>().Setup(i.GetComponent<ShopItem>().weapon);
        }
    }
}
