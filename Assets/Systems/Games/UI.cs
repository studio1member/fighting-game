using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("Setting Panel")]
    private GameObject settingPanel;
    [SerializeField] private bool switchSettingPanel;

    [Header("Controller")]
    private ControlManagement controlManagement;
    [SerializeField] private Image controllerWorksImage;
    [SerializeField] private Image controllerButtonWorksImage;
    private Color color = Color.white;
    private void Awake()
    {
        settingPanel = GameObject.Find("Setting Panel");
        settingPanel.SetActive(false);

        controlManagement = GameObject.Find("GameManagement").GetComponent<ControlManagement>();
        AwakeControllerWorks();
        AwakeControllerButtonWorks();
    }
    public void SettingPanel()
    {
        if (switchSettingPanel)
        {
            switchSettingPanel = false;
            settingPanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            switchSettingPanel = true;
            settingPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ControllerWorks() 
    {
        if (PlayerPrefs.GetInt("ControllerWorks") == 0)
        {
            PlayerPrefs.SetInt("ControllerWorks", 1);
            color.a = 1f;
            controllerWorksImage.color = color;
            if (controlManagement.controller) controlManagement.controller.SetActive(true);
            if (controlManagement.controllerMultiplayer) controlManagement.controllerMultiplayer.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("ControllerWorks", 0);
            color.a = 0f;
            controllerWorksImage.color = color;
            if (controlManagement.controller) controlManagement.controller.SetActive(false);
            if (controlManagement.controllerMultiplayer) controlManagement.controllerMultiplayer.SetActive(false);
        }
    }
    private void AwakeControllerWorks()
    {
        if (PlayerPrefs.GetInt("ControllerWorks") == 1)
        {
            color.a = 1f;
            controllerWorksImage.color = color;
            if (controlManagement.controller) controlManagement.controller.SetActive(true);
            if (controlManagement.controllerMultiplayer) controlManagement.controllerMultiplayer.SetActive(true);
        }
        else
        {
            color.a = 0f;
            controllerWorksImage.color = color;
            if (controlManagement.controller) controlManagement.controller.SetActive(false);
            if (controlManagement.controllerMultiplayer) controlManagement.controllerMultiplayer.SetActive(false);
        }
    }
    public void ControllerButtonWorks() 
    {
        if (PlayerPrefs.GetInt("ControllerButtonWorks") == 0)
        {
            PlayerPrefs.SetInt("ControllerButtonWorks", 1);
            color.a = 1f;
            controllerButtonWorksImage.color = color;
            if (controlManagement.controllerButton) controlManagement.controllerButton.SetActive(true);
            if (controlManagement.controllerButtonMultiplayer) controlManagement.controllerButtonMultiplayer.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("ControllerButtonWorks", 0);
            color.a = 0f;
            controllerButtonWorksImage.color = color;
            if (controlManagement.controllerButton) controlManagement.controllerButton.SetActive(false);
            if (controlManagement.controllerButtonMultiplayer) controlManagement.controllerButtonMultiplayer.SetActive(false);
        }
    }
    public void AwakeControllerButtonWorks() 
    {
        if (PlayerPrefs.GetInt("ControllerButtonWorks") == 1)
        {
            color.a = 1f;
            controllerButtonWorksImage.color = color;
            if (controlManagement.controllerButton) controlManagement.controllerButton.SetActive(true);
            if (controlManagement.controllerButtonMultiplayer) controlManagement.controllerButtonMultiplayer.SetActive(true);
        }
        else
        {
            color.a = 0f;
            controllerButtonWorksImage.color = color;
            if (controlManagement.controllerButton) controlManagement.controllerButton.SetActive(false);
            if (controlManagement.controllerButtonMultiplayer) controlManagement.controllerButtonMultiplayer.SetActive(false);
        }
    }
}
