using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementPlayerButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerManagement playerManagement;
    [SerializeField] string selectPlayer;
    [SerializeField] bool changeDirectionLeft = true;
    [SerializeField] bool changeDirectionRight = true;
    private void Start()
    {
        playerManagement = GameObject.Find(selectPlayer).GetComponent<PlayerManagement>();
    }
    public void OnPointerDown(PointerEventData data)
    {
        if(gameObject.name == "left move Button")
        {
            changeDirectionLeft = false;

            playerManagement.playerMovement.isMove = true;
            playerManagement.playerMovement.speedPlayer = -playerManagement.playerStatus.speedPlayer;

            Vector3 scaleX = playerManagement.transform.localScale;
            scaleX.x = -1;
            playerManagement.transform.localScale = scaleX;
        }
        if (gameObject.name == "right move Button")
        {
            changeDirectionRight = false;

            playerManagement.playerMovement.isMove = true;
            playerManagement.playerMovement.speedPlayer = playerManagement.playerStatus.speedPlayer;

            Vector3 scaleX = playerManagement.transform.localScale;
            scaleX.x = 1;
            playerManagement.transform.localScale = scaleX;
        }
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (gameObject.name == "left move Button") changeDirectionLeft = true;
        if (gameObject.name == "right move Button") changeDirectionRight = true;
        if (changeDirectionLeft && changeDirectionRight)
        {
            changeDirectionLeft = true;
            changeDirectionRight = true;
            playerManagement.playerMovement.isMove = false;
            playerManagement.playerAnim.SetBool("run", false);
        }
    }
}
