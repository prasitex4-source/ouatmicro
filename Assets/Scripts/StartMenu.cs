using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject boton;
    [SerializeField] PuzzlePiece parche;

    private void Update()
    {
        if (parche.locked)
        {
            boton.SetActive(true);
        }
    }
    public void OnStartClick()
    {
        SceneManager.LoadScene("Puzzle base");
    }
}
