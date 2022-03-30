using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDownZone : MonoBehaviour
{
    private float prevSpeed;
    private float prevMaxSpeed;

    private float boostSpeed = 50;
    private float boostMaxSpeed = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            prevMaxSpeed = other.gameObject.GetComponent<Player>().MaxSpeed;
            prevSpeed = other.gameObject.GetComponent<Player>().Speed;

            other.gameObject.GetComponent<Player>().MaxSpeed = boostMaxSpeed;
            other.gameObject.GetComponent<Player>().Speed = boostSpeed;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Player>().MaxSpeed = prevMaxSpeed;
        other.gameObject.GetComponent<Player>().Speed = prevSpeed;
    }

}
