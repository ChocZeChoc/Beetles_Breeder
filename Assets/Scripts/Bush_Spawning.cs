
using UnityEngine;

public class Bush_Spawning : MonoBehaviour
{
    [SerializeField] private GameObject bush;
    [SerializeField] private GameObject food;
    [SerializeField] private GameObject bushSpawner;
    [SerializeField] private int bush_Amount = 20;

    [SerializeField] private float bush_Height = 0.7f;

    [SerializeField] private float xPosLow = -50f;
    [SerializeField] private float zPosLow = -50f;
    [SerializeField] private float xPosHigh = 50f;
    [SerializeField] private float zPosHigh = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SpawnBush(bush_Amount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnBush(int amount)
    {


        for (int i = 0; i < amount; i++)
        {
            float spawnPointX = Random.Range(xPosLow, xPosHigh);
            float spawnPointZ = Random.Range(zPosLow, zPosHigh);
            Vector3 spawnPoint = new Vector3(spawnPointX, bush_Height, spawnPointZ);
            Instantiate(bush, spawnPoint, Quaternion.identity);
        }
    }

}
