using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 100f;
    float huaTime = 1f;
    float degree = 90;
    float hp = 100;
    bool isPause = false;

    //bool canLeft = true, canRight = true;

    public event Hua HuaLeft;
    public event Hua HuaRight;
    public delegate void Hua(string dir, Vector3 v);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Global.isPause = false;
        HuaLeft += HuaEvent;
        HuaRight += HuaEvent;
    }

    //可放入外部
    void HuaEvent(string dir, Vector3 v)
    {

        if (dir == "left")
        {
            HuaLeft -= HuaEvent;
            
            Debug.Log("左边取消");

            StartCoroutine(HuaJiangLeft(v));
        }
        if (dir == "right" )
        {
            HuaRight -= HuaEvent;
            
            Debug.Log("右边取消");
            StartCoroutine(HuaJiangRight(v));
        }
    }
    IEnumerator HuaJiangLeft(Vector3 v)
    {
        rb.AddRelativeForce(v * speed);
        yield return new WaitForSeconds(huaTime);
        HuaLeft += HuaEvent;
        
        Debug.Log("左边恢复");
    }
    IEnumerator HuaJiangRight(Vector3 v)
    {
        rb.AddRelativeForce(v * speed);
        yield return new WaitForSeconds(huaTime);
        HuaRight += HuaEvent;
        
        Debug.Log("右边恢复");
    }
    //private void OnBecameInvisible()
    //{
    //    Debug.Log("隐藏");
    //}


    void OnCollisionEnter2D(Collision2D other)
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.P))
        {
            Global.Pause();
        }

    }
    void Water()
    {
        var rate = UnityEngine.Random.Range(0, 2f);
        rb.AddForce(Vector2.right * rate);
    }


    void Move()
    {
        var impulse = rb.inertia * Mathf.Deg2Rad * degree;
        if (Input.GetKey(KeyCode.Q))
        {
            HuaLeft?.Invoke("left", new Vector2(1, -4));
            //rb.AddRelativeForce(new Vector2(1, -4) * speed);
            rb.AddTorque(-impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            HuaLeft?.Invoke("left", new Vector2(1, 4));
            //rb.AddRelativeForce(new Vector2(1, 4) * speed);
            rb.AddTorque(impulse);
        }
        if (Input.GetKey(KeyCode.E))
        {
            HuaRight?.Invoke("right", new Vector2(-1, -4));
            //rb.AddRelativeForce(new Vector2(-1, -4) * speed);
            rb.AddTorque(impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            HuaRight?.Invoke("right", new Vector2(-1, 4));
            //rb.AddRelativeForce(new Vector2(-1, 4) * speed);
            rb.AddTorque(-impulse);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddRelativeForce(Vector2.up * speed);
        }

    }
}