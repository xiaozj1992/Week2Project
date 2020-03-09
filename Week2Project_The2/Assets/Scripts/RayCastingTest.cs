using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastingTest : MonoBehaviour
{
    private Ray2D lray;
    private RaycastHit2D hit;
    private float angle;
    public float lineLength;
    public float stepSize;

    private void Awake()
    {
        //Initializing Detacted Target
        hit = Physics2D.Raycast(transform.position, transform.up, lineLength, LayerMask.GetMask("Player"));
        angle = 90f;
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
        
        Debug.DrawLine(transform.position, (transform.position+NewDirc(angle) * lineLength), Color.red);
        
        if (hit.collider != null) {
            print(transform.name + ":  " + hit.collider.name);
            print(transform.name + " Ray Length:  " + transform.up*lineLength);
        }
        //transform.Rotate(0f, 0f, .5f);
        
        //if (hit.collider.transform.parent.name

    }

    private void FixedUpdate()
    {
        angle += .02f;
        angle = angle % 360;
        hit = Physics2D.Raycast(transform.position, NewDirc(angle), lineLength, LayerMask.GetMask("Player"));
    }

    private Vector3 NewDirc(float angle)
    {
        Vector3 dirc = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle),0);
        return dirc;
    }
}
