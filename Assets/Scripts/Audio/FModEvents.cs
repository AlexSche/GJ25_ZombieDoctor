using FMODUnity;
using UnityEngine;

public class FModEvents : MonoBehaviour
{
    [field: Header("Main theme")]
    [field: SerializeField] public EventReference mainTheme { get; private set; }
    [field: Header("Chainsaw SFX")]
    [field: SerializeField] public EventReference sawStroke { get; private set; }
    [field: SerializeField] public EventReference sawChain { get; private set; }

    public static FModEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene");
        }
        instance = this;
    }
}
