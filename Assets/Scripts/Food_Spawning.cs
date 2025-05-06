using System.Collections;
using UnityEngine;
using Unity;

public class Food_Spawning : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private GameObject bush;

    [SerializeField] private int food_Amount = 3;
    [SerializeField] private int spawnTime = 3;

    [SerializeField] private float food_range = 3f;
    private float xPos;
    private float yPos;
    private float zPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bush = this.GetComponent<GameObject>();
        xPos = bush.transform.position.x;
        yPos = bush.transform.position.y;
        zPos = bush.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FoodSpawn());
    }
    IEnumerator FoodSpawn()
    {
        yield return null;
        for (int i = 0; i < food_Amount; i++)
        {
            Instantiate(food, new Vector3(Random.Range(xPos - food_range, xPos + food_range), Random.Range(yPos - food_range, yPos + food_range), Random.Range(zPos - food_range, zPos + food_range)), Quaternion.identity);
        }
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(FoodSpawn());
    }
}
