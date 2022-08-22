using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutLineLogic : MonoBehaviour
{

    private GameObject _hook;
    private GameObject _line;

    [SerializeField] private float dist;
    [SerializeField] private float speed;

    [SerializeField] private float distFromLine;

    private bool _didCutLine;
    // Start is called before the first frame update

  
    void Start()
    {
        _didCutLine = false;
        _hook = GameObject.FindGameObjectWithTag("hook");
        _line = GameObject.FindGameObjectWithTag("line");
    }

    // Update is called once per frame
    void Update()
    {
        distFromLine = Mathf.Abs(gameObject.transform.position.x - _hook.transform.position.x);
       

        if (distFromLine <= dist)
        {
            if(!_didCutLine)
            {
                cutLine();
            }
            

        }
    }

    private void cutLine()
    {
        if(gameObject.transform.position.y > _hook.transform.position.y)
        {
            _hook.GetComponentInChildren<SpriteRenderer>().sprite = null;
            //_hook.GetComponent<SpriteRenderer>().sprite = null;
            _hook.GetComponent<catchLogic>().hasBait = false;
            //_hook.GetComponent<catchLogic>().baitNum -= 1;
            _hook.transform.position = _line.GetComponent<LineLogic>().points[0].transform.position;
            _didCutLine = true;
        }
        
    }
}
