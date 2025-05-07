using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Beetle_Movement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent Beetle;
    [SerializeField] Beetle_Stats Beetle_Stats;
    [SerializeField] GameObject currentBeetle;
    [SerializeField] GameObject food;
    private float xPosHigh = 50;
    private float zPosHigh = 50;
    private float xPosLow = -50;
    private float zPosLow = -50;
    [SerializeField] private GameObject grass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBeetle = GetComponent<GameObject>();
        Beetle = GetComponent<NavMeshAgent>();
        Beetle_Stats = GetComponent<Beetle_Stats>();
        grass = GameObject.Find("Grass");
        PickDestination();
        Beetle.speed = Beetle_Stats.speed;
    }

    void PickDestination()
    {
        //food = GameObject.FindWithTag("Food");
        //float distanceToFood = Vector3.Distance(food.transform.position,currentBeetle.transform.position);
        if (Beetle_Stats.Hunger > 50)
        {
            var randomPos = new Vector3(Random.Range(xPosLow, xPosHigh), 0, Random.Range(zPosLow, zPosHigh));
            Beetle.destination = randomPos;
        }
        //else if (food != null && distanceToFood < Beetle_Stats.detectRange)
        //{
        //  Beetle.destination = food.transform.position;
        //}

    }

    // Update is called once per frame
    void Update()
    {
        if(Beetle.remainingDistance < 0.5f)
        {
            PickDestination() ;
        }
        
    }

}
