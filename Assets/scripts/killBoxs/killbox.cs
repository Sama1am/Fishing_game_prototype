using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killbox : MonoBehaviour
{

    [SerializeField] private GameObject crabSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.CompareTag("fish")) || (collision.gameObject.CompareTag("obstacle")))
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("crab"))
        {
            crabSpawner.GetComponent<Enemy_Spawner>().spawnedCrab = false;
            Destroy(collision.gameObject);
        }

    }
}
