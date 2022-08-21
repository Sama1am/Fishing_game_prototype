using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishLogic : MonoBehaviour
{

    [SerializeField] public fish fish;
    [SerializeField] private bool _isOther;
    

    public bool isCaught;

    private GameObject hook;

    private GameObject catchZone;

    [SerializeField] private LayerMask fishLayer;

    // Start is called before the first frame update
    void Start()
    {
        catchZone = GameObject.FindGameObjectWithTag("catchZone");
        Physics.IgnoreLayerCollision(fishLayer, fishLayer, true);
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(fishLayer, fishLayer, true);
        if (isCaught)
        {
            gameObject.transform.position = new Vector3(0f, hook.transform.position.y, 0f);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("hook"))
        {
            if(collision.gameObject.GetComponent<catchLogic>().hasFish == false)
            {
                if (collision.gameObject.GetComponent<catchLogic>().hasBait == true)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    if (!_isOther)
                    {
                        gameObject.transform.eulerAngles = new Vector3(0f, 0f, -90f);
                    }
                    //Debug.Log("collided with fish!");

                    isCaught = true;
                    gameObject.transform.position = new Vector3(0f, collision.gameObject.transform.position.y, 0f);
                    hook = collision.gameObject;
                    collision.gameObject.GetComponent<catchLogic>().hasFish = true;
                    collision.gameObject.GetComponent<catchLogic>().cuaghtFish = this.gameObject;
                    
                }
            }
            


        }
    }



}
