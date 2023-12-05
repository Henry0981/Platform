using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FireBox : MonoBehaviour
{
  [SerializeField]
  GameObject enemyPrefab;

  [SerializeField]
  GameObject firepoint;

  int degress = 10;

  float timer = 0;

  [SerializeField]
  float firetime = 1.5f;
  void Update()
  {
    timer += Time.deltaTime;

    if (timer > firetime)
    {
      GameObject instanceFire = Instantiate(enemyPrefab, firepoint.transform.position, Quaternion.identity);
      Destroy(instanceFire, 0.8f);
      timer = 0;
    }
    
  }
}
