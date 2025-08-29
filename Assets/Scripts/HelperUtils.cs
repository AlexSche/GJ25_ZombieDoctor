using UnityEngine;

public static class HelperUtils
{
    public static Vector3 GetMouseWorldPos(GameObject gameObject)
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public static Color[] GenerateColors(int count)
    {
        Color[] colors = new Color[count];

        // Spread hues evenly across the color wheel
        for (int i = 0; i < count; i++)
        {
            float hue = (float)i / count; // range [0,1)
            float saturation = 0.5f;      // keep fairly high for bright colors
            float value = 0.7f;           // high value for vibrancy

            colors[i] = Color.HSVToRGB(hue, saturation, value);
        }

        return colors;
    }
}
