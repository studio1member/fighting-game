using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveteFreeKnight : VirtualPlayerActivites
{
    private PlayerManagement playerManagement;
    private int attackCurrent;
    private float timerChangeAttack;
    private float timerDelay;
    [SerializeField] private Transform pointAttack;
    [SerializeField] private float rangeAttack;
    [SerializeField] private LayerMask enemy;
    [SerializeField] private bool showRangeAttack;
    [SerializeField] private float isAttack;
    [SerializeField] private float getDamage;

    private void Awake()
    {
        if (!playerManagement) playerManagement = GetComponent<PlayerManagement>();

    }
    private void Update()
    {
        if (timerChangeAttack > 0) timerChangeAttack -= Time.deltaTime;
        if (timerChangeAttack <= 0) attackCurrent = 0;
        if (timerDelay > 0) timerDelay -= Time.deltaTime;
        if (isAttack > 0)
        {
            isAttack -= Time.deltaTime;
            if (isAttack <= 0) playerManagement.playerMovement.isAttack = true;
        }
    }
    public override void skill1_down()
    {
        base.skill1_down();
        if (attackCurrent == 0 && timerDelay <= 0) StartCoroutine(Attack());
        else if (attackCurrent == 1 && timerDelay <= 0) StartCoroutine(Attack1());
    }
    IEnumerator Attack()
    {
        isAttack = 0.24f;
        playerManagement.playerMovement.isAttack = false;
        timerDelay = 0.2f;
        attackCurrent = 1;
        timerChangeAttack = 3f;
        playerManagement.playerAnim.SetTrigger("attack");
        yield return new WaitForSeconds(0.1f);
        Collider2D[] checkEnemy = Physics2D.OverlapCircleAll(pointAttack.position, rangeAttack, enemy);
        foreach (Collider2D hit in checkEnemy) hit.GetComponent<VirtualStatusEnemy>().ApplyHP(-playerManagement.playerStatus.getDamage, playerManagement.playerStatus);
    }
    IEnumerator Attack1()
    {
        isAttack = 0.24f;
        playerManagement.playerMovement.isAttack = false;
        timerDelay = 0.2f;
        attackCurrent = 0;
        timerChangeAttack = 3f;
        playerManagement.playerAnim.SetTrigger("attack 1");
        yield return new WaitForSeconds(0.1f);
        Collider2D[] checkEnemy = Physics2D.OverlapCircleAll(pointAttack.position, rangeAttack, enemy);
        foreach (Collider2D hit in checkEnemy) hit.GetComponent<VirtualStatusEnemy>().ApplyHP(-playerManagement.playerStatus.getDamage, playerManagement.playerStatus);
    }
    public override void skill1_up()
    {
        base.skill1_up();
    }
    private void OnDrawGizmos()
    {
        if (!showRangeAttack) return;
        Gizmos.DrawWireSphere(pointAttack.position, rangeAttack);
    }
    public override void skill2_down()
    {
        base.skill2_down();
    }
    public override void skill2_up()
    {
        base.skill2_up();
    }
}
