using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    bool isChasing=false;
    float speed = 1f;
    float smooth = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //发现
        if (collision.tag == "Player")
        {
            isChasing = true;
            //Debug.Log("发现目标");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isChasing = true;
            transform.position = Vector3.MoveTowards(transform.position, collision.gameObject.transform.position, Time.deltaTime * speed);
            //转向
            transform.up = Vector3.Lerp(transform.up, collision.gameObject.transform.position - transform.position, smooth * Time.deltaTime);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //逃离
        if (collision.tag == "Player")
        {
            isChasing = false;
            //Debug.Log("目标逃脱");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
