using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 400f;
    public float huaTime = 1f;
    float degree = 1440f;
    float hp = 100;
    bool isPause = false;
    bool isEnd = false;
    float maxTime = 600;//游戏最大时间

    public event Hua HuaMid;
    public delegate void Hua(Vector3 v);

    public event Anim AnimEvent;
    public delegate void Anim(KeyCode key);

    public GameObject[] AnimObject;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Global.isPause = false;

        HuaMid += HuaEvent;
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
        rb.AddTorque(impulse * (v.x * v.y > 0 ? 1 : -1) * (v.x == 0 ? 0 : 1));
        rb.AddRelativeForce(v * speed);
        yield return new WaitForSeconds(huaTime / 2);
        HuaMid += HuaEvent;
    }
    //private void OnBecameInvisible()
    //{
    //    Debug.Log("隐藏");
    //}

    void Damage(int i)
    {
        hp -= i;
        if (hp <= 0)
        {
            Instantiate(AnimObject[6], Vector3.zero, Quaternion.identity);
            isEnd = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Big")
        {
            Damage(40);
        }

        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(AnimObject[1], Vector3.zero, Quaternion.identity);
            isEnd = true;
        }
        if (other.gameObject.tag == "Police")
        {
            Instantiate(AnimObject[2], Vector3.zero, Quaternion.identity);
            isEnd = true;

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Small")
        {
            Damage(20);
        }


        if (other.tag == "Goal")
        {
            if (other.name == "Goal1")
            {
                Instantiate(AnimObject[0], Vector3.zero, Quaternion.identity);
            }
            if (other.name == "Goal2")
            {
                Instantiate(AnimObject[1], Vector3.zero, Quaternion.identity);
            }
            if (other.name == "Goal3")
            {
                Instantiate(AnimObject[2], Vector3.zero, Quaternion.identity);
            }
            if (other.name == "Goal4")
            {
                Instantiate(AnimObject[3], Vector3.zero, Quaternion.identity);
            }

            isEnd = true;
        }

    }
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.P))
        {
            Global.Pause();
        }
        if (Time.time > maxTime)
        {

        }
        if (isEnd)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadSceneAsync("Title");
            }
        }
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            AnimEvent?.Invoke(KeyCode.Q);
            HuaMid?.Invoke(new Vector2(1, -4).normalized);
        }
        if (Input.GetKey(KeyCode.A))
        {
            AnimEvent?.Invoke(KeyCode.A);
            HuaMid?.Invoke(new Vector2(1, 4).normalized);
        }
        if (Input.GetKey(KeyCode.E))
        {
            AnimEvent?.Invoke(KeyCode.E);
            HuaMid?.Invoke(new Vector2(-1, -4).normalized);
        }
        if (Input.GetKey(KeyCode.D))
        {
            AnimEvent?.Invoke(KeyCode.D);
            HuaMid?.Invoke(new Vector2(-1, 4).normalized);
        }
        if (Input.GetKey(KeyCode.W))
        {
            AnimEvent?.Invoke(KeyCode.W);
            HuaMid?.Invoke(Vector2.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            AnimEvent?.Invoke(KeyCode.S);
            HuaMid?.Invoke(Vector2.down);
        }
    }
}