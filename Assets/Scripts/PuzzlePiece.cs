using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PuzzlePiece : MonoBehaviour
{
    public GameObject correctPlace;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip pickUp;
    [SerializeField] private AudioClip yay;
    [SerializeField] private AudioClip oh;


    [SerializeField] public float distance;

    float z1;
    float z2;
    public float angleDiff;

    private bool dragging;
    public bool locked;

    Vector2 offset, originalPos;

    public Timer Timer;

    void Awake()
    {
        originalPos = transform.position;

        z1 = this.transform.localEulerAngles.z;
        z2 = correctPlace.transform.localEulerAngles.z;
        angleDiff = Mathf.Abs(Mathf.DeltaAngle(z1, z2));
    }

    private void Update()
    {
        if (!locked)
        {
            if (!dragging) return;

            if (Mouse.current.rightButton.wasPressedThisFrame && dragging)
            {
                Rotate();
            }

            var mousePos = GetMousePos();

            transform.position = mousePos - offset;
        }

        Debug.Log(z1 + z2);


    }

    void OnMouseDown()
    {
        dragging = true;
        aSource.PlayOneShot(pickUp);

        offset = GetMousePos() - (Vector2)transform.position;

    }

    void OnMouseUp() 
    { 
        dragging = false;

        float z1 = this.transform.localEulerAngles.z;
        float z2 = correctPlace.transform.localEulerAngles.z;
        float angleDiff = Mathf.Abs(Mathf.DeltaAngle(z1, z2));

        if (Mathf.Abs(this.transform.localPosition.x - correctPlace.transform.localPosition.x) <= distance &&
            Mathf.Abs(this.transform.localPosition.y - correctPlace.transform.localPosition.y) <= distance &&
            (angleDiff <= distance))
        {
            this.transform.position = new Vector2(correctPlace.transform.position.x, correctPlace.transform.position.y);
            aSource.PlayOneShot(yay);
            locked = true;

            Timer.pieces += 1;
        }
        else
        {
            aSource.PlayOneShot(oh);
            transform.position = originalPos;
        }
    }

    public void Rotate()
    {
        if (dragging)
        {
            this.transform.Rotate(0, 0, 45);
        }

    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition); 
    }
}
