using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerStatus playerStatus;
    public VirtualPlayerActivites virtualPlayerActivites;

    public Transform playerName;

    public Rigidbody2D playerRig;
    public Animator playerAnim;

    private void Awake()
    {
        if (!playerMovement) playerMovement = GetComponent<PlayerMovement>();
        if (!playerStatus) playerStatus = GetComponent<PlayerStatus>();
        if (!virtualPlayerActivites) virtualPlayerActivites = GetComponent<VirtualPlayerActivites>();
        if (!playerRig) playerRig = GetComponent<Rigidbody2D>();
        playerRig.freezeRotation = true;
        if (!playerAnim)
        {
            foreach(Transform check in transform)
            {
                if (playerAnim) return;
                playerAnim = check.GetComponent<Animator>();
            }
        }
    }
}
