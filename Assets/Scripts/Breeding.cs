using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Breeding : MonoBehaviour
{
    private float breedingTimer = 0;
    [SerializeField] private GameObject[] kids;
    private GameObject kid;
    private Beetle_Stats Stats;

    private float Mutation = 1f;

    private LookForFood lookforfood;

    private Vector3 BeetlePos;
    public NavMeshAgent agent;

    public GameObject Sim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lookforfood = GetComponent<LookForFood>();
        Stats = GetComponent<Beetle_Stats>();
        agent = GetComponent<NavMeshAgent>();
        Sim = GameObject.Find("Beetles");
        StartCoroutine(BreedingCooldown());

    }

    // Update is called once per frame
    void Update()
    {
        BeetlePos = agent.transform.position;
        if (Stats.Hunger > 80)
        {
            Breed(BeetlePos);
        }
        
    }
    void Breed(Vector3 currentPos)
    {
        if (breedingTimer <= 0)
        {
            kid = Instantiate(kids[Random.Range(0, kids.Length)], currentPos, Quaternion.identity,Sim.transform);
            kid.GetComponent<Beetle_Stats>().speed = Random.Range(Stats.speed - Mutation, Stats.speed + Mutation);
            kid.GetComponent<Beetle_Stats>().detectRange = Random.Range(Stats.detectRange - Mutation, Stats.detectRange + Mutation);
            kid.GetComponent<Beetle_Stats>().Hunger = 30;
            breedingTimer = 10;
            //Debug.Log(breedingTimer);
            return;
        }
        else
        {
            lookforfood.LookForTarget(currentPos);
            //Debug.Log(breedingTimer);
            return;
        }
    }

    IEnumerator BreedingCooldown()
    {
        breedingTimer--;
        yield return new WaitForSeconds(1);
        StartCoroutine(BreedingCooldown());

    }
}
