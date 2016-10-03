using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour
{
    public float bulletSpeed = 2.0f;
    public int ownerID;


    void Start()
    {

    }

    void Update()
    {
        Rigidbody2D bulletRigid = GetComponent<Rigidbody2D>();
        bulletRigid.velocity = new Vector2(bulletSpeed, 0.0f);
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

            int hitID = col.GetComponent<playerStats>().playerId; //Grab the ID of the player

            //Check that the player hasn't hit themselves
            if (hitID != ownerID)
            {
                //Call the die function on the targeted player
                col.GetComponent<characterAction>().playerDie(ownerID);

                //Remove the bullet
                Destroy(gameObject);
            }

        }
    }

}