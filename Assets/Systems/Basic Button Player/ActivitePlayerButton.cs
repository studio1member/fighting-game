using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivitePlayerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private string selectPlayer;
    private PlayerManagement playerManagement;
    void Start()
    {
        while (!playerManagement){ playerManagement = GameObject.Find(selectPlayer).GetComponent<PlayerManagement>(); }
    }
    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == ("jump Button")) playerManagement.playerMovement.JumpPlayer();
        if (gameObject.name == ("skill 1 Button")) playerManagement.virtualPlayerActivites.skill1_down();
        if (gameObject.name == ("skill 2 Button")) playerManagement.virtualPlayerActivites.skill2_down();
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (gameObject.name == ("skill 1 Button")) playerManagement.virtualPlayerActivites.skill1_up();
        if (gameObject.name == ("skill 2 Button")) playerManagement.virtualPlayerActivites.skill2_up();
    }
   
}
