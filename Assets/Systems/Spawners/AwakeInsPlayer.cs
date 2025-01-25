using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeInsPlayer : MonoBehaviour
{
    [SerializeField] GameObject player1P, player1, player2P, player2;
    private PlayerManagement playerManagement1P, playerManagement2P;
    [SerializeField] private GameObject level2PImage, barHPPlayer2P, barMPPlayer2P, barXPPlayer2P;
    private void Awake()
    {
        player1 = Instantiate(Resources.Load<GameObject>("Heros/" + PlayerPrefs.GetString("ChooseHero1P")));
        player1.name = "Player 1P";
        playerManagement1P = player1.GetComponent<PlayerManagement>();
        player1P = Instantiate(player1P);

        if (PlayerPrefs.GetFloat("Multiplayer") == 0)
        {
            player2 = Instantiate(Resources.Load<GameObject>("Heros/" + PlayerPrefs.GetString("ChooseHero2P")));
            player2.name = "Player 2P";
            playerManagement2P = player2.GetComponent<PlayerManagement>();
            player2P = Instantiate(player2P);
        }
        else
        {
            Destroy(level2PImage);
            Destroy(barHPPlayer2P);
            Destroy(barMPPlayer2P);
            Destroy(barXPPlayer2P);
        }
    }
    private void Update()
    {
        Vector2 pos1 = new Vector2(playerManagement1P.playerName.position.x, playerManagement1P.playerName.position.y);
        player1P.transform.position = pos1;
        if (player2)
        {
            Vector2 pos2 = new Vector2(playerManagement2P.playerName.position.x, playerManagement2P.playerName.position.y);
            player2P.transform.position = pos2;
        }
    }
}
