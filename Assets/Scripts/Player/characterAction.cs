using UnityEngine;
using System.Collections;

public class characterAction : MonoBehaviour
{

    public bool isAlive;
    public bool canDie;
    public bool crouching;
    public bool isReloading;
    public int playerDeaths;
    public float deathTimer = 2.0f;
    //CameraShake shake;
    //public book alive;

    float timer = 0.0f;

    GameObject respawnLocationObject;
    GameObject weaponSpriteObject;
    GameObject playerObject;
    //GameObject Camera;


    // Use this for initialization
    void Start()
    {
        isAlive = true;
        playerObject = GameObject.Find("testplayer_P1");

        /*Camera = GameObject.Find("Main Camera");
        shake = gameObject.GetComponent<CameraShake>();
        shake.enabled = false;*/

        switch (transform.GetComponent<playerStats>().playerId)
        {
            case 1:
                respawnLocationObject = GameObject.Find("respawnLocation_P1");
                playerObject = GameObject.Find("testPlayer_P1");
                break;
            case 2:
                respawnLocationObject = GameObject.Find("respawnLocation_P2");
                playerObject = GameObject.Find("testPlayer_P2");
                break;
            case 3:
                respawnLocationObject = GameObject.Find("respawnLocation_P3");
                playerObject = GameObject.Find("testPlayer_P3");
                break;
            case 4:
                respawnLocationObject = GameObject.Find("respawnLocation_P4");
                playerObject = GameObject.Find("testPlayer_P4");
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == false)
        {
            timer += Time.deltaTime;
            //shake.enable = true;
            if (timer >= deathTimer)
            {
                Debug.Log(playerObject.transform.position);
                Debug.Log(respawnLocationObject.transform.position);
                playerObject.transform.position = respawnLocationObject.transform.position;
                timer = 0.0f;
                isAlive = true;
                //shake.enable = false;
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
        transform.position = new Vector3(100, -10, 0);
        playerDeaths++;

        //Find score manager and give the killer player 100 points, subtract the killed 50 points
        ScoreManager scoreManager = GameObject.Find("Canvas").transform.GetComponent<ScoreManager>();
        scoreManager.addScore(killerID - 1, 100);
        scoreManager.subtractScore(transform.GetComponent<playerStats>().playerId - 1, 50);
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
        //player.weapon.GetComponent<BaseGunClass>().fire(player);
        player.weapon.GetComponent<Gun>().isFiring = true;
        //Add visual fire effects
    }
}
