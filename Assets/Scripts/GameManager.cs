using DG.Tweening;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    GameObject initialSquare;
    public GameObject squarePrefab;
    public GameObject resultPanel;
    public GameObject[] squares = new GameObject[25];
    public Transform questionPanel;
    public Transform squarePanel;
    public Text questionText;
    public Sprite[] sprites = new Sprite[5];

    List<int> division = new List<int>();

    int dividend, divider;
    int questionNumber;
    int buttonValue;
    int result;
    int right;

    bool buttonClickable;

    string difficultyLevel;

    RightManager rightManager;
    PointManager pointManager;
    private void Awake()
    {
        right = 3;

        resultPanel.GetComponent<RectTransform>().localScale = Vector3.zero;

        rightManager = Object.FindObjectOfType<RightManager>();
        pointManager = Object.FindObjectOfType<PointManager>();
        rightManager.CheckRights(right);
    }
    void Start()
    {
       
        questionPanel.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        CreateSquares();
    }

    public void CreateSquares()
    {
        for(int i = 0; i < 25; i++)
        {
            GameObject square = Instantiate(squarePrefab, squarePanel);
            square.transform.GetChild(1).GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
            square.transform.GetComponent<Button>().onClick.AddListener(() => ButtonClicked());
            squares[i] = square;
        }
        DivisionToText();
        StartCoroutine(DoFadeRoutine());
        Invoke("OpenQuestionPanel", 2.5f);
    }

    void ButtonClicked()
    {
        if (buttonClickable)
        {
            buttonValue = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            initialSquare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            CheckResult();
        }
    }


    IEnumerator DoFadeRoutine()
    {
        for(int i = 0;i< squares.Length; i++)
        {
            squares[i].GetComponent<CanvasGroup>().DOFade(1, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }


    void DivisionToText()
    {
        var rand = new System.Random();
        foreach(var square in squares)
        {
            int randomNumber = rand.Next(1,13);
            division.Add(randomNumber);
            square.transform.GetChild(0).GetComponent<Text>().text = randomNumber.ToString();
        }
    }


    void OpenQuestionPanel()
    {
        Question();
        buttonClickable = true;
        questionPanel.GetComponent<RectTransform>().DOScale(1, 0.5f);
    }


    void Question()
    {
        divider = Random.Range(2, 11);
        questionNumber = Random.Range(0, division.Count-1);
        result = division[questionNumber];
        dividend = divider * result;

        if (dividend<=40)
        {
            difficultyLevel = "easy";
        }
        else if (dividend<=80)
        {
            difficultyLevel = "medium";
        }
        else
        {
            difficultyLevel = "hard";
        }
        questionText.text = dividend.ToString() + " : " + divider.ToString();
    }


    void CheckResult()
    {
        if(buttonValue == result)
        {
            initialSquare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            initialSquare.transform.GetChild(0).GetComponent<Text>().enabled = false;
            initialSquare.transform.GetComponent<Button>().interactable = false;

            pointManager.IncreasePoint(difficultyLevel);

            division.RemoveAt(questionNumber);
            if (division.Count>0)
            {
                Question();
            }
            else
            {
                GameOver();
            }
        }
        else
        {
            right--;
            rightManager.CheckRights(right);
        }

        if (right<=0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        buttonClickable = false;
        resultPanel.GetComponent<RectTransform>().DOScale(1, 0.5f);
    }
}
