using UnityEngine;

public class ExchangeLimb : MonoBehaviour
{
    private MeshFilter meshFilter;
    [SerializeField] private Mesh newLimbMesh;
    [SerializeField] private Transform meshScales;
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
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
        if (meshScales != null)
        {
            KeepScales();
        }
        else
        {
            Debug.Log("No Transform reference for scales set on: " + gameObject.name);
        }
    }

    private void KeepScales()
    {
        transform.localScale = meshScales.localScale;
    }
}
