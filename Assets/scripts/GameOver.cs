using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void gameover()
    {
        GameObject.FindWithTag("Game").GetComponent<SceneAssign>().NextScene("End");
    }
}
