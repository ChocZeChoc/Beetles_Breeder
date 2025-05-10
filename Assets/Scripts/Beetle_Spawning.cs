using UnityEngine;
using UnityEngine.UI;

public class Beetle_Spawning : MonoBehaviour
{
    [SerializeField] private GameObject beetleSpawner;
    [SerializeField] private GameObject males;
    [SerializeField] private GameObject females;
     private int startBeetleAmount;
    
    private float Range = 45F;

    public GameObject Sim;

    public UI_Controls uI_Controls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {

        startBeetleAmount = uI_Controls.StartBeetles();
    }

    void Start()
    {
        SpawnBeetle(startBeetleAmount);
        Debug.Log(startBeetleAmount);
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
            Instantiate(males,spawnPoint,Quaternion.identity,Sim.transform);
        }
        for (int i = 0; i < amount / 2; i++)
        {
            float spawnPointX = Random.Range(-Range, Range);
            float spawnPointZ = Random.Range(-Range, Range);
            Vector3 spawnPoint = new Vector3(spawnPointX, -0.25f, spawnPointZ);
            Instantiate(females, spawnPoint, Quaternion.identity, Sim.transform);
        }
    }
}
