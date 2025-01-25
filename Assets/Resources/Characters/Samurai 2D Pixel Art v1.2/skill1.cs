using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill1 : MonoBehaviour
{
    [SerializeField] private Vector2 range;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private ActivitePlayer activitePlayer;
    [SerializeField] private PlayerStatus playerStatus;
    private void Awake()
    {
        if (!activitePlayer) activitePlayer = GameObject.Find("Player 1P").GetComponent<ActivitePlayer>();
        if (!playerStatus) playerStatus = GameObject.Find("Player 1P").GetComponent<PlayerStatus>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Collider2D[] checkEnemy = Physics2D.OverlapBoxAll(transform.position, range, 0f, layerMask);
        foreach(Collider2D hit in checkEnemy)
        {
            hit.GetComponent<VirtualStatusEnemy>().ApplyHP(-playerStatus.getDamage * activitePlayer.damageBaokick, playerStatus);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, range);
    }
}
