using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GolemSpawner : MonoBehaviour
{
    [SerializeField] EnemyManagement enemyManagement;
    [SerializeField] Vector2 pointSpawn;
    private void Start()
    {
        enemyManagement.golemSpawner = this;
        Transform ins = Instantiate(enemyManagement.transform);
        ins.gameObject.SetActive(true);
        ins.position = pointSpawn;
    }
    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(2f);
        Transform ins = Instantiate(enemyManagement.transform);
        ins.gameObject.SetActive(true);
        ins.position = pointSpawn;
    }
}
