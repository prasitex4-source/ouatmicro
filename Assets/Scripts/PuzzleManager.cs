using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PuzzleManager : MonoBehaviour
{
    bool loadingStarted = false;
    bool finished = false;
    float secondsLeft = 0;

    void Start()
    {
        StartCoroutine(DelayLoadLevel(10));
    }

    IEnumerator DelayLoadLevel(float seconds)
    {
        secondsLeft = seconds;
        loadingStarted = true;
        do
        {
            yield return new WaitForSeconds(1);
        } while (--secondsLeft > 0 && !finished);

        if(finished)
        {
            SceneManager.LoadScene("Win");
        }

        SceneManager.LoadScene("Fail");
    }

    void OnGUI()
    {
        if (loadingStarted)
            GUI.Label(new Rect(0, 0, 100, 20), secondsLeft.ToString());
    }
}
