using UnityEngine;

public class ExchangeLimb : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Rigidbody rb;
    [SerializeField] private Mesh newLimbMesh;
    [SerializeField] private Transform meshTransform;
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        rb = GetComponent<Rigidbody>();
        if (newLimbMesh != null)
        {
            ExchangeActiveLimb();
        }
        else
        {
            Debug.Log("No new limb set on: " + gameObject.name);
        }
    }

    private void ExchangeActiveLimb()
    {
        meshFilter.mesh = newLimbMesh;
        if (meshTransform != null)
        {
            KeepTransform();
        }
        else
        {
            Debug.Log("No Transform reference for scales set on: " + gameObject.name);
        }
    }

    private void KeepTransform()
    {
        //Vector3 newScale = new Vector3(meshTransform.localScale.x, transform.localScale.y, meshTransform.localScale.z);
        //transform.localScale = newScale;
        Vector3 eulerRotation = new Vector3(meshTransform.transform.eulerAngles.x, meshTransform.transform.eulerAngles.y, meshTransform.transform.eulerAngles.z);
        rb.rotation = Quaternion.Euler(eulerRotation);
    }
}
