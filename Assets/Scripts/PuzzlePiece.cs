using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PuzzlePiece : MonoBehaviour
{
    public GameObject correctPlace;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip pickUp;

    [SerializeField] public float distance;

    private bool dragging;
    private bool locked;

    Vector2 offset, originalPos;

    public Timer Timer;

    void Awake()
    {
        originalPos = transform.position;
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

        if (Mathf.Abs(this.transform.localRotation.z - correctPlace.transform.localRotation.z) <= distance)
        {
            Debug.Log("rotación ok");

            if (Mathf.Abs(this.transform.localPosition.x - correctPlace.transform.localPosition.x) <= distance &&
                Mathf.Abs(this.transform.localPosition.y - correctPlace.transform.localPosition.y) <= distance)
            {
                this.transform.position = new Vector2(correctPlace.transform.position.x, correctPlace.transform.position.y);
                locked = true;

                Timer.pieces += 1;
            }

        }


        else
        {
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
