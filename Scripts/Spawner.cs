using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  public GameObject[] apples;

  private float maxSpawnPoint = 6.5f;
  private float minSpawnPoint = -6.5f;

  void Start()
  {
    StartCoroutine(SpawnApples());
  }

  IEnumerator SpawnApples()
  {
    yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
    float appleToSpawn = Random.Range(0f, 10f);
    if(appleToSpawn < 4f)
    {
      Instantiate(apples[0], new Vector2(Random.Range(minSpawnPoint, maxSpawnPoint), transform.position.y),
                  Quaternion.identity);
    } else if(appleToSpawn < 7f)
    {
      Instantiate(apples[1], new Vector2(Random.Range(minSpawnPoint, maxSpawnPoint), transform.position.y),
                  Quaternion.identity);
    } else if(appleToSpawn < 9f)
    {
      Instantiate(apples[3], new Vector2(Random.Range(minSpawnPoint, maxSpawnPoint), transform.position.y),
                  Quaternion.identity);
    } else {
      Instantiate(apples[2], new Vector2(Random.Range(minSpawnPoint, maxSpawnPoint), transform.position.y),
                  Quaternion.identity);
    }

    StartCoroutine(SpawnApples());
  }
} //class
