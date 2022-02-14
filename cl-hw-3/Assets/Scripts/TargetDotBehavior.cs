using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDotBehavior : MonoBehaviour
{
    CursorController onClick;

    // Start is called before the first frame update
    void Start()
    {
        NewDotPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void NewDotPosition()
    {
        float xRandom = Random.Range(-8, 8);
        float yRandom = Random.Range(-4, 4);
        transform.position = new Vector3(xRandom, yRandom, 0);
    }
}

