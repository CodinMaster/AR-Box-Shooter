using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  public Transform[] spawnPoints;
  public GameObject enemy;
  public Material[] enemyMaterials;

  public ScoreManager scoreManager;

  private float spawnWait = 2;

  private void Start()
  {
    StartCoroutine(StartSpawning());
  }

  IEnumerator StartSpawning()
  {
    yield return new WaitForSeconds(spawnWait);

    int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
    int randomEnemyMatIndex = Random.Range(0, enemyMaterials.Length);
    GameObject newEnemy = Instantiate(enemy, spawnPoints[randomSpawnIndex].position, Quaternion.identity);
    newEnemy.GetComponent<Renderer>().material = enemyMaterials[randomEnemyMatIndex];

    scoreManager.IncreaseEnemiesAlive();

    spawnWait = spawnWait / 1.06f;
    StartCoroutine(StartSpawning());
  }
}
