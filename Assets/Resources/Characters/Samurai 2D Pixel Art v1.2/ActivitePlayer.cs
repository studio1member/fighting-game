using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ActivitePlayer : VirtualPlayerActivites
{
    private PlayerManagement playerManagement;
    [Header("Skill 1")]
    [SerializeField] private bool isSkill1 = true;
    [SerializeField] private float cooldownSkill1 = 0.3f;

    [SerializeField] private Image barBaokich;
    [SerializeField] private bool isBaokich;
    [SerializeField] private Transform skill1;
    public float damageBaokick;
    [SerializeField] private float timerBaokich = 0f;
    [SerializeField] private float maxBaokick = 3f;

    [SerializeField] private bool showRangeSkill1;
    [SerializeField] private Transform pointSkill1;
    [SerializeField] private float rangeSkill1 = 1.4f;
    [SerializeField] private LayerMask objectAttack;

    [SerializeField] public float timerIsAttack;
    [SerializeField] public float cooldownIsAttack;

    private void Awake()
    {
        if (!playerManagement) playerManagement = GetComponent<PlayerManagement>();
    }
    private void Update()
    {
        if (timerIsAttack <= 0) { playerManagement.playerMovement.isAttack = true; }
        if (timerIsAttack > 0) { timerIsAttack -= Time.deltaTime; }
    }

    //------------Skill 1-------------------
    public override void skill1_down()
    {
        base.skill1_down();
        barBaokich.gameObject.SetActive(true);
        isBaokich = true;
        StartCoroutine(Hit_Hard());
    }
    private IEnumerator Hit_Hard()
    {
        while (timerBaokich <= maxBaokick && isBaokich)
        {
            timerBaokich += Time.deltaTime;
            barBaokich.fillAmount = timerBaokich / maxBaokick;
            yield return null;
        }
    }
    public override void skill1_up()
    {
        base.skill1_up();

        timerIsAttack = cooldownIsAttack;
        playerManagement.playerMovement.isAttack = false;

        damageBaokick = timerBaokich;

        Collider2D[] checkEnemy = Physics2D.OverlapCircleAll(pointSkill1.position, rangeSkill1, objectAttack);
        foreach(Collider2D hit in checkEnemy)
        {
            hit.GetComponent<VirtualStatusEnemy>().ApplyHP(-playerManagement.playerStatus.getDamage, playerManagement.playerStatus);
        }

        barBaokich.gameObject.SetActive(false);
        isBaokich = false;
        if (isSkill1) StartCoroutine(Skill1Cooldown());
    }
    private IEnumerator Skill1Cooldown()
    {
        isSkill1 = false;
        barBaokich.fillAmount = 0f;
        playerManagement.playerAnim.SetTrigger("skill 1");
        if (timerBaokich > 1f) StartCoroutine(BaokichUp());
        timerBaokich = 0f;
        yield return new WaitForSeconds(cooldownSkill1);
        isSkill1 = true;
    }
    private IEnumerator BaokichUp()
    {
        yield return new WaitForSeconds(0.2f);
        Vector3 scale = transform.localScale;
        float timer = 0f;
        skill1.position = new Vector2(transform.position.x, transform.position.y + 0.9f);
        skill1.gameObject.SetActive(true);
        skill1.SetParent(null);
        skill1.Translate(Vector2.right * scale.x * 1f);

        while (timer <= 0.5f) 
        {
            timer += Time.deltaTime;
            skill1.Translate(Vector2.right * scale.x * 10f * Time.deltaTime);
            if (timer > 0.5f) 
            {
                skill1.SetParent(transform);
                skill1.gameObject.SetActive(false);
            }
            yield return null;
        }
    }
    private void OnDrawGizmos()
    {
        if (showRangeSkill1) Gizmos.DrawWireSphere(pointSkill1.position, rangeSkill1);
    }

    //----------Skill 2-----------------------
    public override void skill2_down()
    {
        base.skill2_down();
    }
    public override void skill2_up()
    {
        base.skill2_up();
    }
}
