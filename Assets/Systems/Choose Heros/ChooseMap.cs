using UnityEngine;
public class ChooseMap : MonoBehaviour
{
    public string chooseMap;
    public void ChooseMapButton()
    {
        ChooseManagement.instance.mapChoose = this.chooseMap;
        ChooseManagement.instance.chooseMap.position = transform.position;
    }
}
