using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerManagement : MonoBehaviour
{
    [SerializeField] GameObject choosePanel2P;
    [SerializeField] Text multiplayerText;
    private void Awake()
    {
        Multiplayer();
    }
    public void MutilplayerButton()
    {
        if (PlayerPrefs.GetFloat("Multiplayer") == 0)
        {
            PlayerPrefs.SetFloat("Multiplayer", 1);
            choosePanel2P.SetActive(false);
            multiplayerText.text = "1 người chơi";
        }
        else
        {
            PlayerPrefs.SetFloat("Multiplayer", 0);
            choosePanel2P.SetActive(true);
            multiplayerText.text = "2 người chơi";
        }
    }
    public void Multiplayer()
    {
        if (PlayerPrefs.GetFloat("Multiplayer") == 1)
        {
            choosePanel2P.SetActive(false);
            multiplayerText.text = "1 người chơi";
        }
        else 
        {
            choosePanel2P.SetActive(true);
            multiplayerText.text = "2 người chơi";
        }
    }
}
