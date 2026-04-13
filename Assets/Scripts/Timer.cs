using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Image timerForeground;

    public int pieces = 0;

    [Header("Tiempo")]
    [SerializeField] float totalTime;   // Cuándo termina el juego
    [SerializeField] float freezeTime;  // Desde cuándo la barra se congela

    float timeRemaining;
    bool gameEnded = false;

    void Start()
    {
        timeRemaining = totalTime;
    }

    void Update()
    {
        if (gameEnded) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            // Parte en la que la barra baja
            if (timeRemaining > freezeTime)
            {
                float activeDuration = totalTime - freezeTime;
                float normalizedTime = (timeRemaining - freezeTime) / activeDuration;
                timerForeground.fillAmount = normalizedTime;
            }
            // Parte congelada
            else
            {
                timerForeground.fillAmount = 0f;
            }

            // Victoria
            if (pieces == 7)
            {
                gameEnded = true;
                SceneManager.LoadScene("Win");
            }
        }
        else
        {
            // Derrota
            gameEnded = true;
            SceneManager.LoadScene("Fail");
        }
    }
}