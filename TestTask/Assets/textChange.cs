using UnityEngine;
using UnityEngine.UI;

public class textChange : MonoBehaviour
{
    public Slider speedValueSlider;
    private Text _movementSpeedText;
    private string _speedValue;

    private void Start()
    {
        _movementSpeedText = gameObject.GetComponent<Text>();
        _speedValue = System.Convert.ToString(System.Math.Round(speedValueSlider.value, 2) * 100);
        _movementSpeedText.text = "�������� ��������: " + _speedValue;
    }

    public void newText()
    {
        _speedValue = System.Convert.ToString(System.Math.Round(speedValueSlider.value, 2) * 100);
        _movementSpeedText.text = "�������� ��������: " + _speedValue;
    }
}
