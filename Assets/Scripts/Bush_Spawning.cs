
using System.Collections;
using UnityEngine;

public class Bush_Spawning : MonoBehaviour
{
    [SerializeField] private GameObject bush;
    [SerializeField] private GameObject food;
    [SerializeField] private GameObject bushSpawner;
    [SerializeField] private int bush_Amount = 20;
    [SerializeField] private int food_Amount = 100;

    [SerializeField] private float foodRate = 10;

    [SerializeField] private float bush_Height = 0.7f;

    [SerializeField] private float Spawnrange = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SpawnBush();
        StartCoroutine(FoodSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBush()
    {
        for (int i = 0;i < bush_Amount;i++)
        {
            Vector3 Spawnpoint = Randomizer(0,0, Spawnrange,bush_Height);
            Instantiate(bush,Spawnpoint, Quaternion.identity);
        }
    }

    Vector3 Randomizer(float xPos, float zPos, float range,float height)
    {
        float x = Random.Range(xPos-range,xPos+range);
        float y = height;
        float z = Random.Range(zPos-range,zPos+range);
        return new Vector3(x, y, z);
    }
    
    IEnumerator FoodSpawn()
    {
        
        for (int i = 0; i < food_Amount; i++)
        {
            Vector3 Spawnpoint = Randomizer(0, 0, Spawnrange,0);
            Instantiate(food, Spawnpoint, Quaternion.identity);
        }
        yield return new WaitForSeconds(foodRate);
        StartCoroutine(FoodSpawn());
    }

}
