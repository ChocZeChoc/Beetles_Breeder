
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bush_Spawning : MonoBehaviour
{
    [SerializeField] private GameObject bush;
    [SerializeField] private GameObject food;
    [SerializeField] private GameObject bushSpawner;
    public List<GameObject> Insfood = new List<GameObject>();
    List<GameObject> Insbush = new List<GameObject>();

    public int bush_Amount;
    private int food_Amount = 3;

    private float foodRate = 20;
    private float bush_Height = 0.7f;
    private float food_Height = 1.5f;

    private float Spawnrange = 45f;

    public GameObject Sim_Food;
    public GameObject Sim_Bush;

    public UI_Controls uI_Controls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        bush_Amount = uI_Controls.StartBush();
    }

    void Start()
    {
        SpawnBush();
        //Debug.Log(bush_Amount);
        //Debug.Log(food_Amount);
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RemoveFood());
    }

    void SpawnBush()
    {
        for (int i = 0;i < bush_Amount;i++)
        {
            Vector3 Spawnpoint = Randomizer(0,0, Spawnrange,bush_Height);
            Insbush.Insert(i, Instantiate(bush, Spawnpoint, Quaternion.identity,Sim_Bush.transform));
            StartCoroutine(FoodSpawn(i));
        }
    }

    Vector3 Randomizer(float xPos, float zPos, float range,float height)
    {
        float x = Random.Range(xPos-range,xPos+range);
        float y = height;
        float z = Random.Range(zPos-range,zPos+range);
        return new Vector3(x, y, z);
    }
    
    IEnumerator FoodSpawn(int Bushes)
    {
        
        for (int j = 0; j < food_Amount; j++)
        {
            Vector3 Spawnpoint = Randomizer(0, 0, bush_Height,food_Height) + new Vector3(GivePos(Insbush[Bushes]).x, 0, GivePos(Insbush[Bushes]).z);
            Insfood.Insert(j, Instantiate(food, Spawnpoint, Quaternion.identity,Sim_Food.transform));
            
        }
        yield return new WaitForSeconds(foodRate);
        //GivePos(Insfood);
        StartCoroutine(FoodSpawn(Bushes));
        
    }

    public Vector3 GivePos(GameObject InsObj)
    {
        return InsObj.transform.position;
    }

    IEnumerator RemoveFood()
    {
        yield return new WaitForSeconds(5);
        for (int i = 0; i < Insfood.Count; i++)
        {
            if (Insfood[i] == null)
            {
                Insfood.RemoveAt(i);
            }
        }
    }
}
