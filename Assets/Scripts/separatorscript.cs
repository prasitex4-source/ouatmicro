using UnityEngine;

public class separatorscript : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] Vector3 newposition;
    [SerializeField] AudioSource xilophone;


    void MoveCamera()
    {
        camera.transform.position = newposition;
        xilophone.Stop();
    }

    void Done()
    {
        this.gameObject.SetActive(false);
    }

}
