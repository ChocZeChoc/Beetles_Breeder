using System.Collections;
using UnityEngine;

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
}
