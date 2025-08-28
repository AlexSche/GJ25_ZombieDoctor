using UnityEngine;

public static class Utils
{
    private static Vector3 GetMouseWorldPos(GameObject gameObject)
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
