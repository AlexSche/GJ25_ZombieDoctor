using UnityEngine;

public class LineFollower : MonoBehaviour
{
    private Camera cam;
    private float progress = 0f;
    private Vector3 start;
    private Vector3 end;
    private Vector3 direction;
    private float distance;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Material gooMaterial;
    public bool isComplete = false;
    void Awake()
    {
        cam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // if the line is hit - the object this script sits on
                if (hit.collider.gameObject == gameObject)
                {
                    // mouse is on the line
                    Progress();
                }
            }
        }
        if (progress > 0.55f)
        {
            if (!isComplete)
            {
                AudioManager.instance.PlayOneShotReferenceSound(FModEvents.instance.sawStroke, transform.position);
                if (gooMaterial)
                {
                    spriteRenderer.material = gooMaterial;
                }
                else
                {
                    spriteRenderer.color = new Color(1, 1, 1);
                }
                // shoot the event that THIS line has been followed
                isComplete = true;
                GameEvents.SawingMiniGameEvent.OnLineComplete.Invoke();
            }
        }
    }

    public void Initialize(Vector3 start, Vector3 end, Vector3 direction, float distance)
    {
        this.start = start;
        this.end = end;
        this.direction = direction;
        this.distance = distance;
    }

    void Progress()
    {
        Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

        Vector3 lineDir = direction.normalized;
        float lineLength = distance;

        // Vector from start to mouse
        Vector3 toMouse = mouseWorld - start;

        // Project mouse onto line and get normalized progress
        float dot = Vector3.Dot(toMouse, lineDir);
        float t = Mathf.Clamp01(dot / lineLength);

        // Update progress if mouse moves forward along the line
        if (t > progress)
            progress = t;

        Debug.Log($"Line followed: {progress * 100f:0}%");
    }
}
