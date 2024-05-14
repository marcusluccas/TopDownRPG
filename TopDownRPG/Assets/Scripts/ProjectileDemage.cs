using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDemage : MonoBehaviour
{
    public float demage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().hp -= demage;
            Destroy(this.gameObject);
        }
    }
}