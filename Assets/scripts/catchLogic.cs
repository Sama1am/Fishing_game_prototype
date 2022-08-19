using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchLogic : MonoBehaviour
{
    GameManager GM;

    [SerializeField]
    public bool hasFish;

    [SerializeField] public bool hasBait;
    [SerializeField] public int baitNum;

    public GameObject cuaghtFish;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
        hasFish = false;
        baitNum = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(baitNum > 0)
        {
            hasBait = true;
        }
        else if(baitNum <= 0)
        {
            hasBait = false;
            baitNum = 0;
        }
    }

    void addBait()
    {
        hasBait = true;
        baitNum -= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("catchZone"))
        {
            //Debug.Log("IN CATCH ZONE!");
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("pushed the mouse button!");

                if (hasFish)
                {
                    Debug.Log("we have fish will destroy");
                    GM.points += cuaghtFish.GetComponent<fishLogic>().fish.value;
                    cuaghtFish.GetComponent<fishLogic>().isCaught = false;
                    Destroy(cuaghtFish);
                    hasFish = false;
                }

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("obstacle"))
        {
            hasBait = false;
            baitNum -= 1;
            Destroy(collision.gameObject);
        }
    }
}
