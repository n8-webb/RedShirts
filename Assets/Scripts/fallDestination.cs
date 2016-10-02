using UnityEngine;
using System.Collections;

public class fallDestination : MonoBehaviour
{
    //The empty gameObject being used as the fall point
    public Vector3 fallDestinationPos;

    void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag = "Player")
        {
            //Only changes the y axis, so if the player falls the right side of the hole, they'll keep falling from where they entered
            transform.position = new Vector3(transform.gameObject.x, fallDestinationPos.y, transform.gameObject.z);
        }*/
    }
}
