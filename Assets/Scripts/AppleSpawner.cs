using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _applePrefab;
    private float _waitSpawnTime = 0.0f;    

    private void SpawnApple()
    {
        Vector3 treePosition = gameObject.GetComponent<Transform>().position;
        Vector3 spawnPosition = new Vector3(
            treePosition.x + Random.Range(-1.0f, 1.0f),
            treePosition.y,
            treePosition.z + Random.Range(-1.0f, 1.0f)
        );

        Instantiate(_applePrefab, spawnPosition, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        _waitSpawnTime += Time.deltaTime;

        if(_waitSpawnTime > 3.0f) {
            SpawnApple();
            _waitSpawnTime = 0.0f;
        }
    }
}
