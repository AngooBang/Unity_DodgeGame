using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float MinSpawnRate = 0.5f;
    public float MaxSpawnRate = 3f;
    public Transform Target;

    private float _elapsedTime = 0f;
    private float _spawnRate = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _spawnRate = getRandomSpawnRate();

    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _spawnRate)
        {
            _elapsedTime = 0f;

            GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(Target);

            _spawnRate = getRandomSpawnRate();

        }
    }

    // return을 요약하는 C#기능
    private float getRandomSpawnRate() => Random.Range(MinSpawnRate, MaxSpawnRate);
}
