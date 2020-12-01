using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRocketman : MonoBehaviour
{

    private Rigidbody rb;
    private float throwForce;
    private bool didItThrown;

    private void OnEnable()
    {
        didItThrown = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        throwForce = 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Rocketman.RocketmanThrowPower == Rocketman.ThrowPower.Slow)
        {
            if (!didItThrown)
            {
                rb.AddRelativeForce(Vector3.forward * throwForce * 0.3f, ForceMode.Impulse);

                didItThrown = true;
            }
        }
        else if (Rocketman.RocketmanThrowPower == Rocketman.ThrowPower.Medium)
        {
            if (!didItThrown)
            {
                rb.AddRelativeForce(Vector3.forward * throwForce * 0.3f,ForceMode.Impulse);
                didItThrown = true;
            }
        }
        else if (Rocketman.RocketmanThrowPower == Rocketman.ThrowPower.Fast)
        {
            if (!didItThrown)
            {
                rb.AddRelativeForce(Vector3.forward * throwForce * 0.3f, ForceMode.Impulse);
                didItThrown = true;
            }
        }
    }
}
