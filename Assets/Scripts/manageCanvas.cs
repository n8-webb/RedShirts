using UnityEngine;
using System.Collections;

public class manageCanvas : MonoBehaviour {

    public float timeLeft = 60.0f;
    public GameObject leaderboard;
    public GameObject score;
    public GameObject[] players;


    // Use this for initialization
    void Start () {
        //leaderboard = GameObject.Find("LeaderboardCanvas");
        score = GameObject.Find("ScoreCanvas");
        players = GameObject.FindGameObjectsWithTag("Player");
        score.SetActive(true);
        leaderboard.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;

        if(timeLeft <= 0)
        {
            score.SetActive(false);
            leaderboard.SetActive(true);

            for (int i = 0; i < players.Length; i++)
            {
                players[i].SetActive(false);
            }
        }

    }
}
