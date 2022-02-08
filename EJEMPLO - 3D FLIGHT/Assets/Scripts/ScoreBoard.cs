using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    public void IncreaseScore(int valueToIncrease)
    {
        score += valueToIncrease;
        Debug.Log(score);
    }
}
