using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    int totalPoint;
    int pointIncreasement;

    public Text pointText;
    void Start()
    {
        pointText.text = totalPoint.ToString();
    }

    public void IncreasePoint(string difficultyLevel)
    {
        if (difficultyLevel.Equals("easy"))
        {
            pointIncreasement = 5;
        }
        else if (difficultyLevel.Equals("medium"))
        {
            pointIncreasement = 10;
        }
        else
        {
            pointIncreasement = 15;
        }

        totalPoint += pointIncreasement;
        pointText.text = totalPoint.ToString();
    }

}
