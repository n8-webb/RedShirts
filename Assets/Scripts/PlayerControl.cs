using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float playerSpeed;

    public int playerID;

    public string jumpButton = "Jump_P1";
    public string horizontalCtrl = "Horizontal_P1";

    public float horizontal;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        playerSpeed = 5.0f;

        horizontal = Input.GetAxis(horizontalCtrl);

        if (Input.GetButton(horizontalCtrl))
        {
            if (horizontal == -1)
            {
                transform.position += Vector3.left * playerSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.right * playerSpeed * Time.deltaTime;
            }

        }
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += Vector3.right * playerSpeed * Time.deltaTime;

        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += Vector3.up * playerSpeed * Time.deltaTime;

        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position += Vector3.down * playerSpeed * Time.deltaTime;

        //}

        if (Input.GetButtonDown(jumpButton))
        {

        }

    }
}
