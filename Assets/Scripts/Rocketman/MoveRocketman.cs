using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocketman : MonoBehaviour
{
    //stick z axis

    private Touch touch;

    private float distance;
    private Vector3 centerPos;
   

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
       
        speed = 0.001f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rocketman.RocketmanCurrentState == Rocketman.State.Still || Rocketman.RocketmanCurrentState == Rocketman.State.Dragged)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    Rocketman.RocketmanCurrentState = Rocketman.State.Dragged;

                    transform.position = new Vector3(
                           transform.position.x,
                           transform.position.y + touch.deltaPosition.y * speed,
                           transform.position.z + touch.deltaPosition.y * speed);
                }
            }
        }   
    }
    
}
