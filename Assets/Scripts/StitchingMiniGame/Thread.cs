using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Thread : MonoBehaviour
{
    Vector3 startPoint = Vector3.zero;
    private LineRenderer lineRenderer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.03f;
        lineRenderer.endWidth = 0.03f;
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
    }
    
    void Start()
    {
        startPoint = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = GetMousePosition();
        DrawThread(startPoint, mousePos);
    }

    private void OnMouseExit()
    {
        // if target position reached break;
        //DrawThread(startPoint, startPoint);
    }

    private Vector3 GetMousePosition()
    {
        float mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mouseZCoord;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePoint);
        pos.y = pos.y + 0.01f;
        return pos;
    }

    private void DrawThread(Vector3 pos1, Vector3 pos2)
    {
        lineRenderer.SetPosition(0, pos1);
        lineRenderer.SetPosition(1, pos2);
    }
}
