using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool is3D;   //Determine which rigibody is used.
    public float spd;   //Speed variable
    public float trq;   //Torque variable
    private Animator anis;

    // Start is called before the first frame update
    void Start()
    {
        anis = GetComponent<Animator>();
        //if (is3D) {
           // rb = GetComponent<Rigidbody>();
        //} else {
            rb = GetComponent<Rigidbody2D>();
       // }
    }

    // Update is called once per frame
    void Update()
    {
        //Input Method I
        /*
        if (Input.GetKeyDown("e")){
            anis.SetBool("isRightPad", true);
        }
        if (Input.GetKeyDown("w")){
            anis.SetBool("isBoth", true);
        }
        if (Input.GetKeyDown("q")){
            anis.SetBool("isLeftPad", true);
        }
        if (Input.GetKeyUp("w")) {
            anis.SetBool("isBoth", false);
        }
        if (Input.GetKeyUp("e")) {
            anis.SetBool("isRightPad", false);
        }
        if (Input.GetKeyUp("q")) {
            anis.SetBool("isLeftPad", false);
        }
        */

        //Input Method II
        if (Input.GetKey("e")) {
            anis.Play("Player_Lt");
        } else
        if (Input.GetKey("w")) {
            anis.Play("Player_F");
        } else
        if (Input.GetKey("q")) {
            anis.Play("Player_Rt");
        }

    }

    void VerticalMovement()
    {
        rb.AddForce(transform.up * spd, ForceMode2D.Impulse);
    }

    void LeftPadMovement()
    {
        rb.AddForce((transform.up + transform.right*-.2f)* spd / 2, ForceMode2D.Impulse);
        rb.AddTorque(/*transform.forward * */trq, ForceMode2D.Impulse);
    }

    void RightPadMovement() {
        rb.AddForce((transform.up + transform.right* .2f) * spd / 2, ForceMode2D.Impulse);
        rb.AddTorque(/*transform.forward * */trq *-1, ForceMode2D.Impulse);
    }

    void VerticalReset()
    {
        //anis.SetBool("isBoth", false);
    }

    void LeftPadReset()
    {
        //anis.SetBool("isLeftPad", false);
    }

    void RightPadReset()
    {
        //anis.SetBool("isRightPad", false);
    }
}
