using UnityEngine;
using UnityEngine.AI;

public class Beetle_Movement : MonoBehaviour
{
    private Beetle_Stats stats;
    private NavMeshAgent Beetle;
    private int xPosHigh = 50;
    private int zPosHigh = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Beetle = GetComponent<NavMeshAgent>();
        stats = GetComponent<Beetle_Stats>();
        Beetle.speed = stats.speed;
        PickDestination();
    }

    void PickDestination()
    {
        var randomPos = new Vector3(Random.Range(0, xPosHigh), 0, Random.Range(0, zPosHigh));
        Beetle.destination = randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Beetle.remainingDistance < 0.5f){
            PickDestination() ;
        }
    }

    
}
