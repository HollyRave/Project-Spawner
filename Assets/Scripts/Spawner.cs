using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private List<Point> _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;

    private int _targetSpawnIndex;
    private Transform _targetSpawnPosition;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            _targetSpawnIndex = Random.Range(0, _spawnPoints.Count);
            _targetSpawnPosition = _spawnPoints[_targetSpawnIndex].transform;

            Instantiate(_enemyPrefab, _targetSpawnPosition);

            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }
}
