using UnityEngine;
using System.Collections;

public class characterAction : MonoBehaviour
{

    public bool isAlive;
    public bool canDie;
    public bool crouching;
    public bool isReloading;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
    public void playerCrouch(PlayerControl player)
    {
        player.crouching = true;
        //Change player sprite here//


    }

    //Called when a player stops crouching
    public void playerStand(PlayerControl player)
    {
        player.crouching = false;
        //Change player sprite here//


    }

    // Called when a player is reloading
    public void playerReload(PlayerControl player, GameObject gun)
    {
        //Call guns reload action
        //Change gun to reload sprite
    }

    // Called when a player fires
    public void playerFire(PlayerControl player, GameObject gun)
    {
        //Call guns fire function
        //Add visual fire effects
    }
}
