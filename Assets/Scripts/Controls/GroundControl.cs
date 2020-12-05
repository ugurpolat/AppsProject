using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Rocketman"))
        {

            
            GameManager.GameIsOver = true;
            other.gameObject.GetComponent<FlyingControl>().enabled = false;
            other.gameObject.GetComponent<ThrowRocketman>().enabled = false;
            other.gameObject.GetComponent<Rocketman>().enabled = false;
            other.gameObject.GetComponent<MoveRocketman>().enabled = false;

        }
    }
}
