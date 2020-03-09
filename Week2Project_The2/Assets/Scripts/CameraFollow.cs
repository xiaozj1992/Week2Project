using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform pTransform;

    // Start is called before the first frame update
    void Start()
    {
        pTransform = GameObject.FindWithTag("Player").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= new Vector3(pTransform.position.x, pTransform.position.y, transform.position.z);
    }
}
