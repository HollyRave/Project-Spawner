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
    private bool _canThisBeSpawn = true;

    private void Update()
    {
        if (_canThisBeSpawn == true)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator SpawnEnemy()
    {
        _canThisBeSpawn = false;

        _targetSpawnIndex = Random.Range(0, _spawnPoints.Count);
        _targetSpawnPosition = _spawnPoints[_targetSpawnIndex].GetComponent<Transform>();

        Instantiate(_enemyPrefab, _targetSpawnPosition);

        yield return new WaitForSeconds(_timeBetweenSpawn);

        _canThisBeSpawn = true;
    }
}
