using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generating Patrol Route for Enemies
public class PFTest : MonoBehaviour
{
    /*Algorithm Logic:
     * 1. Scanning current loaction with the radius R check obsticals, via raycasting, ray rotate 360, step a, every hit, record in map. 
     * 2. Finding the obstical with the longest covered angle, the highest value in map. Based on that, determine the initial direction.
     * 3.
     * 
     */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
