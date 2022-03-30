using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingSpike : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            print("Kill Player");
        }

    }
}
