using UnityEngine;
using System.Collections;

public class activatePlayer : MonoBehaviour {

    public string activateButton = "Activate_P1";
    public string playerToActivate = "testPlayer_P1";
    public bool activated;
    public float activateValue;
    GameObject player;


    // Use this for initialization
    void Start () {

        player = GameObject.Find(playerToActivate);
        player.SetActive(false);
        activated = false;

	}
	
	// Update is called once per frame
	void Update () {

        activateValue = Input.GetAxis(activateButton);

        if (activateValue == 1 && activated == false)
        {
            player.SetActive(true);
            activated = true;


        }

    }
}
