using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchLogic : MonoBehaviour
{
    GameManager GM;

    [SerializeField]
    public bool hasFish;

    [SerializeField] public bool hasBait;

    public GameObject cuaghtFish;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
        hasFish = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
