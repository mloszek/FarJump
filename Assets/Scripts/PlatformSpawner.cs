using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public float platformSpeed = 0;
    public float spawnRatio = 0;

    void Start()
    {
        StartCoroutine(SpawnPlatforms());
    }

    IEnumerator SpawnPlatforms()
    {
        for (int i = 0; i < 22; i++)
        {
            var newPlatform = Instantiate(platform, gameObject.transform.position + new Vector3((i * 17.74f), 0, 0), Quaternion.identity);
            newPlatform.GetComponent<PlatformMover>().SetSpeed(platformSpeed);
            yield return new WaitForSeconds(Random.Range(spawnRatio / 2, spawnRatio));
        }
    }
}
