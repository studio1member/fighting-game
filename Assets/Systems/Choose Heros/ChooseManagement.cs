using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseManagement : MonoBehaviour
{
    public static ChooseManagement instance;
    public string mapChoose;
    private bool isShowChooseMapPanel;
    private GameObject chooseMapsPanel;
    public Transform chooseHero1P, chooseHero2P, chooseMap;
    public bool heroAwake;
    private void Awake()
    { 
        instance = this;
        chooseMap = GameObject.Find("Choose Map Image").transform;
        chooseMapsPanel = GameObject.Find("Choose Maps Panel");
        chooseMapsPanel.SetActive(false);
        chooseHero1P = GameObject.Find("Choose Hero 1P Image").transform;
        chooseHero2P = GameObject.Find("Choose Hero 2P Image").transform;
    }
    public void PlayGame()
    {
        if (!heroAwake) Debug.Log("Chọn tướng");
        if (mapChoose == "") Debug.Log("Chọn map");
        else 
        {
            if (heroAwake) SceneManager.LoadScene(mapChoose);
        }
    }
    public void ChooseMap()
    {
        if (!isShowChooseMapPanel)
        {
            isShowChooseMapPanel = true;
            chooseMapsPanel.SetActive(true);
        }
        else
        {
            isShowChooseMapPanel = false;
            chooseMapsPanel.SetActive(false);
        }
    }
}
