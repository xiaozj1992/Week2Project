using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player;
    public Transform compass;
    Vector2 xSize = new Vector2(4,4);
    Vector2 ySize = new Vector2(2.25f,2.25f);
    bool isFollowRotate = false;
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        var x = Mathf.Clamp (transform.position.x, player.position.x - xSize.x, player.position.x + xSize.y);
        var y = Mathf.Clamp (transform.position.y, player.position.y - ySize[0], player.position.y + ySize[1]);
        transform.position = new Vector3 (x, y, transform.position.z);

        if (isFollowRotate) {
            transform.rotation = player.rotation;
            compass.rotation = Quaternion.Euler (-player.rotation.eulerAngles);
        }
        //if(Input.GetKeyDown(KeyCode.R)){
        //    ChangeRotateState();
        //}
    }
    public void ChangeRotateState () {
        isFollowRotate = !isFollowRotate;
        if(!isFollowRotate){
            transform.rotation=Quaternion.identity;
            compass.rotation=Quaternion.identity;
        }
    }
}