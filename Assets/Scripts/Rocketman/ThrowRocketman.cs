using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRocketman : MonoBehaviour
{

    private Rigidbody rb;
    private float throwForce;
    public bool didItThrown;

    private void OnEnable()
    {
        didItThrown = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        throwForce = 50f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Rocketman.RocketmanThrowPower == Rocketman.ThrowPower.Slow)
        {
            if (!didItThrown)
            {
                rb.AddRelativeForce(new Vector3(0f,3f,1f) * throwForce * 0.3f, ForceMode.Impulse);

                didItThrown = true;
            }
        }
        else if (Rocketman.RocketmanThrowPower == Rocketman.ThrowPower.Medium)
        {
            if (!didItThrown)
            {
                rb.AddRelativeForce(new Vector3(0f, 3f, 1f) * throwForce * 0.6f,ForceMode.Impulse);
                didItThrown = true;
            }
        }
        else if (Rocketman.RocketmanThrowPower == Rocketman.ThrowPower.Fast)
        {
            if (!didItThrown)
            {
                rb.AddRelativeForce(new Vector3(0f, 3f, 1f) * throwForce * 1f, ForceMode.Impulse);
                didItThrown = true;
            }
        }
    }
}
