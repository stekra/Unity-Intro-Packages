using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    public GameObject targetObject;
    public Vector3 newRelativePosition;

    public bool onlyOnce;
    bool didItAtLeastOnce;

    public bool smooth;
    [Tooltip("In seconds")]
    public float smoothSpeed = 1f;
    Vector3 integration;

    void Update()
    {
        // Smoothly interpolate to target position
        if (smooth && didItAtLeastOnce && (integration.sqrMagnitude < newRelativePosition.sqrMagnitude))
        {
            targetObject.transform.position += newRelativePosition * Time.deltaTime * smoothSpeed;

            integration += newRelativePosition * Time.deltaTime * smoothSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If onlyOnce is checked and script was triggered once, skip everything
        if (onlyOnce && didItAtLeastOnce)
        {
            return;
        }

        didItAtLeastOnce = true;

        // If smooth is checked, skip (smoothing is done in Update())
        if (smooth)
        {
            return;
        }

        // Add newRelativePosition to this objects position
        targetObject.transform.position = targetObject.transform.position + newRelativePosition;
    }
}
