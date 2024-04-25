using UnityEngine;

public class Line
{
    public LineRenderer LineRenderer { get; set; }
    public Transform StartPoint { get; set; }
    public Transform EndPoint { get; set; }

    public void DestroyLine()
    {
        GameObject.Destroy(LineRenderer.gameObject);
    }
    
    public void SetEndPoint(Transform endPoint)
    {
        EndPoint = endPoint;
    }
    
}
