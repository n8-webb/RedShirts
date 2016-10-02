using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public int playerSpeed = 5;

    //Change these depending on what player it is in the inspector window

    public string jumpButton = "Jump_P1";
    public string horizontalCtrl = "Horizontal_P1";
    public string playerJumpSprite = "player jump red";
    public string playerIdleSprite = "player idle red";

    //Strength of the jump

    public int jumpPower = 300;

    //Values for the controller

    public float horizontal;
    public float jump;

    //Allows raycast to ignore the player itself

    public LayerMask mask;

    //Is the player on the ground?

    public bool grounded;

    //Unity stuff

    Rigidbody2D rb2d;
    PolygonCollider2D poly2d;
    SpriteRenderer playerSprite;
    Sprite[] jumpSprite;
    Sprite[] idleSprite;

    // Use this for initialization
    void Start () {

        //Fetch the unity stuff
        rb2d = GetComponent<Rigidbody2D>();
        poly2d = GetComponent<PolygonCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        jumpSprite = Resources.LoadAll<Sprite>(playerJumpSprite);
        idleSprite = Resources.LoadAll<Sprite>(playerIdleSprite);
    }

    //Trigger stuff for the falling through platform on down press

    void OnTriggerEnter2D(Collider2D col)
    {
        if (jump == -1)
        {
            if (col.transform.gameObject.tag == "Platform")
            {
                poly2d.enabled = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (jump == -1)
        {
            if (col.transform.gameObject.tag == "Platform")
            {
                poly2d.enabled = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.gameObject.tag == "Platform")
        {
            poly2d.enabled = true;
        }
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        //Casts a raycast ignoring the player to check if grounded
        if (Physics2D.Raycast(transform.position, -Vector2.up, 1.0f, mask))
        {
            grounded = true;
            playerSprite.sprite = idleSprite[0];
        }
        else
        {
            grounded = false;
            playerSprite.sprite = jumpSprite[0];
        }

        //Fetches the values from the controller and keyboard presses
        horizontal = Input.GetAxis(horizontalCtrl);

        jump = Input.GetAxis(jumpButton);


        //Adds force to the player's rigid body in the up direction
        if (jump == 1 && grounded == true && rb2d.velocity.y == 0)
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

    }

}
