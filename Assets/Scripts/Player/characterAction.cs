using UnityEngine;
using System.Collections;

public class characterAction : MonoBehaviour
{

    public bool isAlive;
    public bool canDie;
    public bool crouching;
    public bool isReloading;
    public int playerDeaths;
    public float deathTimer = 5.0f;

    float timer = 0.0f;

    SpriteRenderer playerSprite;
    SpriteRenderer weaponSprite;
    GameObject respawnLocationObject;
    GameObject weaponSpriteObject;


    // Use this for initialization
    void Start()
    {
        isAlive = true;
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        switch (transform.GetComponent<playerStats>().playerId)
        {
            case 1:
                respawnLocationObject = GameObject.Find("respawnLocation_P1");
                weaponSpriteObject = GameObject.Find("weaponSprite_P1");
                
                break;
            case 2:
                respawnLocationObject = GameObject.Find("respawnLocation_P2");
                weaponSpriteObject = GameObject.Find("weaponSprite_P2");
                break;
            case 3:
                respawnLocationObject = GameObject.Find("respawnLocation_P3");
                weaponSpriteObject = GameObject.Find("weaponSprite_P3");
                break;
            case 4:
                respawnLocationObject = GameObject.Find("respawnLocation_P4");
                weaponSpriteObject = GameObject.Find("weaponSprite_P4");
                break;
        }
        weaponSprite = weaponSpriteObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == false)
        {
            timer += Time.deltaTime;

            if (timer >= deathTimer)
            {
                transform.position = respawnLocationObject.transform.position;
                playerSprite.enabled = true;
                weaponSprite.enabled = true;
                timer = 0.0f;
                isAlive = true;
            }
        }
    }

    // Called when spawning a player
    void playerSpawn()
    {

    }

    // Called when a player dies
    public void playerDie(int killerID)
    {
        isAlive = false;
        Debug.Log("I am Player (" + transform.GetComponent<playerStats>().playerId + ") and have been killed by Player (" + killerID + ")");
        playerSprite.enabled = false;
        weaponSprite.enabled = false;
        playerDeaths++;       
    }

    // Called when a player starts crouching
    public void playerCrouch(PlayerControl player)
    {
        player.stats.crouching = true;
        //Change player sprite here//


    }

    //Called when a player stops crouching
    public void playerStand(PlayerControl player)
    {
        player.stats.crouching = false;
        //Change player sprite here//


    }

    // Called when a player is reloading
    public void playerReload(PlayerControl player)
    {
        //Call guns reload action
        //Change gun to reload sprite
    }

    // Called when a player fires
    public void playerFire(PlayerControl player)
    {
        //Call weapons fire function
        player.weapon.GetComponent<BaseGunClass>().fire(player);

        //Add visual fire effects
    }
}
