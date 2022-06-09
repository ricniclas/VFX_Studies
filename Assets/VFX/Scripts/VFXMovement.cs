using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXMovement : MonoBehaviour
{
    public float velocity;
    public bool moving = false;
    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            gameObject.transform.Translate(new Vector3(velocity, 0, 0) * Time.deltaTime);
        }
    }
}
