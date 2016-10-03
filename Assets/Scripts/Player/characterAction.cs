using UnityEngine;
using System.Collections;

public class characterAction : MonoBehaviour {

    public bool isAlive;
    public bool canDie;
    public bool crouching;
    public bool isReloading;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Called when spawning a player
    void playerSpawn()
    {

    }

    // Called when a player dies
    void playerDie()
    {

    }

    // Called when a player starts crouching
    void playerCrouch()
    {
        crouching = true;
    }

    //Called when a player stops crouching
    void playerStand()
    {
        crouching = false;
    }

    // Called when a player is reloading
    void playerReload()
    {

    }
}
