using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    private Animator[] animators;
    private Animator manAni;
    private Animator leftPadAni;
    private Animator rightPadAni;
    PlayerController PC;

    // Start is called before the first frame update
    void Start()
    {
        animators = GetComponentsInChildren<Animator>();
        manAni = animators[0];
        leftPadAni = animators[1];
        rightPadAni = animators[2];

        PC = GetComponent<PlayerController>();
        PC.AnimEvent += PC_AnimEvent;
    }

    private void PC_AnimEvent(KeyCode key)
    {
        PC.AnimEvent -= PC_AnimEvent;
        switch (key)
        {
            case KeyCode.Q:
                manAni.Play("ManRow_L");
                leftPadAni.Play("LeftPad_T");
                break;
            case KeyCode.A:
                manAni.Play("ManRow_L");
                leftPadAni.Play("LeftPad_T");
                break;
            case KeyCode.W:
                manAni.Play("ManRow_H");
                leftPadAni.Play("LeftPad_H");
                rightPadAni.Play("RightPad_H");
                break;
            case KeyCode.S:
                manAni.Play("ManRow_H");
                leftPadAni.Play("LeftPad_H");
                rightPadAni.Play("RightPad_H");
                break;
            case KeyCode.E:
                manAni.Play("ManRow_R");
                rightPadAni.Play("RightPad_T");
                break;
            case KeyCode.D:
                manAni.Play("ManRow_R");
                rightPadAni.Play("RightPad_T");
                break;
        }

        StartCoroutine(AddAnim());
    }
    IEnumerator AddAnim()
    {
        yield return new WaitForSeconds(PC.huaTime);
        PC.AnimEvent += PC_AnimEvent;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("q")) {
        //    manAni.Play("ManRow_L");
        //    leftPadAni.Play("LeftPad_T");
        //}
        //if (Input.GetKey("w")) {
        //    manAni.Play("ManRow_H");
        //    leftPadAni.Play("LeftPad_H");
        //    rightPadAni.Play("RightPad_H");
        //}
        //if (Input.GetKey("e")) {
        //    manAni.Play("ManRow_R");
        //    rightPadAni.Play("RightPad_T");
        //}
    }
}
