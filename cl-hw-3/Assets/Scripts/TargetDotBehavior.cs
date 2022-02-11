using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDotBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void NewDotPosition()
    {
        float xRandom = Random.Range(-9, 9);
        float yRandom = Random.Range(-5, 5);
        transform.position = new Vector3(xRandom, yRandom, 0);
    }

    void OnMouseDown()
    {
        NewDotPosition();
    }
}
