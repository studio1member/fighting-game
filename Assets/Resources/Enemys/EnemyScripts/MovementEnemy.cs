using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] EnemyManagement enemyManagement;
    [SerializeField] private float range = 10f;
    [SerializeField] private float limitFolow = 20f;
    [SerializeField] private float distance = 20f;
    [SerializeField] private float limitDistance = 2.5f;
    [SerializeField] private float speed = 1.3f;    
    [SerializeField] bool show;
    [SerializeField] bool attack = true;
    [SerializeField] private Collider2D players;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        if (!players) 
        {
            players = Physics2D.OverlapCircle(transform.position, range, layerMask);
            enemyManagement.EnemyAnim.SetBool("Walk", false);
        }
        if (players) 
        {
            if (!enemyManagement.virtualStatusEnemy.isDie) return;
            if (distance > limitDistance)
            {
                enemyManagement.EnemyAnim.SetBool("Walk", true);
                Vector3 targetFolower = new Vector3(players.transform.position.x, transform.position.y, transform.position.z);
                transform.position = Vector2.MoveTowards(transform.position, targetFolower, speed * Time.deltaTime);
                if (players.transform.position.x > transform.position.x)
                {
                    Vector3 scaleX = transform.localScale;
                    scaleX.x = -1f;
                    transform.localScale = scaleX;
                }
                else
                {
                    Vector3 scaleX = transform.localScale;
                    scaleX.x = 1f;
                    transform.localScale = scaleX;
                }
            }
            else if (attack)
            {
                attack = false;
                StartCoroutine(AttackCooldown());
                enemyManagement.EnemyAnim.SetTrigger("Attack");
                StartCoroutine(Attack());
            }
            Vector2 enemy = new Vector2(transform.position.x, 0);
            Vector2 player = new Vector2(players.transform.position.x, 0);
            distance = Vector2.Distance(player, enemy);
            if (distance > limitFolow) players = null;
        }
    }
    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(1.5f);
        attack = true;
    }
    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);
        if (enemyManagement.virtualStatusEnemy.isDie)
        {
            Collider2D[] checkHit = Physics2D.OverlapCircleAll(transform.position, 2.5f, layerMask);
            foreach (Collider2D hit in checkHit)
            {
                if (hit) hit.GetComponent<PlayerStatus>().ApplyHP(-10f);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (!show) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, 2.5f);
    }
}
