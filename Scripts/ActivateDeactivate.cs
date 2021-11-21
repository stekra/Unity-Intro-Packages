using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivate : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;

    private void OnTriggerEnter(Collider other)
    {
        if (objectToActivate != null) objectToActivate.SetActive(true);
        if (objectToDeactivate != null) objectToDeactivate.SetActive(false);
    }
}
