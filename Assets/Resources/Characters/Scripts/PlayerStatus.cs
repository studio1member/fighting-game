using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public PlayerManagement playerManagement;

    [Header("Movement")]
    public float speedPlayer = 4f;
    public LayerMask groundLayerMask;
    public float jumpForce = 20f;
    public bool isGround;
    private bool isMove;

    [Header("Status")]
    [SerializeField ]private Text level;
    private Image barHPPlayer;
    private Image barMPPlayer;
    private Image barXPPlayer;

    public float currentHP;
    public float maxHP;
    public float getDamage;
    public float requiresXP;
    public float currentXP;
    private void Awake()
    {
        playerManagement = GetComponent<PlayerManagement>();
        isMove = true;
    }
    private void Start()
    {
        currentHP = PlayerPrefs.GetFloat("Max HP " + gameObject.name);
        getDamage = PlayerPrefs.GetFloat("Damage " + gameObject.name);
        requiresXP = PlayerPrefs.GetFloat("Requires XP " + gameObject.name);

        level = GameObject.Find("Level " + gameObject.name + " Text").GetComponent<Text>();
        level.text = "" + PlayerPrefs.GetInt("Level " + gameObject.name);
        barHPPlayer = GameObject.Find("Bar HP " + gameObject.name).GetComponent<Image>();
        maxHP = PlayerPrefs.GetFloat("Max HP " + gameObject.name);
        barHPPlayer.fillAmount = currentHP / maxHP;
        barMPPlayer = GameObject.Find("Bar MP " + gameObject.name).GetComponent<Image>();
        barXPPlayer = GameObject.Find("Bar XP " + gameObject.name).GetComponent<Image>();
        currentXP = PlayerPrefs.GetFloat("Current XP " + gameObject.name);
        barXPPlayer.fillAmount = currentXP / requiresXP;
    }

    public void ApplyXP(float xp)
    {
        currentXP = PlayerPrefs.GetFloat("Current XP " + gameObject.name);
        PlayerPrefs.SetFloat("Current XP " + gameObject.name, currentXP + xp);
        barXPPlayer.fillAmount = currentXP / requiresXP;
        while (currentXP > requiresXP)
        {
            PlayerPrefs.SetFloat("Current XP " + gameObject.name, currentXP - requiresXP);
            PlayerPrefs.SetFloat("Requires XP " + gameObject.name, requiresXP * 1.1f);
            PlayerPrefs.SetInt("Level " + gameObject.name, PlayerPrefs.GetInt("Level " + gameObject.name) + 1);
            level.text = "" + PlayerPrefs.GetInt("Level " + gameObject.name);
            requiresXP = PlayerPrefs.GetFloat("Requires XP " + gameObject.name);
            barXPPlayer.fillAmount = currentXP / requiresXP;
        }
    }
    public void ApplyHP(float hp)
    {
        if (!isMove) return;
        currentHP += hp;
        barHPPlayer.fillAmount = currentHP / maxHP;
        playerManagement.playerAnim.SetTrigger("hurt");
        if (currentHP <= 0)
        {
            playerManagement.playerAnim.SetTrigger("die");
            isMove = false;
            playerManagement.playerMovement.isMove = false;
        }
    }
}
