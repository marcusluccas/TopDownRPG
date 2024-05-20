using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject door;

    public List<GameObject> spawnPoints;

    public List<GameObject> enemies;

    public int enemiesAlive;
    bool dungeonActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDungeonEnd();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpawnEnemy();
            door.SetActive(true);
            dungeonActive = true;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void SpawnEnemy()
    {
        foreach (GameObject point in spawnPoints)
        {
            int randomEnemy = Random.Range(0, 2);

            GameObject newEnemy = Instantiate(enemies[randomEnemy], point.transform.position, Quaternion.identity);
            newEnemy.GetComponent<EntityStats>().spawnManager = this;
            enemiesAlive++;
        }
    }

    void CheckDungeonEnd()
    {
        if (dungeonActive == true)
        {
            if (enemiesAlive <= 0)
            {
                door.SetActive(false);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                dungeonActive = false;
            }
        }
    }
}
