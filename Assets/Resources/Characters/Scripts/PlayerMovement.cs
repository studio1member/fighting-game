using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerManagement playerManagement;

    public bool isAttack = true;
    public bool isMove;
    public float speedPlayer;

    private void Awake()
    {
        playerManagement = GetComponent<PlayerManagement>();
    }
    private void FixedUpdate()
    {
        if (isMove && isAttack)
        {
            playerManagement.playerRig.velocity = new Vector2(speedPlayer * 100f * Time.fixedDeltaTime, playerManagement.playerRig.velocity.y);
            playerManagement.playerAnim.SetBool("run", true);
        }

        playerManagement.playerStatus.isGround = Physics2D.Raycast(transform.position, Vector2.down, 1f, playerManagement.playerStatus.groundLayerMask);
    }
    public void JumpPlayer()
    {
        if (!playerManagement.playerStatus.isGround) return;
        playerManagement.playerRig.AddForce(Vector2.up * playerManagement.playerStatus.jumpForce, ForceMode2D.Impulse);
        playerManagement.playerAnim.SetBool("jump", true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") playerManagement.playerAnim.SetBool("jump", false);
    }
}
