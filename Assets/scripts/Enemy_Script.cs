using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public Rigidbody2D enemy;

    public Enemy_Spawner enemy_Spawner;
    private float _speed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] public bool isLeft = false;

    // Start is called before the first frame update
    void Awake()
    {
        
        enemy = gameObject.GetComponent<Rigidbody2D>();
        _speed = Random.Range(_minSpeed, _maxSpeed);
        enemy_Spawner = FindObjectOfType<Enemy_Spawner>();

        enemy.velocity = enemy_Spawner.currentPoint.transform.TransformDirection(Vector3.right * _speed);
       
       
    }

    // Update is called once per frame
    void Update()
    {
       if(enemy.velocity.x > 0 && gameObject.transform.rotation.y != -180f)
       {
            Debug.Log("flipping GAME OBJECT!");
            gameObject.transform.eulerAngles = new Vector3(0f, -180f, 0f);
       }
    }
}
