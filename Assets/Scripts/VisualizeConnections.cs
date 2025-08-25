using UnityEngine;

public class VisualizeConnections : MonoBehaviour
{
    [SerializeField] private GameObject leftStation;
    [SerializeField] private GameObject rightStation;
    private GameObject[] lines;
    void Start()
    {
        drawLine();
    }
    private void drawLine()
    {
        GameObject gameObject = new GameObject("line");
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.SetPosition(0, leftStation.transform.position);

        // TODO: stitching line between the two objects
        //drawAround(leftStation.transform);
        //drawAround(rightStation.transform);

        lineRenderer.SetPosition(1, rightStation.transform.position);
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
    }


    public static void drawAround(Transform transform)
    {
        Vector3 input = transform.position;
        float radius = 1 * (transform.localScale.y / 2);
        Vector3 topLeft = new Vector3(input.x - radius, input.y + radius, 0);
        Vector3 topRight = new Vector3(input.x + radius, input.y + radius, 0);
        Vector3 bottomLeft = new Vector3(input.x - radius, input.y - radius, 0);
        Vector3 bottomRight = new Vector3(input.x + radius, input.y - radius, 0);
        Debug.DrawLine(topLeft, topRight, Color.white, 100f);
        Debug.DrawLine(topRight, bottomRight, Color.blue, 100f);
        Debug.DrawLine(bottomRight, bottomLeft, Color.yellow, 100f);
        Debug.DrawLine(bottomLeft, topLeft, Color.red, 100f);
    }
}
