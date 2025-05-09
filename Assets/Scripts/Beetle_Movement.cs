using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
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

    void PickDestination(float Range,GameObject tar)
    {
        
        if (!foundtarget)
        {
            var DesPos = new Vector3(Random.Range(-Range,Range),0, Random.Range(-Range, Range));
            Beetle.destination = DesPos;
            return;
        }
        else
        {
            Vector3 targetPos = tar.transform.position;
            var DesPos = new Vector3(targetPos.x, 0, targetPos.z);
            Beetle.destination = DesPos;

        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = Beetle.transform.position;
        StartCoroutine(RemoveFood());
        
        if (Beetle.remainingDistance < 2f)
        {
            foundtarget = false;
            //PickDestination() ;
            switch(Beetle_Stats.Hunger)
            {
                case < 50:
                    LookForTarget(currentPos);
                    break;
                case > 80:
                    Breed(currentPos);
                    break;
                default:
                    PickDestination(RandomWalk,null);
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

    void LookForTarget(Vector3 currentPos)
    {
        for (int i = 0; i < Insfood.Count; i++)
        {
            if (Insfood[i] != null)
            {
                float distance = Vector3.Distance(currentPos, Insfood[i].transform.position);
                if (distance <= Beetle_Stats.detectRange)
                {

                    target = Insfood[i];
                    foundtarget = true;
                    Debug.Log(target.name + target.transform.position);
                    PickDestination(0, target);
                    return;
                }
                else
                {
                    foundtarget = false;
                }

            }
            else
            {
                return;
            }


        }
    }

    void Breed(Vector3 currentPos)
    {
        if (breedingTimer <= 0)
        {
            kid = Instantiate(kids[Random.Range(0, kids.Length)], currentPos, Quaternion.identity);
            kid.GetComponent<Beetle_Stats>().speed = Random.Range(Beetle_Stats.speed - Mutation, Beetle_Stats.speed + Mutation);
            kid.GetComponent<Beetle_Stats>().detectRange = Random.Range(Beetle_Stats.detectRange - Mutation, Beetle_Stats.detectRange + Mutation);
            kid.GetComponent<Beetle_Stats>().Hunger = 30;
            breedingTimer = 10;
            //Debug.Log(breedingTimer);
            return;
        }
        else
        {
            LookForTarget(currentPos);
            //Debug.Log(breedingTimer);
            return;
        }
    }

}
