using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBahaviour : MonoBehaviour
{
    public GameObject targetObject;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetObject = player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, this.transform.position.z), 2f * Time.fixedDeltaTime);
    }
}
