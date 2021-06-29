using UnityEngine;

public class CircleMove : MonoBehaviour
{
    public PointClick point;
    public textChange change;
    private float startTime;
    private float journeyLength;
    private LineRenderer _lineRenderer;
    private LineRenderer _line;

    void Start()
    {
        startTime = Time.time;
        journeyLength = 0;
    }

    void Update()
    {
        if (point.points.Count > 1)
        {
            for (int i = 0; i < point.points.Count - 1; i++)
            {
                if (_line == null)
                {
                    _line = point.createLine(point.points[i], point.points[i + 1], _lineRenderer);
                }
            }
            if (journeyLength == 0) journeyLength = Vector3.Distance(point.points[0], point.points[1]);
            float distCovered = (Time.time - startTime) * change.speedValueSlider.value * 1000;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(point.points[0], point.points[1], fractionOfJourney);
            if (fractionOfJourney > 1)
            {
                journeyLength = 0;
                startTime = Time.time;
                point.points.RemoveAt(0);
                Destroy(_line.gameObject);
                _lineRenderer = null;
            }
        }
        else
        {
            startTime = Time.time;
            journeyLength = 0;
        }
    }
}
