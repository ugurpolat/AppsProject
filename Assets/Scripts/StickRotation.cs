using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickRotation : MonoBehaviour
{
    public Transform rocketman;
    private float followSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
        followSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        RotateToBall();
    }

    private void RotateToBall()
    {
        //Vector3 direction = rocketman.transform.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(direction);
        ////Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * followSpeed).eulerAngles;
        //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * followSpeed).eulerAngles;
        //transform.rotation = lookRotation;

        
    }
}
