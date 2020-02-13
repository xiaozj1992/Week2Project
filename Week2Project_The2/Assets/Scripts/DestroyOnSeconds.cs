using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnSeconds : MonoBehaviour
{
    public float time;
    void Start()
    {
        Invoke("Func",time);
    }
    void Func()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            Destroy(gameObject);
        }
    }


}
