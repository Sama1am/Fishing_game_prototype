using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineLogic : MonoBehaviour
{

    [SerializeField]
    private LineRenderer LR;

    
    public Transform[] points;

    [SerializeField] public Transform topLine;
    [SerializeField] Transform[] linePoint;
    [SerializeField] GameObject hook;
    [SerializeField] private float _interp;
    [SerializeField] private float _speed;
    
    private float _timeElapsed;
    private float _time;

    public bool isCut;
    
    
    // Start is called before the first frame update
    void Start()
    {
        LR = GetComponent<LineRenderer>();
        setUpLine(linePoint);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            LR.SetPosition(i, points[i].position);
        }

        //inputControl();
        pcControls();
        //touchControls();
    }

    //sets up the line render and its points
    public void setUpLine(Transform[] points)
    {
        LR.positionCount = points.Length;
        this.points = points;
    }

    //gets the position of the mouse and then sets the hook to its y postion 
    

    void pcControls()
    {
        if(Input.GetMouseButton(0))
        {
            if(!isCut)
            {
                var currentPos = hook.transform.position;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                //hook.transform.position = new Vector3(transform.position.x, worldPosition.y, transform.position.z);

                if (_time > 1)
                {
                    _time = 1;
                }

                hook.transform.position = Vector3.Lerp(new Vector3(0f, currentPos.y, 0f), new Vector3(0f, worldPosition.y, 0f), _time);
                _time += Time.deltaTime / _interp;


                //clamps the y position of the hook so it cant go above a certain point or below a certain point
                hook.transform.position = new Vector3(transform.position.x, Mathf.Clamp(hook.transform.position.y, -7.1f, 4.15f), transform.position.z);
                _timeElapsed = 0;
            }
            
        }
        else if((transform.position.y < points[0].position.y))
        {
            var currentPos = hook.transform.position;
            //hook.transform.position = points[0].transform.position;

           // var dir = (points[0].position - hook.transform.position).normalized;

            //hook.transform.position += dir * _speed * Time.deltaTime;
            if(_timeElapsed > 1)
            {
                _timeElapsed = 1;
            }
            hook.transform.position = Vector3.Lerp(currentPos, topLine.transform.position, _timeElapsed);


            //hook.transform.position = new Vector3(transform.position.x, transform.position.y + (Time.deltaTime*rate), transform.position.z);
            _timeElapsed += Time.deltaTime / _interp;
            _time = 0;
        }else if (Input.GetMouseButtonUp(0))
        {
            _timeElapsed = 0;
            _time = 0;
        }
    }

    void touchControls()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                if(touch.phase == TouchPhase.Moved)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    //float ypos = transform.position.y;
                    hook.transform.position = new Vector3(transform.position.x, worldPosition.y, transform.position.z);
                    //clamps the y position of the hook so it cant go above a certain point or below a certain point
                    hook.transform.position = new Vector3(transform.position.x, Mathf.Clamp(hook.transform.position.y, -4.61f, 1.85f), transform.position.z);
                    _timeElapsed = 0;
                }
            }
            else if ((transform.position.y < points[0].position.y))
            {
                var currentPos = hook.transform.position;
                //hook.transform.position = points[0].transform.position;

                // var dir = (points[0].position - hook.transform.position).normalized;

                //hook.transform.position += dir * _speed * Time.deltaTime;
                if (_timeElapsed > 1)
                {
                    _timeElapsed = 1;
                }
                hook.transform.position = Vector3.Lerp(currentPos, points[0].position, _timeElapsed);


                //hook.transform.position = new Vector3(transform.position.x, transform.position.y + (Time.deltaTime*rate), transform.position.z);
                _timeElapsed += Time.deltaTime / _interp;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _timeElapsed = 0;
            }
        }

       
    }
}
