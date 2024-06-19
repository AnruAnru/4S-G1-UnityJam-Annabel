using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawn : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject _stone;

    private float timer;

    private void Start()
    {
        SpawnStone();
    }

    private void Update()
    {
        if (timer > maxTime)
        {
            SpawnStone();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnStone()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject stone = Instantiate(_stone, spawnPos, Quaternion.identity);

        Destroy(stone, 15f);
    }
}
