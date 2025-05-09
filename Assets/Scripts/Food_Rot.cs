using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Food_Rot : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Rot());
    }

    IEnumerator Rot()
    {
        yield return new WaitForSeconds(Random.Range(10,20));
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.CompareTag("Beetle"))
        {

            Destroy(gameObject);
        }
    }
}
