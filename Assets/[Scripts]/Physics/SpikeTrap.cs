using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float ReflectionPower;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().maxAngularVelocity = 15;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddTorque(transform.up , ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            Vector3 forceDirection = (other.transform.position - transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().AddForce(forceDirection * ReflectionPower, ForceMode.Impulse);
        }
    }
}
