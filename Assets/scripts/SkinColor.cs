using UnityEngine;

public class SkinColor : MonoBehaviour
{
    [SerializeField] Color[] skinrange;

    void Start()
    {
        int randomIndex = Random.Range(0, skinrange.Length);
        Color skin = skinrange[randomIndex];

        GetComponent<SpriteRenderer>().color = skin;
    }
}
