using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class activatePlayer : MonoBehaviour {

    public string activateButton = "Activate_P1";
    public string playerToActivate = "testPlayer_P1";
    public bool activated;
    public float activateValue;
    GameObject player;

    public Text scoreText;

    // Use this for initialization
    void Start () {

        player = GameObject.Find(playerToActivate);
        player.SetActive(false);
        activated = false;

        scoreText.text = "PRESS START";

	}
	
	// Update is called once per frame
	void Update () {

        activateValue = Input.GetAxis(activateButton);

        if (activateValue == 1 && activated == false)
        {
            player.SetActive(true);
            activated = true;
            scoreText.text = "0";

        }

    }
}
