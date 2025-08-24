using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour
{
    private float mouseZCoord;
    private Rigidbody rb;

    private SpringJoint grabJoint;
    private Rigidbody grabAnchor;
    private float spring = 1000f;
    private float damper = 50f;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        createAnchor();
        createJoint();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mouseZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        grabAnchor.MovePosition(GetMouseWorldPos());
    }

    void OnMouseUp()
    {
        if (grabJoint != null)
            Destroy(grabJoint);
    }

    private void createAnchor()
    {
        if (grabAnchor == null)
        {
            // Create invisible anchor - character breaks if you pick it up by the body itself
            GameObject go = new GameObject("GrabAnchor");
            grabAnchor = go.AddComponent<Rigidbody>();
            grabAnchor.isKinematic = true;
        }
        grabAnchor.position = transform.position;
    }

    private void createJoint()
    {
        grabJoint = gameObject.AddComponent<SpringJoint>();
        grabJoint.connectedBody = grabAnchor;
        grabJoint.spring = spring;
        grabJoint.damper = damper;
        grabJoint.autoConfigureConnectedAnchor = false;
        grabJoint.connectedAnchor = Vector3.zero;
    }
}
