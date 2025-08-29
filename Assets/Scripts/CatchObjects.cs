using UnityEngine;

public class CatchObjects : MonoBehaviour
{
    [SerializeField] private GameObject pos1;
    private bool pos1Set = false;
    private GameObject limbOnPosition1;
    [SerializeField] private GameObject pos2;
    private bool pos2Set = false;
    private GameObject limbOnPosition2;
    private BoxCollider boxCollider;
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Limb"))
        {
            GameObject limb = collision.gameObject;
            Debug.Log("Table collided with " + limb.name);
            if (limb.transform.parent.tag == "SawAble")
            {
                Debug.Log("Can saw");
                if (!pos1Set)
                {
                    pos1Set = true;
                    limbOnPosition1 = limb;
                    //pos1.GetComponent<SnapToPoint>().SnapTargetToPosition(limb);
                    //limb.GetComponent<Rigidbody>().position = pos1.transform.position;
                }
                else if (!pos2Set)
                {
                    if (limbOnPosition1 == limb) return;
                    pos2Set = true;
                    //pos2.GetComponent<SnapToPoint>().SnapTargetToPosition(limb);
                    //limb.GetComponent<Rigidbody>().position = pos2.transform.position;
                }
                else
                {
                    Debug.Log("Station is full!");
                }
            }
        }
    }
}
