using UnityEngine;
using System.Collections;

public class movingPlatform : MonoBehaviour {

    public float platformSpeed;
    public Vector3 platformStart;
    public Vector3 platformDestination;

    bool movingToDestination;

	// Use this for initialization
	void Start () {
        platformStart = transform.position;
        movingToDestination = true;
	
	}
	
	// Update is called once per frame
	void Update () {

        platformSpeed = 1.0f;

        if (movingToDestination == true)
        {
            transform.position += Vector3.down * platformSpeed * Time.deltaTime;
            Debug.Log("Moving down");
        }

        else
        {
            transform.position += Vector3.up * platformSpeed * Time.deltaTime;
            Debug.Log("Moving up");
        }
        
        if (transform.position.y <= platformDestination.y)
        {
            Debug.Log("Arrived at destination");
            movingToDestination = false;
        }

        else if (transform.position.y >= platformStart.y)
        {
            movingToDestination = true;
        }

    }
}
