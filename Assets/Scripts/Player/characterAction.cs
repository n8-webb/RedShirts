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
    //CameraShake shake;
    //public book alive;

    float timer = 0.0f;

    GameObject respawnLocationObject;
    GameObject weaponSpriteObject;
    GameObject playerObject;

    //ParticleSystem bloodEmitter;
    SpriteRenderer playerSprite;
    SpriteRenderer gunSprite;
    BoxCollider2D playerBoxCollider;
    PolygonCollider2D playerPolyCollider;
    Rigidbody2D playerRigidbody;
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
                weaponSpriteObject = GameObject.Find("weaponSprite_P1");
                break;
            case 2:
                respawnLocationObject = GameObject.Find("respawnLocation_P2");
                playerObject = GameObject.Find("testPlayer_P2");
                weaponSpriteObject = GameObject.Find("weaponSprite_P2");
                break;
            case 3:
                respawnLocationObject = GameObject.Find("respawnLocation_P3");
                playerObject = GameObject.Find("testPlayer_P3");
                weaponSpriteObject = GameObject.Find("weaponSprite_P3");
                break;
            case 4:
                respawnLocationObject = GameObject.Find("respawnLocation_P4");
                playerObject = GameObject.Find("testPlayer_P4");
                weaponSpriteObject = GameObject.Find("weaponSprite_P4");
                break;
        }

        playerSprite = playerObject.GetComponent<SpriteRenderer>();
        playerBoxCollider = playerObject.GetComponent<BoxCollider2D>();
        playerPolyCollider = playerObject.GetComponent<PolygonCollider2D>();
        gunSprite = weaponSpriteObject.GetComponent<SpriteRenderer>();
        playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
        //bloodEmitter = playerObject.GetComponentInChildren<ParticleSystem>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAlive == false)
        {
            timer += Time.deltaTime;
            //shake.enable = true;
            if (timer >= deathTimer)
            {
                //bloodEmitter.Clear();
                Debug.Log(playerObject.transform.position);
                Debug.Log(respawnLocationObject.transform.position);
                playerObject.transform.position = respawnLocationObject.transform.position;
                playerSprite.enabled = true;
                gunSprite.enabled = true;
                playerBoxCollider.enabled = true;
                playerPolyCollider.enabled = true;
                playerRigidbody.gravityScale = 1;
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
        //bloodEmitter.Emit(250);       
        isAlive = false;
        Debug.Log("I am Player (" + transform.GetComponent<playerStats>().playerId + ") and have been killed by Player (" + killerID + ")");
        playerSprite.enabled = false;
        gunSprite.enabled = false;
        playerBoxCollider.enabled = false;
        playerPolyCollider.enabled = false;
        playerRigidbody.gravityScale = 0;
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
