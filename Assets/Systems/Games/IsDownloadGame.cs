using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDownloadGame : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("IsDownloadGame"))
        {
            PlayerPrefs.SetInt("IsDownloadGame", 1);
            PlayerPrefs.SetInt("ControllerButtonWorks", 1);
            PlayerPrefs.SetInt("ControllerWorks", 1);
            PlayerPrefs.SetInt("ControllerWorks", 1);
            PlayerPrefs.SetFloat("Max HP Player 1P", 100f);
            PlayerPrefs.SetFloat("Max HP Player 2P", 100f);
            PlayerPrefs.SetInt("Level Player 1P", 1);
            PlayerPrefs.SetInt("Level Player 2P", 1);
            PlayerPrefs.SetFloat("Requires XP Player 1P", 20f);
            PlayerPrefs.SetFloat("Requires XP Player 2P", 20f);
            PlayerPrefs.SetFloat("Damage Player 1P", 10f);
            PlayerPrefs.SetFloat("Damage Player 2P", 10f);
        }
    }
}
