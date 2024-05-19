using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBahaviour : MonoBehaviour
{
    public GameObject targetObject;
    Vector3 targetTransform;

    GameObject player;

    public List<Transform> boundaries;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetObject = player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((player.transform.position.x < boundaries[0].position.x || player.transform.position.x > boundaries[1].position.x) && (player.transform.position.y < boundaries[2].position.y || player.transform.position.y > boundaries[3].position.y))
        {
            targetTransform = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        }
        else if (player.transform.position.x < boundaries[0].position.x || player.transform.position.x > boundaries[1].position.x)
        {
            targetTransform = new Vector3(gameObject.transform.position.x, targetObject.transform.position.y, -10f);
        }
        else if (player.transform.position.y < boundaries[2].position.y || player.transform.position.y > boundaries[3].position.y)
        {
            targetTransform = new Vector3(targetObject.transform.position.x, gameObject.transform.position.y, -10f);
        }
        else
        {
            targetTransform = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, -10);
        }

        this.transform.position = Vector3.Lerp(this.transform.position, targetTransform, 2f * Time.fixedDeltaTime);
    }
}
