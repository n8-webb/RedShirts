using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float playerSpeed;

    public string jumpButton = "Jump_P1";
    public string horizontalCtrl = "Horizontal_P1";

    public int jumpPower;

    public float horizontal;
    public float jump;

    public LayerMask mask;

    public bool grounded;


    Rigidbody2D rb2d;
    PolygonCollider2D poly2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        poly2d = GetComponent<PolygonCollider2D>();
    }

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

        if (Physics2D.Raycast(transform.position, -Vector2.up, 1.22f, mask))
        {
            grounded = true;
;        }
        else
        {
            grounded = false;
        }

        jumpPower = 300;

        if (rb2d.velocity.y > 0)
        {
            grounded = false;
        }
        playerSpeed = 5.0f;

        horizontal = Input.GetAxis(horizontalCtrl);

        jump = Input.GetAxis(jumpButton);

        if (jump == 1 && grounded == true)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }

        if (horizontal == -1)
        {
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }

        else if (horizontal == 1)
        {
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }

        

    }

}
