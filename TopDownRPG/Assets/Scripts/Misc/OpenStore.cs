using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenStore : MonoBehaviour
{
    public GameObject storeObject;
    public GameObject storeWarning;
    GameObject playerObject;

    public List<Weapon> itemSold;

    public GameObject storeBG;
    public GameObject storeItem;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

        RandomItems();
        storeObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject != null)
        {
            float distance = Vector2.Distance(transform.position, playerObject.transform.position);

            if (distance < 2)
            {
                storeWarning.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    storeObject.SetActive(true);
                }
            }
            else
            {
                storeWarning.SetActive(false);
                storeObject.SetActive(false);
            }
        }
    }

    void RandomItems()
    {
        for (int i = 0; i < 3; i++) {

            int itemChance = Random.Range(0, itemSold.Count);

            GameObject newItem = Instantiate(storeItem, storeBG.transform);
            newItem.GetComponent<ShopItem>().weapon = itemSold[itemChance];
            newItem.GetComponent<ShopItem>().Setup(itemSold[itemChance]);
        }
    }
}
