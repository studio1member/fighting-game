using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardcontrolsMultiplayer : MonoBehaviour
{
    private PlayerManagement playerManagement;
    [Header("Player 1P")]
    [SerializeField] KeyCode moveLeftPlayer1P = KeyCode.A;
    [SerializeField] KeyCode moveRightPlayer1P = KeyCode.D;
    [SerializeField] string selectPlayer1P = "Player 1P";

    [Header("Activite")]
    [SerializeField] KeyCode jumpPlayer1P = KeyCode.K;
    [SerializeField] KeyCode skill1Player1P = KeyCode.J;
    [SerializeField] KeyCode skill2Player1P = KeyCode.L;

    private PlayerManagement playerManagement2P;
    [Header("Player 2P")]
    [SerializeField] KeyCode moveLeftPlayer2P = KeyCode.LeftArrow;
    [SerializeField] KeyCode moveRightPlayer2P = KeyCode.RightArrow;
    [SerializeField] string selectPlayer2P = "Player 2P";

    [Header("Activite")]
    [SerializeField] KeyCode jumpPlayer2P = KeyCode.Keypad2;
    [SerializeField] KeyCode skill1Player2P = KeyCode.Keypad1;
    [SerializeField] KeyCode skill2Player2P = KeyCode.Keypad3;
    private void Start()
    {
        if (!playerManagement) playerManagement = GameObject.Find(selectPlayer1P).GetComponent<PlayerManagement>();
        if (!playerManagement2P) playerManagement2P = GameObject.Find(selectPlayer2P).GetComponent<PlayerManagement>();
    }
    private void Update()
    {
        Movement();
        Jump();
        Skill_1();
        Skill_2();
        
        Movement2P();
        Jump2P();
        Skill_1_2P();
        Skill_2_2P();
    }
    private void Movement()
    {
        //--Left
        if (Input.GetKey(moveLeftPlayer1P))
        {
            playerManagement.playerMovement.isMove = true;
            playerManagement.playerMovement.speedPlayer = -playerManagement.playerStatus.speedPlayer;

            Vector3 scaleX = playerManagement.transform.localScale;
            scaleX.x = -1;
            playerManagement.transform.localScale = scaleX;
        }
        if (Input.GetKeyUp(moveLeftPlayer1P))
        {
            playerManagement.playerMovement.isMove = false;
            playerManagement.playerAnim.SetBool("run", false);
        }
        //---Right
        if (Input.GetKey(moveRightPlayer1P))
        {
            playerManagement.playerMovement.isMove = true;
            playerManagement.playerMovement.speedPlayer = playerManagement.playerStatus.speedPlayer;

            Vector3 scaleX = playerManagement.transform.localScale;
            scaleX.x = 1;
            playerManagement.transform.localScale = scaleX;
        }
        if (Input.GetKeyUp(moveRightPlayer1P))
        {
            playerManagement.playerMovement.isMove = false;
            playerManagement.playerAnim.SetBool("run", false);
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(jumpPlayer1P))
        {
            playerManagement.playerMovement.JumpPlayer();
        }
    }
    private void Skill_1()
    {
        if (Input.GetKeyDown(skill1Player1P))
        {
            playerManagement.virtualPlayerActivites.skill1_down();
        }
        if (Input.GetKeyUp(skill1Player1P))
        {
            playerManagement.virtualPlayerActivites.skill1_up();
        }
    }
    private void Skill_2()
    {
        if (Input.GetKeyDown(skill2Player1P))
        {
            playerManagement.virtualPlayerActivites.skill2_down();
        }
        if (Input.GetKeyUp(skill2Player1P))
        {
            playerManagement.virtualPlayerActivites.skill2_up();
        }
    }
    private void Movement2P()
    {
        //--Left
        if (Input.GetKey(moveLeftPlayer2P))
        {
            playerManagement2P.playerMovement.isMove = true;
            playerManagement2P.playerMovement.speedPlayer = -playerManagement.playerStatus.speedPlayer;

            Vector3 scaleX = playerManagement.transform.localScale;
            scaleX.x = -1;
            playerManagement2P.transform.localScale = scaleX;
        }
        if (Input.GetKeyUp(moveLeftPlayer2P))
        {
            playerManagement2P.playerMovement.isMove = false;
            playerManagement2P.playerAnim.SetBool("run", false);
        }
        //---Right
        if (Input.GetKey(moveRightPlayer2P))
        {
            playerManagement2P.playerMovement.isMove = true;
            playerManagement2P.playerMovement.speedPlayer = playerManagement.playerStatus.speedPlayer;

            Vector3 scaleX = playerManagement.transform.localScale;
            scaleX.x = 1;
            playerManagement2P.transform.localScale = scaleX;
        }
        if (Input.GetKeyUp(moveRightPlayer2P))
        {
            playerManagement2P.playerMovement.isMove = false;
            playerManagement2P.playerAnim.SetBool("run", false);
        }
    }
    private void Jump2P()
    {
        if (Input.GetKeyDown(jumpPlayer2P))
        {
            playerManagement2P.playerMovement.JumpPlayer();
        }
    }
    private void Skill_1_2P()
    {
        if (Input.GetKeyDown(skill1Player2P))
        {
            playerManagement2P.virtualPlayerActivites.skill1_down();
        }
        if (Input.GetKeyUp(skill1Player2P))
        {
            playerManagement2P.virtualPlayerActivites.skill1_up();
        }
    }
    private void Skill_2_2P()
    {
        if (Input.GetKeyDown(skill2Player2P))
        {
            playerManagement2P.virtualPlayerActivites.skill2_down();
        }
        if (Input.GetKeyUp(skill2Player2P))
        {
            playerManagement2P.virtualPlayerActivites.skill2_up();
        }
    }
}

