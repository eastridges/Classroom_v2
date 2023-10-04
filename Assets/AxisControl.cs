using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisControl : MonoBehaviour
{
    public float lineWidth;
    public float lineLength;
    public LineRenderer drawX;
    public LineRenderer drawY;
    public LineRenderer drawZ;
    public Color axisColor;

    private List<Vector3> linePoints;

    // Start is called before the first frame update
    void Start()
    {
        axisColor = new Color(0.9f,1,0.1f,1);
        linePoints = new List<Vector3>();
        lineWidth=0.01f;
        lineLength=0.8f;
        drawX=this.transform.GetChild(0).GetComponent<LineRenderer>();
        drawY=this.transform.GetChild(1).GetComponent<LineRenderer>();
        drawZ=this.transform.GetChild(2).GetComponent<LineRenderer>();
        drawX.startWidth=lineWidth;
        drawY.startWidth=lineWidth;
        drawZ.startWidth=lineWidth;
        drawX.startColor=axisColor;
        drawY.startColor=axisColor;
        drawZ.startColor=axisColor;
        drawX.endColor=axisColor;
        drawY.endColor=axisColor;
        drawZ.endColor=axisColor;
        linePoints.Clear();
        linePoints.Add(new Vector3(-lineLength,0,0));
        linePoints.Add(new Vector3(lineLength,0,0));
        drawX.SetPositions(linePoints.ToArray());
        linePoints.Clear();
        linePoints.Add(new Vector3(0,0,-lineLength));
        linePoints.Add(new Vector3(0,0,lineLength));
        drawY.SetPositions(linePoints.ToArray());
        linePoints.Clear();
        linePoints.Add(new Vector3(0,-lineLength,0));
        linePoints.Add(new Vector3(0,lineLength,0));
        drawZ.SetPositions(linePoints.ToArray());
        drawX.useWorldSpace=false;
        drawY.useWorldSpace=false;
        drawZ.useWorldSpace=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVariables()
    {
        lineWidth=0.01f;
        lineLength=0.8f;
    }
}
