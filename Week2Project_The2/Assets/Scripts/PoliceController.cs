using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    public Transform path;
    List<Transform> pathPoint;
    Rigidbody2D rb;
    int desIndex = 0;//路径序号
    float speed = 3f;//移动速度
    float smooth = .5f;//转向速度
    // Start is called before the first frame update
    void Start()
    {
        pathPoint = new List<Transform>();
        rb = GetComponent<Rigidbody2D>();
        foreach (Transform p in path)
        {
            pathPoint.Add(p);
        }

    }
    void Move()
    {
        if (transform.position == pathPoint[desIndex].position)
        {
            desIndex = desIndex == pathPoint.Count - 1 ? 0 : desIndex + 1;
        }
        //位移
        transform.position = Vector3.MoveTowards(transform.position, pathPoint[desIndex].position, Time.deltaTime * speed);
        //转向
        transform.up = Vector3.Lerp(transform.up, pathPoint[desIndex].position - transform.position, smooth * Time.deltaTime);

    }
    private void FixedUpdate()
    {
        //rb.AddRelativeForce(Vector2.up);
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
