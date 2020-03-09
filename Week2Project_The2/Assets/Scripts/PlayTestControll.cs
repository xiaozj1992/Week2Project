using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTestControll : MonoBehaviour
{
    public GameObject pref;
    public float xMax;
    public float yMax;
    public int numMax;

    void Awake()
    {
        for (int i = 0; i < numMax; i++) {
            Vector2 tarPos = Pos(xMax, yMax);
            Collider2D hitColls = Physics2D.OverlapCircle(tarPos, 1);
            while (hitColls!= null) {
                tarPos = Pos(xMax, yMax);
                hitColls = Physics2D.OverlapCircle(tarPos, 1);
            }
            //Vector3 nPos = new Vector3(tarPos.x, tarPos.y, 0);
            Instantiate(pref,tarPos, Quaternion.identity);
        }
    }

    Vector2 Pos(float xM, float yM)
    {
        float x = Random.Range(-xMax, xMax);
        float y = Random.Range(-yMax, yMax);
        return new Vector2(x, y);
    }
}
