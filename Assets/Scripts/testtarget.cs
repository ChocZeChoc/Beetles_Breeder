using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class TestTarget : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public GameObject food;
    public float detect = 100f;

    public bool foundtarget = false;
    public float Range = 50f;

    public List<GameObject> Insfood = new List<GameObject>();
    private Bush_Spawning bush;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bush = FindFirstObjectByType<Bush_Spawning>();
        if (bush != null)
        {
            Insfood = bush.Insfood;
        }
    }
    // Update is called once per frame
    void Update()
    {
        RemoveFood();
        if (agent.remainingDistance < 2)
        {
            
            LookForTarget(agent.transform.position);
            
        }
        
    }

    void PickDestination(float range,GameObject tar)
    {
        if (!foundtarget)
        {
            return;
        }
        else
        {
            Vector3 targetPos = tar.transform.position;
            var DesPos = new Vector3(targetPos.x, 0 , targetPos.z);
            agent.destination = DesPos;
            
        }
    }

    void LookForTarget(Vector3 currentPos)
    {
        for (int i = 0; i < Insfood.Count; i++)
        {
            if (Insfood[i] != null)
            {
                float distance = Vector3.Distance(currentPos, Insfood[i].transform.position);
                if (distance <= detect)
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
