using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManagement : MonoBehaviour
{
    [Header("Single")]
    public GameObject controller;
    public GameObject controllerButton;

    [Header("Multiplayer")]
    public GameObject controllerMultiplayer;
    public GameObject controllerButtonMultiplayer;
    private void Awake()
    {
        if(PlayerPrefs.GetFloat("Multiplayer") == 1)
        {
            this.controller = Instantiate(this.controller);
            this.controllerButton = Instantiate(this.controllerButton);

            this.controllerMultiplayer = null;
            this.controllerButtonMultiplayer = null;

            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) 
            {
                controller.SetActive(false);
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer)
            {
                controllerButton.SetActive(false);
            }
        }
        else
        {
            this.controllerMultiplayer = Instantiate(this.controllerMultiplayer);
            this.controllerButtonMultiplayer = Instantiate(this.controllerButtonMultiplayer);

            this.controller = null;
            this.controllerButton = null;

            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                controllerMultiplayer.SetActive(false);
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer)
            {
                controllerButtonMultiplayer.SetActive(false);
            }
        }
    }
}
