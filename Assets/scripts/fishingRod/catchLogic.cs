using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class catchLogic : MonoBehaviour
{
    GameManager GM;

    [SerializeField] public bool hasFish;
    [SerializeField] public bool hasBait;
    [SerializeField] public int baitNum;
    [SerializeField] private Transform _catchZone;
    [SerializeField] private SpriteRenderer _SR;
    [SerializeField] private Sprite[] _hookSprites;

    #region SoundStuff
    [Header("sound stuff")]
    [SerializeField] private AudioSource _AS;
    [SerializeField] private AudioClip _catchSound;
    #endregion


    public GameObject cuaghtFish;
    private GameObject _Line;

    #region QTE
    [SerializeField] private float _numNeeded;
    [SerializeField] private float _currentNum;
    [SerializeField] private float _time;
    [SerializeField] private float _currentTime;



    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _Line = GameObject.FindGameObjectWithTag("line");
        hasFish = false;
        hasBait = true;
        GM = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
        hasFish = false;
        baitNum = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(hasFish)
        {
            Physics2D.IgnoreLayerCollision(6, 3, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(6, 3, false);
        }
        //catchFish();
    }

    public void addBait()
    {
        if(!hasBait)
        {
            _Line.GetComponent<LineLogic>().isCut = false;
            hasBait = true;
            baitNum -= 1;
            _SR.sprite = _hookSprites[1];
            Debug.Log("SHOULD CHANGE HOOK SPRITE");
        }
       
    }


    public void quickTimeEvent()
    {
        _currentTime = _time;
        _currentTime -= Time.deltaTime;

        if(Input.GetMouseButtonDown(0))
        {
            _currentNum++;
        }

        if((_currentTime <= 0) && (_currentNum >= _numNeeded))
        {
            //win 
        }
        else if((_currentTime <= 0) && (_currentNum < _numNeeded))
        {
            //loose 
        }
    }


    public void catchFish()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            //Physics.Raycast(ray, out hit);

            if (Physics.Raycast(ray, out hit, 100))
            {

                if (hit.collider.tag == "catchZone")
                {
                    if(hasFish)
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



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            if(hasFish)
            {
                hasBait = false;
                //Destroy(collision.gameObject);
                Destroy(cuaghtFish);
                hasFish = false;
                _SR.sprite = _hookSprites[0];
               
            }
            else
            {
                hasBait = false;
                //Destroy(collision.gameObject);
                _SR.sprite = _hookSprites[0];
            }
        }

        if(collision.CompareTag("bomb"))
        {
            //game over 
            GM.endScene();

        }
           

        if (collision.gameObject.CompareTag("catchZone"))
        {
            if (hasFish)
            {
                Debug.Log("we have fish will destroy");
                _AS.PlayOneShot(_catchSound, 1f);
                GM.points += cuaghtFish.GetComponent<fishLogic>().fish.value;
                cuaghtFish.GetComponent<fishLogic>().isCaught = false;
                Destroy(cuaghtFish);
                hasFish = false;
            }
        }
    }

    
}
