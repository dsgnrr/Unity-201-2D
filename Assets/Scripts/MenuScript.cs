using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private Toggle controlWToggle;
    [SerializeField]
    private Slider pipePeriodSlider;
    [SerializeField]
    private Slider vitalitySlider;
    private bool isShown;

    void Start()
    {
        isShown = content.activeInHierarchy;
        ToggleMenu(isShown);
        GameState.isWkeyEnabled = controlWToggle.isOn;
        SetPipePeriod(pipePeriodSlider.value);
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ToggleMenu(!isShown);
        }
    }

    private void ToggleMenu(bool isDisplay)
    {
        if (isDisplay)
        {
            isShown = true;
            content.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            isShown = false;
            content.SetActive(false);
            Time.timeScale = 1f;
        }
       
    }

    // event handlers
    public void ClosedButtonClick()
    {
        ToggleMenu(false);
    }

    public void ControlWKeyToggleChanged(Boolean value)
    {
        GameState.isWkeyEnabled = value;
    }
    
    public void PipePeriodSliderChanged(Single value)
    {
        SetPipePeriod(value);
    }

    private void SetPipePeriod(Single sliderValue)
    {
        // масштабуємо sliderValue(0..1) до потрібного діапазону (2..6)
        GameState.pipePeriod = 6f - (6f - 2f) * sliderValue;
    }
}
