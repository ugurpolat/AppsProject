using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRocketmanPoint : MonoBehaviour
{
    public Transform rocketman;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rocketman.position + offset;
    }
}
