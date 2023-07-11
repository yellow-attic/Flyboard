using UnityEngine;



public class ScaleAnimation : MonoBehaviour
{
    public AnimationCurve scaleCurve;
    public float animationTime = 1f;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    [ContextMenu("scale")]
    void Update()
    {
        float timePassed = Time.time - startTime;
        float animationPercent = timePassed / animationTime;
        float scale = scaleCurve.Evaluate(animationPercent);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}



