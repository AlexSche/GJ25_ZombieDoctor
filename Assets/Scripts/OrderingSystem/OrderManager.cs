using System.Collections;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CreateOrder()
    {
        yield return new WaitForSeconds(0);
    }
}
