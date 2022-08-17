using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] public float points;

    [SerializeField] private TextMeshProUGUI scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        points = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        setScoreUI();
    }


    void setScoreUI()
    {
        scoreTxt.text = "Score: " + points.ToString();
    }
}
