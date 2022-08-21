using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] public float points;

    [SerializeField] private TextMeshProUGUI _scoreTxt;
    [SerializeField] private TextMeshProUGUI _baitTxt;

    [SerializeField] private int baitCost;

    catchLogic CL;

    // Start is called before the first frame update
    void Start()
    {
        points = 0f;
        CL = GameObject.FindGameObjectWithTag("hook").GetComponent<catchLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        setScoreUI();
        setbaitUi();
        gameOver();
    }


    void setScoreUI()
    {
        _scoreTxt.text = "Score: " + points.ToString();
    }

    void setbaitUi()
    {
        _baitTxt.text = CL.baitNum.ToString();
    }


    public void buyBait()
    {
        if(points >= baitCost)
        {
            //buy bait 
            points -= baitCost;
            CL.baitNum++; 
        }
    }

    public void gameOver()
    {
        if((points >= 0) && (CL.baitNum >= 0) && (CL.hasBait == false))
        {
            SceneManager.LoadScene(2);
        }
    }
}
