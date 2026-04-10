using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("Puzzle base");
    }
}
