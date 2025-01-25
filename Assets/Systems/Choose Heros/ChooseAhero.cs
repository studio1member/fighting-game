using UnityEngine;

public class ChooseAhero : MonoBehaviour
{
    [SerializeField] string heroChoose, stringKey;
    [SerializeField] int hero;
    public void ChooseHero()
    {
        PlayerPrefs.SetString(stringKey, heroChoose);
        ChooseManagement.instance.heroAwake = true;
        if (hero == 1) ChooseManagement.instance.chooseHero1P.position = transform.position;
        else ChooseManagement.instance.chooseHero2P.position = transform.position;
    }
}
