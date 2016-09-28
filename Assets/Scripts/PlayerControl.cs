using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float playerSpeed;

    public string jumpButton = "Jump_P1";
    public string horizontalCtrl = "Horizontal_P1";

    public int jumpPower;

    public float horizontal;
    public float jump;

    public bool grounded;


    Rigidbody2D rb2d;
    RaycastHit2D hit;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        grounded = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        grounded = false;
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        jumpPower = 300;

        if (rb2d.velocity.y > 0)
        {
            grounded = false;
        }
        playerSpeed = 5.0f;

        horizontal = Input.GetAxis(horizontalCtrl);

        jump = Input.GetAxis(jumpButton);

        if (horizontal == -1)
        {
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }

        else if (horizontal == 1)
        {
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }

        else if (jump == 1 && grounded == true)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }

    }

}
