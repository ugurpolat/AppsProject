using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickRotation : MonoBehaviour
{
    private GameObject rocketman;
    private float followSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rocketman = GameObject.Find("Rocketman");
        followSpeed = 35f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateToBall();
    }

    private void RotateToBall()
    {
        Vector3 direction = rocketman.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * followSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(-rotation.x, 0f, 0f);
    }
}
