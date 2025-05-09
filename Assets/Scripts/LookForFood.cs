using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class LookForFood : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public GameObject food;
    public float detect;

    public bool foundtarget = false;
    public float Range = 45f;

    public List<GameObject> Insfood = new List<GameObject>();
    private Bush_Spawning bush;

    private Beetle_Stats Stats;

    private Vector3 BeetlePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bush = FindFirstObjectByType<Bush_Spawning>();
        if (bush != null)
        {
            Insfood = bush.Insfood;
        }
        Stats = GetComponent<Beetle_Stats>();
        agent.speed = Stats.speed;
        detect = Stats.detectRange;
    }
    // Update is called once per frame
    void Update()
    {
        RemoveFood();
        BeetlePos = agent.transform.position;
        if (agent.remainingDistance < 2)
        {

            LookForTarget(BeetlePos);

        }
        
    }

    void PickDestination(float range, GameObject tar)
    {
        if (tar != null)
        {
            if (!foundtarget)
            {
                return;
            }
            else
            {
                Vector3 targetPos = tar.transform.position;
                var DesPos = new Vector3(targetPos.x, 0, targetPos.z);
                agent.destination = DesPos;

            }

        }
        else
        {
            var DesPos = new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));
            agent.destination = DesPos;
        }
        
    }

    public void LookForTarget(Vector3 currentPos)
    {
        for (int i = 0; i < Insfood.Count; i++)
        {
            if (Insfood[i] != null)
            {
                float distance = Vector3.Distance(currentPos, Insfood[i].transform.position);
                //Debug.Log(i + " | " +distance);
                if (distance <= detect)
                {

                    target = Insfood[i];
                    foundtarget = true;
                    //Debug.Log(target.name + target.transform.position + distance);
                    PickDestination(0, target);
                    return;
                }
                else
                {
                    PickDestination(Range,null);
                    foundtarget = false;
                }

            }
            else
            {
                return;
            }


        }
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
