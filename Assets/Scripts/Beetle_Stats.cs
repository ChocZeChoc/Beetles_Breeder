using UnityEngine;

public class Beetle_Stats : MonoBehaviour
{
    [SerializeField] private int Hunger = 100;
    [SerializeField] public float speed;
    [SerializeField] private int detectRange = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
