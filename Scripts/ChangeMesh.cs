using UnityEngine;

public class ChangeMesh : MonoBehaviour
{
    public GameObject targetObject;
    public Mesh newMesh;

    void OnTriggerEnter(Collider other)
    {
        targetObject.GetComponent<MeshFilter>().mesh = newMesh;
    }
}
