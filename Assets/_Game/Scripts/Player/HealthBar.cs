using System;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float startValue = 1.0f;
    private float defaultWidth;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        defaultWidth = rectTransform.sizeDelta.x;
        SetValue(startValue);
    }

    public void SetValue(float value)
    {
        // Set the width of the RectTransform based on the startValue and input value
        float newWidth = defaultWidth * value;
        rectTransform.sizeDelta = new Vector2(newWidth, rectTransform.sizeDelta.y);
    }
}