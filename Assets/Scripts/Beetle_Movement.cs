using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Beetle_Movement : MonoBehaviour
{
    //[SerializeField] private GameObject currentBeetle;

    [SerializeField] private NavMeshAgent Beetle;
    [SerializeField] private Beetle_Stats Beetle_Stats;
    [SerializeField] private GameObject food;

    [SerializeField] private GameObject spawner;
    private Bush_Spawning bush;
    public List<GameObject> Insfood = new List<GameObject>();

    //private float relax = 50f;

    private float RandomWalk = 50f;

    [SerializeField] GameObject target;
    private bool foundtarget = false;

    [SerializeField] private GameObject[] kids;
    private GameObject kid;

    private float Mutation = 0.3f;
    private int breedingTimer = 0;

    void Start()
    {
        Beetle = GetComponent<NavMeshAgent>();
        Beetle_Stats = GetComponent<Beetle_Stats>();
        Beetle.speed = Beetle_Stats.speed;
        bush = FindFirstObjectByType<Bush_Spawning>();
        //currentBeetle = GetComponent<GameObject>();
        if (bush != null )
        {
         Insfood = bush.Insfood;
        }
        PickDestination(RandomWalk, null);
        StartCoroutine(BreedingCooldown());

    }

    void PickDestination(float Range,string tag)
    {

        Vector3 currentPos = Beetle.transform.position;
        Debug.Log(currentPos);
        
        switch(tag)
        {
            case "Food":
                for (int i = 0; i < Insfood.Count; i++)
                    {
                        if(Insfood[i] != null )
                        {
                        float distance = Vector3.Distance(currentPos, Insfood[i].transform.position);
                        if (distance <= Beetle_Stats.detectRange)
                        {
                            foundtarget = true;
                            target = Insfood[i];
                            return;
                        }
                        }
                        
                        
                    }
            break;
            case "Beetle":
                if(breedingTimer <= 0)
                {
                    kid = Instantiate(kids[Random.Range(0, kids.Length)], currentPos, Quaternion.identity);
                    kid.GetComponent<Beetle_Stats>().speed = Random.Range(Beetle_Stats.speed - Mutation, Beetle_Stats.speed + Mutation);
                    kid.GetComponent<Beetle_Stats>().detectRange = Random.Range(Beetle_Stats.detectRange - Mutation, Beetle_Stats.detectRange + Mutation);
                    kid.GetComponent<Beetle_Stats>().Hunger = 30;
                    breedingTimer = 10;
                }
                 
                    

                break;
        }

        if (target != null)
        {
            Vector3 targetPos = target.transform.position;
            if (!foundtarget)
            {
                var DesPos = new Vector3(Random.Range(-Range,Range), 0, Random.Range(-Range,Range));
                Beetle.destination = DesPos;
            }
            else
            {
                var DesPos = new Vector3(targetPos.x, currentPos.y, targetPos.z);
                Beetle.destination = DesPos;
                if(Beetle.remainingDistance == 0)
                {
                    foundtarget = false;
                }
            }
        }
        else
        {
            var DesPos = new Vector3(Random.Range(-Range,Range), 0, Random.Range(-Range, Range));
            Beetle.destination = DesPos;
        }
        }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RemoveFood());
        //Debug.Log(Beetle.destination.ToString());
        if (Beetle.remainingDistance < 0.1f)
        {
            //PickDestination() ;
            switch(Beetle_Stats.Hunger)
            {
                case < 50:
                    PickDestination(RandomWalk,"Food");
                    //target = food;
                break;
                case > 80:
                    PickDestination(0,"Beetle");
                    //target = mate;
                break;
                default:
                    //PickDestination(relax,null);
                    PickDestination(RandomWalk, null);
                break;
            }
        }
        
    }

    IEnumerator BreedingCooldown()
    {
        breedingTimer--;
        yield return new WaitForSeconds(1);
        StartCoroutine(BreedingCooldown());

    }
    
    IEnumerator RemoveFood()
    {
        yield return new WaitForSeconds(5);
        for (int i = 0;i < Insfood.Count;i++)
        {
            if(Insfood[i] == null )
            {
                Insfood.RemoveAt(i);
            }
        }
    }

}
