using UnityEngine;
using System.Collections;

public class aimDirection : MonoBehaviour {

    //Change these depending on what player it is in the inspector window

    public string playerName = "testPlayer_P1";
    public string gunName = "weaponSprite_P1";
    public string inputX = "Aim_X_P1";
    public string inputY = "Aim_Y_P1";

    //Unity stuff

    GameObject player;
    GameObject gun;
    SpriteRenderer playerSprite;
    SpriteRenderer gunSprite;

    //Stuff needed for finding out right stick direction

    public float x;
    public float y;
    public float aimAngle;

    // Use this for initialization
    void Start () {
        player = GameObject.Find(playerName);
        playerSprite = player.GetComponent<SpriteRenderer>();
        gunSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        gun = GameObject.Find(gunName);
	}
	
	// Update is called once per frame
	void Update () {

        //Fetches the values from the right stick on the controller
        x = Input.GetAxis(inputX);
        y = Input.GetAxis(inputY);

        //This maths stuff gets the angle of the right analog stick and turns it into a quaternion rotation for the gun object
        if (x != 0.0f || y != 0.0f)
        {          
            aimAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            gun.transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.back);
            if (aimAngle > 90 || aimAngle < -90)
            {
                //So the gun isn't upside down when aiming left
                playerSprite.flipX = true;
                gunSprite.flipY = true;

            }
            else
            {
                playerSprite.flipX = false;
                gunSprite.flipY = false;
            }
                       
        }
       
	}
}
