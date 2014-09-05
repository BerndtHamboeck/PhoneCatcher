using System;
using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{

    public GUIText scoreText;
    public int catchValue = 1;

    private int score = 0;

    // Use this for initialization
    void Start()
    {
        score = 0;
        UpdateScore();
    }


    void OnTriggerEnter2D(Collider2D second)
    {
        Debug.Log("Tag on trigger: " + second.tag);
        if (second.tag == "Good")
            score += catchValue;
        else
            score -= catchValue;

        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();

        //_signalr.Send("Score", scoreText.text.ToString());

    }
}
