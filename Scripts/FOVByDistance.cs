using UnityEngine;

public class FOVByDistance : MonoBehaviour
{
    public GameObject otherObject;
    public float FOVWhenClose = 25;
    public float maxDistance = 5;
    float originalFOV;

    void Start()
    {
        originalFOV = GetComponent<Camera>().fieldOfView;
    }

    void Update()
    {
        // Calculate the distance between this object's position and the other's
        float distance = Vector3.Distance(transform.position, otherObject.transform.position);

        // Calculate how much percent of the way from 0 to maxDistance it is
        // percentage will always be a value between 0 (far) and 1 (close)
        float percentage = Mathf.InverseLerp(maxDistance, 0, distance);

        // Set the FOV of the camera of this object
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(originalFOV, FOVWhenClose, percentage);
    }

    // Draw a Wireframe Sphere the size of maxDistance when selected in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
