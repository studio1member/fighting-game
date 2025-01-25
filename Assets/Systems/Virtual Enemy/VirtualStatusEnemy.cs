using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class VirtualStatusEnemy : MonoBehaviour
{
    public EnemyManagement enemyManagement;
    public bool isDie = true;
    public float receivedXP;
    public float currentHP;
    public float maxHP;
    public void Start()
    {
        currentHP = maxHP;
    }
    public void ApplyHP(float damage, PlayerStatus playerStatus)
    {
        if (!isDie) return;
        currentHP += damage;
        enemyManagement.EnemyAnim.SetTrigger("Hurt");
        if (currentHP <= 0)
        {
            isDie = false;
            StartCoroutine(DieEnemy());
            playerStatus.ApplyXP(receivedXP);
            StartCoroutine(enemyManagement.golemSpawner.SpawnEnemy());
            Destroy(gameObject, 3f);
        }
    }
    IEnumerator DieEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        enemyManagement.EnemyAnim.SetTrigger("Die");
    }
}
