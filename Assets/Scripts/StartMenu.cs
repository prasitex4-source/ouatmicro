using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject boton;
    [SerializeField] Between_Buttons parche;

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
