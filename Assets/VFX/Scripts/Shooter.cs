using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject projectileEffect;

    [SerializeField]
    private Transform shootPoint;

    [SerializeField]
    private float shootDelay;


    private void Start()
    {
        StartCoroutine(shootCorroutine());
    }

    private IEnumerator shootCorroutine()
    {
        yield return new WaitForSeconds(shootDelay);
        GameObject fireball = Pools.SharedInstance.GetPooledObject();
        if(fireball != null)
        {
            fireball.transform.position = shootPoint.position;
            fireball.transform.rotation = Quaternion.Euler(Vector3.right);
            fireball.SetActive(true);
            StartCoroutine(shootCorroutine());
        }
        else
        {
            fireball = Pools.SharedInstance.ExpandPool();
            fireball.transform.position = shootPoint.position;
            fireball.transform.rotation = Quaternion.Euler(Vector3.right);
            fireball.SetActive(true);
            StartCoroutine(shootCorroutine());
        }
    }

    public void ReceiveMessage(MessageType argument)
    {
        if(argument == MessageType.TYPE1)
        {
            Debug.Log(this.name + " Received the message!");
        }
    }
}
