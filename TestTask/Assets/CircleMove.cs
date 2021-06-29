using UnityEngine;

public class CircleMove : MonoBehaviour
{
    public PointClick point;
    public TextChange change;

    private float _startTime;
    private float _journeyLength;
    private LineRenderer _line;
    private float _fractionOfJourney = 0;
    private float _distCovered = 0;

    void Start()
    {
        ResetPoint();
    }

    void Update()
    {
        if (point.points.Count > 1)
        {
            for (int i = 0; i < point.points.Count - 1; i++)
            {
                if (_line == null)
                {
                    _line = point.CreateLine(point.points[i], point.points[i + 1], _line);
                }
            }
            if (_journeyLength == 0)
            {
                _journeyLength = Vector3.Distance(point.points[0], point.points[1]);
            }
            _fractionOfJourney = CountDistance();
            if (_fractionOfJourney > 1)
            {
                ResetPoint();
                point.points.RemoveAt(0);
                Destroy(_line.gameObject);
            }
        }
        else
        {
            ResetPoint();
        }
    }

    private void ResetPoint()
    {
        _startTime = Time.time;
        _journeyLength = 0;
    }
    private float CountDistance()
    {
        _distCovered = (Time.time - _startTime) * change.speedValueSlider.value * 1000;
        _fractionOfJourney = _distCovered / _journeyLength;
        transform.position = Vector3.Lerp(point.points[0], point.points[1], _fractionOfJourney);
        return _fractionOfJourney;
    }
}
