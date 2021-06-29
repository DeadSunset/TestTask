using System.Collections.Generic;
using UnityEngine;
public class PointClick : MonoBehaviour
{
    public GameObject startCircle;
    public GameObject point;

    [SerializeField]
    private Vector3 _mouseCanvasPosition;
    private Vector3 _mousePosition;
    private Vector3 _previousMouseClickPosition;

    [SerializeField]
    public List<Vector3> points = new List<Vector3>();


    void Start()
    {
        _mousePosition = startCircle.transform.position;
        points.Add(_mousePosition);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && (Input.mousePosition.y < 880 || Input.mousePosition.x > 660))
        {
            points.Add(Input.mousePosition);
        }
    }

    public LineRenderer createLine(Vector3 start, Vector3 end, LineRenderer line)
    {
        line = new GameObject("Line").AddComponent<LineRenderer>();
        line.material.color = Color.white;
        line.transform.SetParent(gameObject.transform);
        line.startWidth = 3f;
        line.endWidth = 32f;
        line.positionCount = 2;
        line.SetPosition(0, start);
        line.SetPosition(1, end);

        return line;
    }
}
