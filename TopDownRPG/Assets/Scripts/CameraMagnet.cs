using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMagnet : MonoBehaviour
{
    public GameObject magnetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Camera.main.GetComponent<CameraBahaviour>().targetObject == collision.gameObject)
            {
                Camera.main.GetComponent<CameraBahaviour>().targetObject = magnetPosition;
            }
            else
            {
                Camera.main.GetComponent<CameraBahaviour>().targetObject = collision.gameObject;
            }
        }
    }
}
