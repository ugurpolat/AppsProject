using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingControl : MonoBehaviour
{
    private Rocketman rocketmanScript;
    private Vector3 position;

    private float baseSpeed = 10.0f;
    private float rotSpeedX = 3.0f;
    private float rotSpeedY = 1.5f;
    private void Start()
    {
        rocketmanScript = GetComponent<Rocketman>();  
    }
    private void Update()
    {
        Vector3 moveVector = transform.forward * baseSpeed;

        //transform.position = new Vector3(
        //    transform.position.x + rocketmanScript.touch.deltaPosition.x * 0.02f,
        //    transform.position.y,
        //    transform.position.z);


        transform.position = new Vector3(
            transform.position.x + rocketmanScript.touch.deltaPosition.x * 0.02f,
            transform.position.y,
            transform.position.z);
    }

}
