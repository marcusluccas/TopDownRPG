using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDemage : MonoBehaviour
{
    public float demage;
    public float life = 1;
    public bool isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((isPlayer == true && collision.gameObject.tag == "Enemy") || (isPlayer == false && collision.gameObject.tag == "Player"))
        {
            collision.gameObject.GetComponent<EntityStats>().RemoveHP(demage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}