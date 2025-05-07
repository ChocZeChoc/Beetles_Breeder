using UnityEngine;

public class Beetle_Spawning : MonoBehaviour
{
    [SerializeField] private GameObject beetleSpawner;
    [SerializeField] private GameObject males;
    [SerializeField] private GameObject females;
    [SerializeField] private int startBeetleAmount = 10;

    [SerializeField] private float Range = 50F;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBeetle(startBeetleAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBeetle(int amount)
    {
        

        for (int i = 0; i < amount/2; i++)
        {
            float spawnPointX = Random.Range(-Range,Range);
            float spawnPointZ = Random.Range(-Range, Range);
            Vector3 spawnPoint = new Vector3(spawnPointX,-0.25f, spawnPointZ);
            Instantiate(males,spawnPoint,Quaternion.identity);
        }
        for (int i = 0; i < amount / 2; i++)
        {
            float spawnPointX = Random.Range(-Range, Range);
            float spawnPointZ = Random.Range(-Range, Range);
            Vector3 spawnPoint = new Vector3(spawnPointX, -0.25f, spawnPointZ);
            Instantiate(females, spawnPoint, Quaternion.identity);
        }
    }
}
