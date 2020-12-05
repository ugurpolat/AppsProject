using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderControl : MonoBehaviour
{
    public float jumpForce = 200f;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Rocketman"))
        {
            
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
           


        }
    }
}
