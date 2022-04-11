using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public KeyType type;
    public enum KeyType{
        BLUE,
        BLACK
    }

    private float rotation = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotation += 0.1f;


        transform.Rotate(transform.rotation.x, rotation, transform.rotation.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (type == KeyType.BLUE)
            {
                other.GetComponent<Player>().BlueKey = true;
                
            }
            else if (type == KeyType.BLACK)
            {
                other.GetComponent<Player>().BlackKey = true;

            }
            Destroy(this.gameObject);
        }

    }

}
