using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager: MonoBehaviour
{
    private int score = 0;
    private Text scoreTxt = null;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GameObject.Find("ScoreTxt").GetComponent<Text>();
        scoreTxt.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
            addScore(69);
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (scoreTxt != null)
            scoreTxt.text = "Score: " + score.ToString("N0");
    }
}
