using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private float velocity = 3;

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.right * velocity) * Time.deltaTime); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            GameObject explosion = Pools.SharedInstance.returnToPool.getPolledObject();
            explosion.SetActive(true);
            explosion.transform.position = gameObject.transform.position;
            gameObject.SetActive(false);
        }
    }


    private void explode()
    {
        Debug.Log("Exploded!");
    }
}
