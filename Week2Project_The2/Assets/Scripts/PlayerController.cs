using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 200f;
    float huaTime = 1f;
    float degree = 180;
    float hp = 100;
    bool isPause = false;

    public event Hua HuaMid;

    public delegate void Hua(Vector3 v);
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Global.isPause = false;

        HuaMid += HuaEvent;
        HuaMid += HuaEvent;

        foreach(var t in HuaMid.GetInvocationList())
        {
        Debug.Log(t.ToString());
        }
        
    }
    //可放入外部
    void HuaEvent(Vector3 v)
    {

        HuaMid -= HuaEvent;
        StartCoroutine(HuaJiang(v));
    }
    IEnumerator HuaJiang(Vector3 v)
    {
        yield return new WaitForSeconds(huaTime / 2);
        var impulse = rb.inertia * Mathf.Deg2Rad * degree;
        rb.AddRelativeForce(v * speed);
        rb.AddTorque(impulse * (v.x * v.y > 0 ? 1 : -1) * (v.x == 0 ? 0 : 1));
        yield return new WaitForSeconds(huaTime / 2);
        HuaMid += HuaEvent;
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
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.P))
        {
            Global.Pause();
        }
    }
    void Move()
    {
        //var impulse = rb.inertia * Mathf.Deg2Rad * degree;
        if (Input.GetKey(KeyCode.Q))
        {
            HuaMid?.Invoke(new Vector2(1, -4).normalized);
            //rb.AddTorque(-impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            HuaMid?.Invoke(new Vector2(1, 4).normalized);
            //rb.AddTorque(impulse);
        }
        if (Input.GetKey(KeyCode.E))
        {
            HuaMid?.Invoke(new Vector2(-1, -4).normalized);
            //rb.AddTorque(impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            HuaMid?.Invoke(new Vector2(-1, 4).normalized);
            //rb.AddTorque(-impulse);
        }
        if (Input.GetKey(KeyCode.W))
        {
            HuaMid?.Invoke(Vector2.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            HuaMid?.Invoke(Vector2.down);
        }
    }
}