
using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour
{
    public float speed;
    public int ownerID;


    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Check if the bullet has collided with a player
        if (col.tag == "Player")
        {
            //Grab the ID of the player
            int hitID = col.GetComponent<playerStats>().playerId;

            //Check that the player hasn't hit themselves
            if (hitID != ownerID)
            {
                //Call the die function on the targeted player
                col.GetComponent<characterAction>().playerDie(ownerID);

                //Remove the bullet
                Destroy(gameObject);
            }
        }
        else if (col.tag == "Platform" || col.tag == "Level")
        {
            //Remove the bullet if it collides with a platform
            Destroy(gameObject);
        }
    }

}