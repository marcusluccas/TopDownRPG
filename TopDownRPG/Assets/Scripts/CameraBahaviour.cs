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
        if (targetObject != null)
        {
            targetTransform = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, -10);

            targetTransform.x = Mathf.Clamp(targetTransform.x, boundaries[0].position.x, boundaries[1].position.x);
            targetTransform.y = Mathf.Clamp(targetTransform.y, boundaries[2].position.y, boundaries[3].position.y);

            this.transform.position = Vector3.Lerp(this.transform.position, targetTransform, 2f * Time.fixedDeltaTime);
        }
    }
}
