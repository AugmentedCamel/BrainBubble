using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public GameObject linePrefab; // Assign a LineRenderer prefab in the inspector
    public List<Line> Lines { get; private set; } = new List<Line>();

    public Line CreateLine(Transform startPoint, Transform endPoint)
    {
        GameObject lineObject = Instantiate(linePrefab);
        LineRenderer lineRenderer = lineObject.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);

        Line line = new Line
        {
            LineRenderer = lineRenderer,
            StartPoint = startPoint,
            EndPoint = endPoint
        };

        Lines.Add(line);

        return line;
    }
    
    public void RemoveLine(Line line)
    {
        Lines.Remove(line);
    }
    
    void Update()
    {
        foreach (var line in Lines)
        {
            line.LineRenderer.SetPosition(0, line.StartPoint.position);
            line.LineRenderer.SetPosition(1, line.EndPoint.position);
        }
    }
}