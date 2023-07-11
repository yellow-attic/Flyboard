using System.Collections;
using UnityEngine;

public class LevelDifficult : MonoBehaviour
{
    [SerializeField] float betweentime = 10f;

    private IEnumerator Start()
    {
        if (GetComponentInChildren<Man>().speed < 20f)
        {
            while (true)
            {
                yield return new WaitForSeconds(betweentime);
                GetComponentInChildren<Man>().speed += 0.5f;

                Debug.Log("Level Up");
            }
        }
    }
}

