using UnityEngine;
using System.Collections;

public class aimDirection : MonoBehaviour {

    public string playerName = "testPlayer_P1";
    public string gunName = "weaponSprite_P1";

    GameObject player;
    GameObject gun;
    SpriteRenderer playerSprite;
    SpriteRenderer gunSprite;

    public string inputX = "Aim_X_P1";
    public string inputY = "Aim_Y_P1";
    float x;
    float y;
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

        x = Input.GetAxis(inputX);
        y = Input.GetAxis(inputY);
        aimAngle = 0.0f;

        if (x != 0.0f || y != 0.0f)
        {          
            aimAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            gun.transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.back);
            if (aimAngle > 90 || aimAngle < -90)
            {
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
