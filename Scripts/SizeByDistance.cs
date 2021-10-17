using UnityEngine;

public class SizeByDistance : MonoBehaviour
{
    public GameObject otherObject;
    public Vector3 scaleWhenClose = Vector3.one;
    public bool invert;
    public float maxDistance = 20;
    Vector3 originalScale;

    void Start()
    {
        // Save the original scale of this object in the beginning
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Calculate the distance between this object's position and the other's
        float distance = Vector3.Distance(transform.position, otherObject.transform.position);

        // Calculate how much percent of the way from 0 to maxDistance it is
        // percentage will always be a value between 0 (far) and 1 (close)
        float percentage = Mathf.InverseLerp(maxDistance, 0, distance);

        // Set the current scale of this object
        if (invert)
        {
            transform.localScale = Vector3.Lerp(scaleWhenClose, originalScale, percentage);
        }
        else
        {
            transform.localScale = Vector3.Lerp(originalScale, scaleWhenClose, percentage);
        }
    }

    // Draw a Wireframe Sphere the size of maxDistance when selected in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
