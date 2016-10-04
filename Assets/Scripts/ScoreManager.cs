using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance { get; private set; }
    [Header("Players")]
    public GameObject[] playersGO;
    [Header("Players Scores Text")]
    public Text[] playersUI;
    [Header("Player Scores")]
    public int[] playersScores;


    // Use this for initialization
    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(this);
        }
        else
        {
            instance = this;
        }

    }


    // Update is called once per frame
    void Update()
    {

    }

    void UpdateCanvas(int playerId, int score)
    {
        playerId = playerId + 1;
        if (playerId == 1)
        {
            playersScores[0] = score;
            playersUI[0].text = playersScores[0].ToString();
        }

        if (playerId == 2)
        {
            playersScores[1] = score;
            playersUI[1].text = playersScores[0].ToString();
        }

        if (playerId == 3)
        {
            playersScores[2] = score;
            playersUI[2].text = playersScores[0].ToString();
        }

        if (playerId == 4)
        {
            playersScores[3] = score;
            playersUI[3].text = playersScores[0].ToString();
        }
    }

    //Adds one to player score of ID (uses 0 index)
    public void addScore(int playerId, int points)
    {
        playersScores[playerId] = playersScores[playerId] + points;
        playersUI[playerId].text = playersScores[0].ToString();
    }
}