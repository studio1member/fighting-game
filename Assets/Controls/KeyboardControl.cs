using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControl : MonoBehaviour
{
    private PlayerManagement playerManagement;
    [Header("Movement")]
    [SerializeField] KeyCode moveLeft = KeyCode.A;
    [SerializeField] KeyCode moveRight = KeyCode.D;
    [SerializeField] string selectPlayer = "Player 1P";

    [Header("Activite")]
    [SerializeField] KeyCode jump = KeyCode.K;
    [SerializeField] KeyCode skill1 = KeyCode.J;
    [SerializeField] KeyCode skill2 = KeyCode.L;
    private void Start()
    {
        if (!playerManagement) playerManagement = GameObject.Find(selectPlayer).GetComponent<PlayerManagement>();
    }
    private void Update()
    {
        Movement();
        Jump();
        Skill_1();  
        Skill_2();
    }
    private void Movement()
    {
        //--Left
        if (Input.GetKey(moveLeft))
        {
            playerManagement.playerMovement.isMove = true;
            playerManagement.playerMovement.speedPlayer = -playerManagement.playerStatus.speedPlayer;

            Vector3 scaleX = playerManagement.transform.localScale;
            scaleX.x = -1;
            playerManagement.transform.localScale = scaleX;
        }
        if (Input.GetKeyUp(moveLeft))
        {
            playerManagement.playerMovement.isMove = false;
            playerManagement.playerAnim.SetBool("run", false);
        }
        //---Right
        if (Input.GetKey(moveRight))
        {
            playerManagement.playerMovement.isMove = true;
            playerManagement.playerMovement.speedPlayer = playerManagement.playerStatus.speedPlayer;

            Vector3 scaleX = playerManagement.transform.localScale;
            scaleX.x = 1;
            playerManagement.transform.localScale = scaleX;
        }
        if (Input.GetKeyUp(moveRight))
        {
            playerManagement.playerMovement.isMove = false;
            playerManagement.playerAnim.SetBool("run", false);
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(jump))
        {
            playerManagement.playerMovement.JumpPlayer();
        }
    }
    private void Skill_1()
    {
        if (Input.GetKeyDown(skill1))
        {
            playerManagement.virtualPlayerActivites.skill1_down();
        }
        if (Input.GetKeyUp(skill1))
        {
            playerManagement.virtualPlayerActivites.skill1_up();
        }
    }
    private void Skill_2()
    {
        if (Input.GetKeyDown(skill2))
        {
            playerManagement.virtualPlayerActivites.skill2_down();
        }
        if (Input.GetKeyUp(skill2))
        {
            playerManagement.virtualPlayerActivites.skill2_up();
        }
    }
}
