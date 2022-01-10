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

            float angle = Vector3.Angle(Target.transform.position - bullet.transform.position, bullet.transform.forward);

            Vector3 normalVector = Vector3.Cross(Target.transform.position - bullet.transform.position, bullet.transform.forward);

            if (Vector3.Dot(Vector3.up, normalVector) < 0f)
            {
                bullet.transform.rotation = bullet.transform.rotation * Quaternion.Euler(0, angle, 0);
            }
            else
            { 
                bullet.transform.rotation = bullet.transform.rotation * Quaternion.Euler(0, -angle, 0);
            }

        

            _spawnRate = getRandomSpawnRate();

        }
    }

    // return을 요약하는 C#기능
    private float getRandomSpawnRate() => Random.Range(MinSpawnRate, MaxSpawnRate);
}
