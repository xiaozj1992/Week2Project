using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    private Animator[] animators;
    private Animator manAni;
    private Animator leftPadAni;
    private Animator rightPadAni;

    // Start is called before the first frame update
    void Start()
    {
        animators = GetComponentsInChildren<Animator>();
        manAni = animators[0];
        leftPadAni = animators[1];
        rightPadAni = animators[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q")) {
            manAni.Play("ManRow_L");
            leftPadAni.Play("LeftPad_T");
        }
        if (Input.GetKey("w")) {
            manAni.Play("ManRow_H");
            leftPadAni.Play("LeftPad_H");
            rightPadAni.Play("RightPad_H");
        }
        if (Input.GetKeyDown("e")) {
            manAni.Play("ManRow_R");
            rightPadAni.Play("RightPad_T");
        }
    }
}
