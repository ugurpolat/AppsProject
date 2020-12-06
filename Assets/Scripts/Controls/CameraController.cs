using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform rocketmanFollowPos;
    public float transitionSpeed;
    Transform currentView;
    private GameObject rocketman;
    // Start is called before the first frame update
    void Start()
    {
        rocketman = GameObject.Find("Rocketman");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (rocketman.GetComponent<ThrowRocketman>().didItThrown == true)
        {
            //Lerp position
            transform.position = Vector3.Lerp(transform.position, rocketmanFollowPos.position, Time.deltaTime * transitionSpeed);

            Vector3 currentAngle = new Vector3(
                                              Mathf.LerpAngle(transform.rotation.eulerAngles.x, rocketmanFollowPos.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
                                              Mathf.LerpAngle(transform.rotation.eulerAngles.y, rocketmanFollowPos.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
                                              Mathf.LerpAngle(transform.rotation.eulerAngles.z, rocketmanFollowPos.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

            transform.eulerAngles = currentAngle;
        }


    }
}
