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
        
    }
}
