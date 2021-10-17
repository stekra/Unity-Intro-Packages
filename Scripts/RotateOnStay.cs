using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnStay : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 rotationPerAxis;

    void OnTriggerStay(Collider other)
    {
        targetObject.transform.Rotate(rotationPerAxis * Time.deltaTime);
    }
}
