using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class PlayerControl : MonoBehaviour {

    public int playerSpeed = 5;

    //Change these depending on what player it is in the inspector window
    public string jumpButton = "Jump_P1";
    public string crouchButton = "Crouch_P1";
    public string reloadButton = "Reload_P1";
    public string fireCtrl = "Fire_P1";
    public string horizontalCtrl = "Horizontal_P1";
    public string playerJumpSprite = "player jump red";
    public string playerIdleSprite = "player idle red";

    //Strength of the jump
    public int jumpPower = 150;
    public float maxSpeed = 15.0f;

    //Character Actions
    public characterAction actions;

    //Player Stats
    public playerStats stats;


    //Players Weapon
    public GameObject weapon;
    public GameObject bullet;


    //Values for the controller
    public float horizontal;
    public float jump;
    public float crouch;
    public float fire;
    public float reload;

    //Allows raycast to ignore the player itself
    public LayerMask mask;

    //Is the player on the ground?
    public bool grounded;

    //Is the player crouching?
    public bool crouching;
    private bool hasShot = false;
    private float delay = 0.0f;
    public GameObject prefabPS;
    public Object bloodSystem;
    bool playerBleeding;

    //Unity stuff
    Rigidbody2D rb2d;
    BoxCollider2D box2d;
    SpriteRenderer playerSprite;
    Sprite[] jumpSprite;
    Sprite[] idleSprite;
    

    // Use this for initialization
    void Start () {

        //Fetch the unity stuff
        rb2d = GetComponent<Rigidbody2D>();
        box2d = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        jumpSprite = Resources.LoadAll<Sprite>(playerJumpSprite);
        idleSprite = Resources.LoadAll<Sprite>(playerIdleSprite);
        actions = gameObject.AddComponent<characterAction>() as characterAction;
        stats = GetComponent<playerStats>();
    }

    //Trigger stuff for the falling through platform on down press
    void OnTriggerEnter2D(Collider2D col)
    {
        if (jump == -1)
        {
            if (col.transform.gameObject.tag == "Platform")
            {
                box2d.enabled = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (jump == -1)
        {
            if (col.transform.gameObject.tag == "Platform")
            {
                box2d.enabled = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.gameObject.tag == "Platform")
        {
            box2d.enabled = true;
        }
    }
    // Update is called once per frame

    void FixedUpdate()
    {

        if (playerSprite.enabled == false)
        {            
            if (bloodSystem == null)
            {
                //bloodSystem = Instantiate(prefabPS, transform.position, transform.rotation);
            }
        }
        else
        {
            if (bloodSystem != null)
            {
                Destroy(bloodSystem);
            }     
        }

        //Casts a raycast ignoring the player to check if grounded
        if (Physics2D.Raycast(transform.position, -Vector2.up, 1.0f, mask))
        {
            stats.grounded = true;
            playerSprite.sprite = idleSprite[0];
        }
        else
        {
            stats.grounded = false;
            playerSprite.sprite = jumpSprite[0];
        }

        if (rb2d.velocity.magnitude > maxSpeed)
        {
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        }

        //Fetches the values from the controller and keyboard presses
        horizontal = Input.GetAxis(horizontalCtrl);
        jump = Input.GetAxis(jumpButton);
        crouch = Input.GetAxis(crouchButton);
        reload = Input.GetAxis(reloadButton);
        fire = Input.GetAxis(fireCtrl);


        //Adds force to the player's rigid body in the up direction
        if (jump == 1 && stats.grounded == true && rb2d.velocity.y == 0)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }
        
        //Moves the player in the left direction
        if (horizontal == -1)
        {            
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }

        //Moves the player in the right direction
        else if (horizontal == 1)
        {   
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }


        //Player crouch (E or B-Button)
        if (crouch == 1 && !stats.crouching)
        {
            actions.playerCrouch(this);
        }

        //Player stand
        if (stats.crouching && crouch != 1)
        {
            actions.playerStand(this);
        }


        //Player Shoot (Click or Right Trigger)
        if (fire == 1)
        {
            if(Time.time > delay)
            {
                delay = Time.time + weapon.GetComponent<Gun>().fireRate;
                print(fire);
                fire = 0;

                actions.playerFire(this);
            }
            
        }

        
        
        //Player Reload (Q or Right Bumper)
        if (reload == 1)
        {
            actions.playerReload(this);
        }


        //If vibrating is enabled tick the timer
        if (stats.vibrating)
        {
            //If there is no vibration time left stop vibration
            if (stats.vibrateTime <= 0)
            {
                GamePad.SetVibration((PlayerIndex)stats.playerId - 1, 0.0f, 0.0f);
                stats.vibrating = false;
            }
            stats.vibrateTime -= Time.deltaTime;
        }
    }

}
