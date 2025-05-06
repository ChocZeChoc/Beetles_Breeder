using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Beetle_Stats : MonoBehaviour
{
    [SerializeField] private int Hunger = 100;
    [SerializeField] public float speed;
    [SerializeField] private int detectRange;
    [SerializeField] private bool starving = false;
    [SerializeField] private float dyingTime = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        speed = Random.Range(3, 20);
        detectRange = Random.Range(3, 20);
    }

    // Update is called once per frame

    private void Start()
    {
        StartCoroutine(Hungry());

    }

    private void Update()
    {
        if (Hunger <= 0)
        {
            starving = true;
            Starved();
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.CompareTag("Food"))
        {

            if (Hunger != 100 && Hunger < 100)
            {
                Hunger += 10;
            }
            else return;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
        }
    }

    private void Beetle_Breeding()
    {

    }
    private void Starved()
    {
        if (starving)
        {
            StartCoroutine(dying());
            IEnumerator dying()
            {
                yield return new WaitForSeconds(dyingTime);
                Destroy(gameObject);

            }
        }
        else return;
    }

    IEnumerator Hungry()
    {
        yield return null;
        Hunger--;
        yield return new WaitForSeconds(1f/speed);
        StartCoroutine(Hungry());
        
    }
}
