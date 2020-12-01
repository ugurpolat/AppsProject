using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocketman : MonoBehaviour
{
    //stick z axis

    private Touch touch;

    private float distance;
    private Vector3 centerPos = new Vector3(0f,10f,0f);
    

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
       
        speed = 0.01f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rocketman.RocketmanCurrentState == Rocketman.State.Still || Rocketman.RocketmanCurrentState == Rocketman.State.Dragged)
        {
            distance = Vector3.Distance(transform.position, centerPos);
            Debug.Log(distance);
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

                    if (distance > 1f && distance < 2.58f)
                    {
                        Rocketman.RocketmanThrowPower =Rocketman.ThrowPower.Slow;
                    }
                    else if (distance >= 4.5f && distance < 5.5f)
                    {
                        Rocketman.RocketmanThrowPower = Rocketman.ThrowPower.Medium;
                    }
                    else if (distance >= 5.5f)
                    {
                        Rocketman.RocketmanThrowPower = Rocketman.ThrowPower.Fast;
                    }
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    if (distance <= 0.05f)
                    {
                        Rocketman.RocketmanCurrentState = Rocketman.State.Still;

                        transform.position = centerPos;
                    }
                    else
                    {
                        Rocketman.RocketmanCurrentState = Rocketman.State.Thrown;    
                    }
                    
                }
            }
        }   
    }
    
}
