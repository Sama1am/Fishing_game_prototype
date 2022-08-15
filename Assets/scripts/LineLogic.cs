using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLogic : MonoBehaviour
{

    [SerializeField]
    private LineRenderer LR;

    
    private Transform[] points;

    [SerializeField] Transform[] linePoint;
    [SerializeField] GameObject hook;

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

        inputControl();
    }

    //sets up the line render and its points
    public void setUpLine(Transform[] points)
    {
        LR.positionCount = points.Length;
        this.points = points;
    }

    //gets the position of the mouse and then sets the hook to its y postion 
    void inputControl()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float ypos = transform.position.y;
        hook.transform.position = new Vector3(transform.position.x, worldPosition.y, transform.position.z);
        //clamps the y position of the hook so it cant go above a certain point or below a certain point
        hook.transform.position = new Vector3(transform.position.x, Mathf.Clamp(hook.transform.position.y, -4.61f, 1.85f), transform.position.z);
    }
}
