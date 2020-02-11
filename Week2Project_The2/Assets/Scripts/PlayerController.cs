using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 5f;
    float degree = 20;
    public float hp = 100;
    public bool isPause = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Global.isPause = false;


    }
    private void OnBecameInvisible()
    {
        Debug.Log("隐藏");
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {

    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        // Water();

    }
    void Water()
    {
        var rate = Random.Range(0, 2f);
        rb.AddForce(Vector2.right * rate);
    }
    void Move()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddRelativeForce(new Vector2(1, -2)*speed);
            var impulse = rb.inertia * Mathf.Deg2Rad * degree;
            rb.AddTorque(-impulse);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rb.AddRelativeForce(new Vector2(-1, -2) * speed);
            var impulse = rb.inertia * Mathf.Deg2Rad * degree;
            rb.AddTorque(impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(new Vector2(1,2) * speed);
            var impulse = rb.inertia * Mathf.Deg2Rad * degree;
            rb.AddTorque(impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(new Vector2(-1, 2) * speed);
            var impulse = rb.inertia * Mathf.Deg2Rad * degree;
            rb.AddTorque(-impulse);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Global.isPause = !Global.isPause;

            Time.timeScale = Global.isPause ? 0 : 1;
        }
    }
}