using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using System.Linq;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _maxObjects = 8;
    [SerializeField] private int _maxCoinOnSpot;
    [SerializeField] private float _enemyProbability = 0.2f;
    [SerializeField] private float _spawnInterval = 8f;
    [SerializeField] private GameProgress _gameProgress;

    private List<Vector3> _validSpawnPositions = new List<Vector3>();
    private List<GameObject> _spawnObjects = new List<GameObject>();
    private bool _isSpawning = false;
    private float _distanceToCheckOnSpawn = 1f;
    private float _horizontalShift = 0.5f;
    private float _verticalShift = 2.0f; 

    public enum ObjectType 
    {
        Coin,
        Enemy
    }

    void Start()
    {
        GatherValidPositions();
        StartCoroutine(SpawnObjectsIfNeeded());
    }

    private int ActiveObjectCount()
    {
        _spawnObjects.RemoveAll(item => item == null);
        return _spawnObjects.Count;
    }

    private IEnumerator SpawnObjectsIfNeeded()
    {
        _isSpawning = true;

        while(ActiveObjectCount() < _maxObjects)
        {
            SpawnObject();
            yield return new WaitForSeconds(_spawnInterval);
        }

        _isSpawning = false;
    }

    private bool PositionHasObject(Vector3 positionToCheck)
    {
        return _spawnObjects.Any(checkObj => checkObj && (checkObj.transform.position - positionToCheck).sqrMagnitude < _distanceToCheckOnSpawn * _distanceToCheckOnSpawn);
    }

    private ObjectType RandomObjectType()
    {
        float randomChoice = Random.value;

        if(randomChoice <= _enemyProbability)
            return ObjectType.Enemy;
        else 
            return ObjectType.Coin;
    }

    private void SpawnObject()
    {
        if(_validSpawnPositions.Count == 0)
            return;

        Vector3 spawnPosition = Vector3.zero;
        bool validPositionFound = false;

        while(!validPositionFound && _validSpawnPositions.Count > 0)
        {
            int randomIndex = Random.Range(0, _validSpawnPositions.Count);
            Vector3 potentialPosition = _validSpawnPositions[randomIndex];
            Vector3 leftposition = potentialPosition + Vector3.left;
            Vector3 rightposition = potentialPosition + Vector3.right;

            if(!PositionHasObject(leftposition) && !PositionHasObject(rightposition))
            {
                spawnPosition = potentialPosition;
                validPositionFound = true;
            }

            _validSpawnPositions.RemoveAt(randomIndex);
        }

        if (validPositionFound)
        {
            ObjectType objectType = RandomObjectType();

            if (objectType == ObjectType.Coin)
            {
                Coin obj = Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);
                _spawnObjects.Add(obj.gameObject);
                
                obj.CoinCollecting += OnCoinCollecting;
            }
            else 
            {
                Enemy obj = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
                _spawnObjects.Add(obj.gameObject);
            }
        }
    }

    private void GatherValidPositions()
    {
        _validSpawnPositions.Clear();
        BoundsInt boundsInt = _tilemap.cellBounds;
        TileBase[] allTiles = _tilemap.GetTilesBlock(boundsInt);
        Vector3 start = _tilemap.CellToWorld(new Vector3Int (boundsInt.xMin, boundsInt.yMin, 0));

        for (int x = 0; x < boundsInt.size.x; x++)
        {
            for (int y = 0; y < boundsInt.size.y; y++)
            {
                TileBase tile = allTiles[x + y * boundsInt.size.x];

                if(tile != null)
                {
                    Vector3 place = start + new Vector3(x + _horizontalShift, y + _verticalShift, 0);

                    _validSpawnPositions.Add(place);
                }
            }
        }
    }

    private void OnCoinCollecting(Coin collectingResource)
    {
        _gameProgress.IncreaseProgressAmount(collectingResource.Worth);
        collectingResource.CoinCollecting -= OnCoinCollecting;
        Destroy(collectingResource.gameObject);
    }
}
