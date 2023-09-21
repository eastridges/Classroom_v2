using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    // To change this, need to attach a custom 3D Line Renderer script to the prefab instead of a LineRenderer script.
    //If we name functions and variables correctly, we shouldn't have to change much in this script
    public InputReader inputs;
    public GameObject Line;
    public Transform Pointer;
    public Transform Drawings;

    private LineRenderer drawLine;
    private List<Vector3> linePoints;
    public float lineWidth = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        linePoints = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {

        //Draw some lines
        if (inputs.RightMainTriggerDown)
        {
            linePoints.Clear();
            makeNewLine();
            drawLine.startWidth = lineWidth;
        }
        else if (inputs.RightMainTrigger)
        {
            linePoints.Add(Pointer.position);
            drawLine.positionCount = linePoints.Count;
            drawLine.SetPositions(linePoints.ToArray());
        }

        if (lineWidth<1 && inputs.leftJoystick[1]>0)
        {
            lineWidth += inputs.leftJoystick[1]*.005f;
        }
        else if (lineWidth>.01 && inputs.leftJoystick[1]<0)
        {
            lineWidth += inputs.leftJoystick[1]*.005f;
        }


        //Delete lines, most recent first
        if (inputs.ButtonBDown && Drawings.childCount>0)
        {
            Destroy(Drawings.GetChild(Drawings.childCount-1).gameObject);
        }     
    }

    private void makeNewLine()
    {
        GameObject NewLine = Instantiate(Line, Pointer.position, Quaternion.identity);
        NewLine.transform.SetParent(Drawings);
        drawLine = NewLine.GetComponent<LineRenderer>();
    }
}
