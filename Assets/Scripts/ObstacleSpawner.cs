using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Range(0.1f, 2f)]
    [SerializeField]
    private float spawnRate = 0.5f;
    [Range(0.01f, 1f)]
    [SerializeField]
    private float shieldChance = 0.05f;
    [SerializeField]
    private GameObject shield;

    private Coroutine spawnCoroutine;

    private void Awake()
    {
        PlayerController.OnPlayerDeath += ResetObjects;
    }

    public void SpawnStart()
    {
        spawnCoroutine = StartCoroutine(SpawnObjects());
    }

    private GameObject GetSpawnObject()
    {
        if(!shield.activeInHierarchy && shieldChance > Random.value)
        {
            return shield;
        }
        return ObstaclePool.instance.GetPooledObject();
    }


    private IEnumerator SpawnObjects()
    {
        GameObject obstacle;

        while (true)
        {
            obstacle = GetSpawnObject();
            if(obstacle != null)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-7, 7), transform.position.y, transform.position.z);
                obstacle.transform.position = spawnPosition;
                obstacle.SetActive(true);
            }

            yield return new WaitForSeconds(spawnRate);
        }


    }

    private void ResetObjects(float score)
    {
        StopCoroutine(spawnCoroutine);
        ObstaclePool.instance.DespawnAll();
    }

    private void OnDestroy()
    {
        PlayerController.OnPlayerDeath -= ResetObjects;
    }
}
