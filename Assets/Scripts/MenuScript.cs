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
    private const String configFilename = "Assets/Files/config.json";

    void Start()
    {
        isShown = content.activeInHierarchy;
        ToggleMenu(isShown);
        if (LoadSettings())// пріорітет файлу -- меню змінюємо під нього
        {
            controlWToggle.isOn = GameState.isWkeyEnabled;
            pipePeriodSlider.value = (6f - GameState.pipePeriod) / (6f - 2f);
            vitalitySlider.value = GameState.vitalitySpeed;
        }
        else // пріорітет меню -- GameState визначаємо з нього
        {
            GameState.isWkeyEnabled = controlWToggle.isOn;
            SetPipePeriod(pipePeriodSlider.value);
            SetVitalitySpeed(vitalitySlider.value);
        }
       
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

    public void SaveSettings()
    {
        System.IO.File.WriteAllText(configFilename, GameState.toJson());
    }
    public bool LoadSettings()
    {
        if (System.IO.File.Exists(configFilename))
        {
            GameState.FromJson(
                System.IO.File.ReadAllText(configFilename));
            return true;
        }
        return false;
    }

    // event handlers
    public void ClosedButtonClick()
    {
        ToggleMenu(false);
    }
    public void ControlWKeyToggleChanged(Boolean value)
    {
        GameState.isWkeyEnabled = value;
        SaveSettings();
    }
    public void PipePeriodSliderChanged(Single value)
    {
        SetPipePeriod(value);
    }
    public void VitalitySpeedSliderChanged(Single value)
    {
        SetVitalitySpeed(value);
    }
    private void SetVitalitySpeed(Single sliderValue)
    {
        GameState.vitalitySpeed = sliderValue;
    }
    private void SetPipePeriod(Single sliderValue)
    {
        // масштабуємо sliderValue(0..1) до потрібного діапазону (2..6)
        GameState.pipePeriod = 6f - (6f - 2f) * sliderValue;
        SaveSettings();
    }
}
