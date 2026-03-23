using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] Image timerBackground;
    [SerializeField] Image timerForeground;

    public int pieces = 0;

    float timeRemaining;
    public float maxTime;

    void Start()
    {
        timeRemaining = maxTime;
    }

    void Update()
    {
        Debug.Log(pieces);

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerForeground.fillAmount = timeRemaining / maxTime;

            if (pieces == 7)
            {
                SceneManager.LoadScene("Win");
            }
        }
        else
        {
            SceneManager.LoadScene("Win");
        }

    }
}
