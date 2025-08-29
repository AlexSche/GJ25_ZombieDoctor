using FMOD.Studio;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Thread : MonoBehaviour
{
    private int number;
    private Color[] colorIndex;
    [SerializeField] private TextMeshPro textMeshPro;
    Vector3 startPoint = Vector3.zero;
    private LineRenderer lineRenderer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.03f;
        lineRenderer.endWidth = 0.03f;
        colorIndex = HelperUtils.GenerateColors(10);
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

    private void OnMouseUp()
    {
        Vector3 mouseWorldPos = GetMousePosition();
        Collider[] overlapping = Physics.OverlapSphere(mouseWorldPos, 0.01f);
        if (overlapping.Length == 0)
        {
            ResetThread();
        }
        foreach (Collider c in overlapping)
        {
            if (c != GetComponent<Collider>() && c.GetComponent<Thread>() != null)
            {
                Thread thread = GetComponent<Thread>();
                if (thread.number == number)
                {
                    Debug.Log("stitched this line " + number);
                    // mark this thread and the other as solved!
                }
            }
        }
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

    public void SetNumber(int value)
    {
        number = value;
        textMeshPro.text = number.ToString();
        spriteRenderer.color = colorIndex[value];
    }

    private void ResetThread()
    {
        DrawThread(gameObject.transform.position, gameObject.transform.position);
    }
}
