using System.Collections.Generic;
using UnityEngine;

public class GenerateStitchingLine : MonoBehaviour
{
    private int stitches = 6;
    private List<GameObject> gameObjects = new List<GameObject>();
    void Start()
    {
        //drawLine();
        //drawAround(transform);
        Renderer rend = GetComponent<Renderer>();
        Bounds bounds = rend.bounds;
        Vector3 topLeft = new Vector3(bounds.min.x, bounds.max.y, bounds.min.z);
        Vector3 bottomLeft = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z);
        Vector3 topRight = new Vector3(bounds.min.x, bounds.max.y, bounds.max.z);
        Vector3 bottomRight = new Vector3(bounds.max.x, bounds.min.y, bounds.max.z);
        Vector3 randPointLeft = getRandomPointBetween(topLeft, bottomLeft);
        Vector3 randPointRight = getRandomPointBetween(topRight, bottomRight);
        for (int i = 0; i <= stitches; i++)
        {
            drawLine(randPointLeft, randPointRight);
            if (i % 2 == 0)
            {
                randPointLeft = getRandomPointBetween(topLeft, bottomLeft);
            }
            else
            {
                randPointRight = getRandomPointBetween(topRight, bottomRight);
            }
        }
    }
    private void drawLine(Vector3 pos1, Vector3 pos2)
    {
        GameObject gameObject = new GameObject("line");
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.SetPosition(0, pos1);
        lineRenderer.SetPosition(1, pos2);
        lineRenderer.startWidth = 0.03f;
        lineRenderer.endWidth = 0.03f;
        gameObjects.Add(gameObject);
    }

    private Vector3 getRandomPointBetween(Vector3 top, Vector3 bottom)
    {
        float randomValue = Random.Range(0, 1f);
        Vector3 dir = top - bottom;
        Vector3 randomPoint = bottom + randomValue * dir.normalized;
        return randomPoint;
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

    private static void drawAround(Renderer rend)
    {
        Bounds bounds = rend.bounds;
        Vector3 topLeft = new Vector3(bounds.min.x, bounds.max.y, bounds.min.z);
        Vector3 bottomLeft = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z);
        Vector3 topRight = new Vector3(bounds.min.x, bounds.max.y, bounds.max.z);
        Vector3 bottomRight = new Vector3(bounds.max.x, bounds.min.y, bounds.max.z);
        Debug.DrawLine(topLeft, bottomLeft, Color.white, 100f);
        Debug.DrawLine(topRight, bottomRight, Color.white, 100f);
    }
}
