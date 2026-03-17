using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] Image timerBackground;
    [SerializeField] Image timerForeground;

    float timeRemaining;
    public float maxTime;

    void Start()
    {
        timeRemaining = maxTime;
    }

    void Update()
    {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerForeground.fillAmount = timeRemaining / maxTime;
        }
        else
        {
            SceneManager.LoadScene("Win");
        }

    }
}
