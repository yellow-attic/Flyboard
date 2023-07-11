using UnityEngine;


public class FadeEffect : MonoBehaviour
{
    [SerializeField] Color colorfull;
    [SerializeField] Color colorempty;

    [SerializeField] float _fadeTime;

    private SpriteRenderer _fadeimage;
    private Color targetcolor;
    private Color currentcolor;
    private float _currentTime = 0f;


    void Start()
    {
        _fadeimage = GetComponent<SpriteRenderer>();
        _fadeimage.color = colorempty;
        currentcolor = colorempty;
        targetcolor = currentcolor;
    }

    void Update()
    {
        if (targetcolor != currentcolor)
        {
            _currentTime += Time.deltaTime;
            float t = _currentTime / _fadeTime;
            _fadeimage.color = Color.Lerp(currentcolor, targetcolor, t);

            if (t >= 1)
            {
                currentcolor = targetcolor;
                _fadeimage.color = targetcolor;
            }
        }
    }


    public void FadeIN()
    {
        targetcolor = colorfull;
    }
    public void FadeOUT()
    {
        targetcolor = colorempty;
    }

}