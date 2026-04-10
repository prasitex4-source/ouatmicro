using UnityEngine;

public class separatorscript : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] Vector3 newposition;


    void MoveCamera()
    {
        camera.transform.position = newposition;
    }

}
