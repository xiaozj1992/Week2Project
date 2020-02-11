using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwirlController : MonoBehaviour
{
    float forceRate=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>()?.AddForce((transform.position-collision.transform.position)*forceRate/ (transform.position - collision.transform.position).magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
