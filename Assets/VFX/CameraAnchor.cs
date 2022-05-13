using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
    public float spinVelocity;

    public void Update()
    {
        transform.Rotate(new Vector3(0, spinVelocity * Time.deltaTime, 0));
    }
}
