using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public DoorType type;
    public enum DoorType
    {
        BLUE,
        BLACK
    }
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
            if (type == DoorType.BLUE)
            {
                if (collision.gameObject.GetComponent<Player>().BlueKey)
                {
                    JointLimits tmpLimit = new JointLimits
                    {
                        max = 90,
                        min = -90
                    };
                    GetComponent<HingeJoint>().limits = tmpLimit;

                }
            }
            else if (type == DoorType.BLACK)
            {
                if (collision.gameObject.GetComponent<Player>().BlackKey)
                {
                    JointLimits tmpLimit = new JointLimits
                    {
                        max = 90,
                        min = -90
                    };
                    GetComponent<HingeJoint>().limits = tmpLimit;
                }
            }
        }
    }
}
