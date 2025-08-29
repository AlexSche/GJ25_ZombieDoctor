using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomJoint : MonoBehaviour
{
    [SerializeField] GameObject limbLeft;
    [SerializeField] GameObject limbRight;
    private Rigidbody rb;
    private CharacterJoint limbJointLeft;
    private CharacterJoint limbJointRight;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        limbJointLeft = createJoint(limbLeft.GetComponent<Rigidbody>());
        limbJointRight = createJoint(limbRight.GetComponent<Rigidbody>());
    }

    private CharacterJoint createJoint(Rigidbody limb)
    {
        CharacterJoint limbJoint = new CharacterJoint();
        limbJoint = gameObject.AddComponent<CharacterJoint>();
        limbJoint.connectedBody = limb;
        limbJoint.autoConfigureConnectedAnchor = false;
        limbJoint.connectedAnchor = Vector3.zero;
        limbJoint.enableProjection = true;

        return limbJoint;
    }
}
