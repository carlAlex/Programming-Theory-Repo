using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public GameObject flower;
    private float spawnX = 250f;
    private float spawnZ = 250f;
    private float spawnRange = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnFlower();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.NumberFlowers < 10)
        {
            SpawnFlower();
        }
    }

    private void SpawnFlower()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(spawnX - spawnRange, spawnX + spawnRange),
            0,
            Random.Range(spawnZ - spawnRange, spawnZ + spawnRange));
        Instantiate(flower, spawnPos, flower.transform.rotation);
        GameManager.Instance.NumberFlowers++;
    }
}
