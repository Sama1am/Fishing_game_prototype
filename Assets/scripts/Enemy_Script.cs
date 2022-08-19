using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public Rigidbody2D enemy;

    public Enemy_Spawner enemy_Spawner;

    
    // Start is called before the first frame update
    void Awake()
    {
        
        enemy_Spawner = FindObjectOfType<Enemy_Spawner>();

        enemy.velocity = enemy_Spawner.currentPoint.transform.TransformDirection(Vector3.right * 10f);
    }

    // Update is called once per frame
    void Update()
    {
        //enemy.AddForce(transform.right * 100f);
    }
}
