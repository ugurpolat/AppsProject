using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketman : MonoBehaviour
{
    private MoveRocketman moveRocketmanScript;
    private ThrowRocketman throwRocketmanScript;

    private Rigidbody rb;

    public static State RocketmanCurrentState;
    public static ThrowPower RocketmanThrowPower;

    public GameObject stickMesh;

    public enum State
    {
        Still,
        Dragged,
        Thrown,
        Falling
    };

    public enum ThrowPower
    {
        NoPower,
        Slow,
        Medium,
        Fast
    };
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        RocketmanCurrentState = State.Still;
        RocketmanThrowPower = ThrowPower.NoPower;

        moveRocketmanScript = gameObject.GetComponent<MoveRocketman>();
        throwRocketmanScript = gameObject.GetComponent<ThrowRocketman>();


    }

    // Update is called once per frame
    void Update()
    {
        if (RocketmanCurrentState == State.Still)
        {
            RocketmanThrowPower = ThrowPower.NoPower;
            moveRocketmanScript.enabled = true;
            throwRocketmanScript.enabled = false;
        }
        else if (RocketmanCurrentState == State.Thrown)
        {
            
            moveRocketmanScript.enabled = false;
            throwRocketmanScript.enabled = true;
            //stickMesh.SetActive(false);
        }
        else if (RocketmanCurrentState == State.Falling)
        {
            RocketmanThrowPower = ThrowPower.NoPower;
            moveRocketmanScript.enabled = false;
            throwRocketmanScript.enabled = false;
        }
    }
    private void FixedUpdate()
    {
        if (RocketmanCurrentState ==State.Still )
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        else if (RocketmanCurrentState == State.Dragged)
        {
            rb.useGravity = false;
            rb.isKinematic = false;
        }
        else if (RocketmanCurrentState == State.Thrown || RocketmanCurrentState == State.Falling)
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
        else if (RocketmanCurrentState == State.Falling)
        {
            rb.velocity = new Vector3(0f,0f,0f);
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Game is over...");
        }
    }
}
