using UnityEngine;

public class PackageColor : MonoBehaviour
{
    float saturation = 0.63f; 
    float value = 0.84f;


    public Color SetPackageColor()
    {
        float hue = Random.Range(0f, 1f);
        Color packagecolor = Color.HSVToRGB(hue, saturation, value);

        transform.Find("color").gameObject.GetComponent<SpriteRenderer>().color = packagecolor;

        return packagecolor;
    }
}
