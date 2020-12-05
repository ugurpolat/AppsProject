using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketman : MonoBehaviour
{
    private MoveRocketman moveRocketmanScript;
    private ThrowRocketman throwRocketmanScript;
    private FlyingControl flyingControlScript;

    private Rigidbody rb;
    public Touch touch;
    private float xAngle = 90;
    private float speed = 5f;
    public static Animator anim;

    public static State RocketmanCurrentState;
    public static ThrowPower RocketmanThrowPower;

    //public GameObject stickMesh;
    


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
        anim = GetComponent<Animator>();

        RocketmanCurrentState = State.Still;
        RocketmanThrowPower = ThrowPower.NoPower;

        moveRocketmanScript = gameObject.GetComponent<MoveRocketman>();
        throwRocketmanScript = gameObject.GetComponent<ThrowRocketman>();
        flyingControlScript = gameObject.GetComponent<FlyingControl>();

    }

    // Update is called once per frame
    void Update()
    {
        if (RocketmanCurrentState == State.Still)
        {
            RocketmanThrowPower = ThrowPower.NoPower;
            moveRocketmanScript.enabled = true;
            throwRocketmanScript.enabled = false;
            flyingControlScript.enabled = false;
            
        }
        else if (RocketmanCurrentState == State.Thrown)
        {
            
            moveRocketmanScript.enabled = false;
            throwRocketmanScript.enabled = true;
            flyingControlScript.enabled = true;
            //stickMesh.SetActive(false);
            if (throwRocketmanScript.didItThrown)
            {
                
                if (Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Moved)
                    {
                        Rocketman.RocketmanCurrentState = Rocketman.State.Thrown;
                        anim.SetInteger("State",1);
                        Vector3 setAngle = new Vector3(xAngle, 0, 0);
                        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles,setAngle,Time.deltaTime * speed* 1.5f);

                        

                        
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        anim.SetInteger("State",2);
                        Rocketman.RocketmanCurrentState = State.Falling;
                    }
                }
            }
        
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
