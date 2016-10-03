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
    public void playerDie(int killerID)
    {
        Debug.Log("I am Player (" + transform.GetComponent<playerStats>().playerId + ") and have been killed by Player (" + killerID + ")");
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
        player.weapon.GetComponent<BaseGunClass>().fire(player);

        //Add visual fire effects
    }
}
