using UnityEngine;
using System.Collections;

public class fallDestination : MonoBehaviour
{
    //The empty gameObject being used as the fall point
    //public Vector3 fallDestinationPos = new Vector3(0,2,0);
    public GameObject teleportDestination;

    void OnTriggerEnter2D(Collider2D other)
    {
        //print("HIT");
        if (other.gameObject.tag == "Player")
        {
            //Only changes the y axis, so if the player falls the right side of the hole, they'll keep falling from where they entered
            other.transform.position = teleportDestination.transform.position;
            //transform.position = new Vector3(transform.gameObject.x, fallDestinationPos.y, transform.gameObject.z);
            //}
        }
    }
}
