using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
  public GameObject arCamera;
  public GameObject explosion;

  public ScoreManager scoreManager;

  public void ShootFx()
  {
    RaycastHit hit;

    if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
    {
      if (hit.transform.CompareTag("Enemy"))
      {
        Destroy(hit.transform.gameObject);
        scoreManager.DecreaseEnemiesAlive();

        Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));
      }
    }
  }
}
