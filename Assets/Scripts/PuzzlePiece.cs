using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Renderer;

    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip pickUp, drop;

    private bool dragging;

    Vector2 offset, originalPos;

    private PuzzleSlot slot;

    public void Init(PuzzleSlot)
    {
        Renderer.sprite = slot.Renderer.sprite;
        slot = slot;
    }

    void Awake()
    {
        originalPos = transform.position;
    }

    private void Update()
    {
        if (!dragging) return;

        var mousePos = GetMousePos();

        transform.position = mousePos - offset;
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
        aSource.PlayOneShot(drop); 

        transform.position = originalPos;
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition); 
    }
}
