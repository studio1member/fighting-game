using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManagement : MonoBehaviour
{
    public void Play_Button() { SceneManager.LoadScene("Lobby"); }
}
