using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{

    public GameObject gameManager;
    private LineRenderer drawLine;
    private Vector3[] linePoints;


    // Start is called before the first frame update
    void Start()
    {
        linePoints=new Vector3[2];
        drawLine=GetComponent<LineRenderer>();
        drawLine.startWidth=gameManager.GetComponent<LineDrawer>().lineWidth; 
        linePoints[0]=this.transform.position;
        linePoints[1]=this.transform.position;
        drawLine.SetPositions(linePoints);
    }

    // Update is called once per frame
    void Update()
    {
        drawLine.startWidth=gameManager.GetComponent<LineDrawer>().lineWidth;
        drawLine=GetComponent<LineRenderer>();
        linePoints[0]=this.transform.position;
        linePoints[1]=this.transform.position;
        drawLine.SetPositions(linePoints);
    }
}
