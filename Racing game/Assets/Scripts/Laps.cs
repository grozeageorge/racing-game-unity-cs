using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laps : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject car;
    private GameObject start;
    private int laps = 0;

    // Update is called once per frame
    void Update()
    {
        if (start.transform.position.z == car.transform.position.z)
        {
            laps++;
        }
        if (laps == 3)
        {
            // ENDGAME
        }
    }
}
