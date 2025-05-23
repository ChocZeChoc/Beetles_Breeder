using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Beetle_Stats : MonoBehaviour
{
    public int Hunger = 120;
    public float speed;
    public float detectRange;
    private bool starving = false;
    private float dyingTime = 20f;
    public float age = 0;
    private float maxAge = 60;
    private float hungerTime = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        speed = Random.Range(1, 50);
        detectRange = Random.Range(1, 50);
    }

    // Update is called once per frame

    private void Start()
    {
        StartCoroutine(Living());
    }

    private void Update()
    {
        if (Hunger <= 0)
        {
            starving = true;
            Starved();
        }
        if (Hunger > 0) 
        {
            starving= false;
            Starved();
        }
        age = age + Time.deltaTime;
        if (age >= maxAge)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.CompareTag("Food"))
        {

            if (Hunger < 100)
            {
                Hunger += 10;
                
            }
            else return;
            Destroy(other.gameObject);
        }
    }
    

    private void Starved()
    {
        if (starving)
        {
            StartCoroutine(dying());
        }
        else if (!starving) 
        {
            StopCoroutine(dying());
        }
        IEnumerator dying()
        {
            yield return new WaitForSeconds(dyingTime);
            Destroy(gameObject);

        }
    }

    IEnumerator Living()
    {
        if(Hunger > 0)
        {
            yield return null;
            Hunger--;
            if (speed <= 0)
            {
                Hunger = 0;
            }
            else { yield return new WaitForSeconds(hungerTime / speed); }
            StartCoroutine(Living());
        }
    }



}
