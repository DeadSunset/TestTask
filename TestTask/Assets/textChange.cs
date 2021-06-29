using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    public Slider speedValueSlider;

    private Text _movementSpeedText;
    private string _speedValue;

    private void Start()
    {
        _movementSpeedText = gameObject.GetComponent<Text>();
        NewText();
    }

    private void NewText()
    {
        _speedValue = System.Convert.ToString(System.Math.Round(speedValueSlider.value, 2) * 100);
        _movementSpeedText.text = "Скорость движения: " + _speedValue;
    }
}
