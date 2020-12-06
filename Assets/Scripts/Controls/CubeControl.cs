using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    public float jumpForce = 2.5f;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Rocketman"))
        {
            
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
            

        }
    }
}
