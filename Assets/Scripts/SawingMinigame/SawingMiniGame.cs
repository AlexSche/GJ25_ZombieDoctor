using UnityEngine;

public class SawingMinigame : MonoBehaviour
{
    [SerializeField] private GameObject chainsaw;
    private Transform chainsawDefaultTransform;
    void Start()
    {
        chainsawDefaultTransform = chainsaw.transform;
        GameEvents.SawingMiniGameEvent.OnMiniGameFinished += RepositionProps;
    }

    public void RepositionProps()
    {
        chainsaw.GetComponent<Pickable>().RemoveJoint();
        Rigidbody rb = chainsaw.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.transform.position = chainsawDefaultTransform.position;
        Debug.Log(chainsawDefaultTransform.position);
        rb.isKinematic = false;
        //chainsaw.transform.position = chainsawDefaultTransform.position;
    }
}
