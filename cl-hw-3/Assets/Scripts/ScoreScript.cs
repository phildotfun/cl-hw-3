using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //script tracks the high score
    //and adds it to the high score text component

    const string FILE_NAME = "HighScore.txt";

    public Text highScore;
    private int highScoreInt;

    public Text currentScore;
    private int highScoreNum;


    

    // Start is called before the first frame update
    void Start()
    {
        GetHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        int newScore = CompareScore(highScore.text, currentScore.text);
        StreamWriter writer = new StreamWriter(FILE_NAME, false);
        writer.Write(newScore.ToString());
        writer.Close();
    }

    void GetHighScore()
    {
        //get the current highscore
        StreamReader reader = new StreamReader(FILE_NAME);
        string highScoreContent = reader.ReadLine();
        highScore.text = highScoreContent;
        reader.Close();

    }

    int CompareScore(string highScore, string currentScore)
    {
        //if the high score is higher than the current scor
        //write the high score
        //if the high score is less than the current score
        //write the current score to the file

        int highScoreInt = ConvertStringToNum(highScore);
        int currentScoreInt = ConvertStringToNum(currentScore);

        if (highScoreInt < currentScoreInt)
        {
            return currentScoreInt;
        }
        else
        {
            return highScoreInt;
        }
    }

    //convert string to number
    int ConvertStringToNum(string number)
    {
        int scoreNum;
        scoreNum = int.Parse(number);
        return scoreNum;
    }

    string ConvertNumToString(int number)
    {
        string scoreNum;
        scoreNum = number.ToString();
        return scoreNum;
    }

}
