using UnityEngine;

[RequireComponent(typeof(Pickable))]
public class SnapToPoint : MonoBehaviour
{
    [Header("Snap Settings")]
    public string snapTag = "SnapPoint";   // Tag of snap targets
    public float snapRange = 1.0f;         // Distance required to create joint
    public float desnapDistance = 2.0f;    // Distance at which joint breaks

    [Header("Spring Joint Settings")]
    public float springForce = 1000f;      // Pulling strength
    public float damper = 100f;            // Smooth damping
    public float tolerance = 0.05f;        // Small tolerance to avoid jitter
    public float maxDistance = 0.05f;      // Max distance the spring can stretch

    private bool isSnapped = false;
    private Transform snapTarget;
    private SpringJoint snapJoint;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isSnapped && snapTarget != null)
        {
            float dist = Vector3.Distance(transform.position, snapTarget.position);

            // Break if dragged away
            if (dist > desnapDistance)
            {
                ReleaseSnap();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isSnapped && other.CompareTag(snapTag))
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);

            if (distance <= snapRange)
            {
                SnapTo(other.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == snapTarget)
        {
            ReleaseSnap();
        }
    }

    private void SnapTo(Transform target)
    {
        snapTarget = target;
        isSnapped = true;

        // Create spring joint
        if (snapJoint == null)
        {
            snapJoint = gameObject.AddComponent<SpringJoint>();
        }

        Rigidbody targetRb = target.GetComponent<Rigidbody>();
        if (targetRb == null)
        {
            // Add a kinematic rigidbody to snap point if missing
            targetRb = target.gameObject.AddComponent<Rigidbody>();
            targetRb.isKinematic = true;
        }

        snapJoint.connectedBody = targetRb;
        snapJoint.autoConfigureConnectedAnchor = false;
        snapJoint.connectedAnchor = Vector3.zero;
        snapJoint.anchor = Vector3.zero;

        // Spring settings
        snapJoint.spring = springForce;
        snapJoint.damper = damper;
        snapJoint.tolerance = tolerance;
        snapJoint.maxDistance = maxDistance;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void ReleaseSnap()
    {
        isSnapped = false;
        snapTarget = null;

        if (snapJoint != null)
        {
            Destroy(snapJoint);
            snapJoint = null;
        }
    }
}
