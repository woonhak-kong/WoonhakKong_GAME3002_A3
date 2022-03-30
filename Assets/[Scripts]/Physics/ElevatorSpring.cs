using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSpring : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GetComponent<SpringJoint>().massScale = 100;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GetComponent<SpringJoint>().massScale = 1;
        }
    }
}
