using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishLogic : MonoBehaviour
{

    [SerializeField] public fish fish;

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
        if(isCaught)
        {
            gameObject.transform.position = new Vector3(0f, hook.transform.position.y, 0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("hook"))
        {
            if(collision.gameObject.GetComponent<catchLogic>().hasBait == true)
            {
                Debug.Log("collided with fish!");
                //gameObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                gameObject.transform.eulerAngles = new Vector3(0f, 0f, -90f);
                isCaught = true;
                gameObject.transform.position = new Vector3(0f, collision.gameObject.transform.position.y, 0f);
                hook = collision.gameObject;
                collision.gameObject.GetComponent<catchLogic>().hasFish = true;
                collision.gameObject.GetComponent<catchLogic>().cuaghtFish = this.gameObject;
            }
           
            
        }
    }


    
}
