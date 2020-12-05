using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingControl : MonoBehaviour
{
    private Rocketman rocketmanScript;
    

    private float baseSpeed = 0.2f;
    
    private void Start()
    {
        rocketmanScript = GetComponent<Rocketman>();  
    }
    private void Update()
    {
        Vector3 moveVector = transform.forward * baseSpeed;

        transform.position = new Vector3(
            transform.position.x + rocketmanScript.touch.deltaPosition.x * 0.02f,
            transform.position.y,
            transform.position.z+moveVector.z);
    }

}
