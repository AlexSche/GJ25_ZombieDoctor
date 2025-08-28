using UnityEngine;

public class SawingTablePositionObjects : MonoBehaviour
{
    [SerializeField] private GameObject limbLeft;
    [SerializeField] private GameObject limbRight;
    [SerializeField] private Transform fixedLimbLeftPosition;
    [SerializeField] private GameObject leftBox;
    [SerializeField] private Transform fixedLimbRightPosition;
    [SerializeField] private GameObject rightBox;

    void Start()
    {
        SetLimbsIntoPosition();
    }

    private void SetLimbsIntoPosition()
    {
        // set transform for the objects
        limbLeft.transform.position = fixedLimbLeftPosition.transform.position;
        limbRight.transform.position = fixedLimbRightPosition.transform.position;
        //SetTransformPositions();

        // set direction for the objects (joints face each other)
        Vector3 center = (fixedLimbLeftPosition.position + fixedLimbRightPosition.position) / 2f;
        Vector3 dir = (limbLeft.transform.position - center).normalized;
        limbLeft.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        dir = (center - limbRight.transform.position).normalized;
        limbRight.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
    }
}
