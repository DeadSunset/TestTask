using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointClick : MonoBehaviour
{
    public GameObject startCircle;

    [SerializeField]
    private Vector3 _mouseCanvasPosition;
    private Vector3 _mouseClickPosition;
    private Vector3 _previousMouseClickPosition;

    void Start()
    {
        _previousMouseClickPosition = new Vector3(0,0,0);
    }

    void Update()
    {
        _mouseCanvasPosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            _previousMouseClickPosition = _mouseClickPosition;
            _mouseClickPosition = _mouseCanvasPosition;

            Debug.Log(_previousMouseClickPosition);
            RaycastHit2D hit = Physics2D.Raycast(_mouseClickPosition, startCircle.transform.position);
            Debug.DrawRay(_mouseClickPosition, _previousMouseClickPosition, Color.black, 25f);
            startCircle.transform.position = _mouseClickPosition;
        }

    }
}
