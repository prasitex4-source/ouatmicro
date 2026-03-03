using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;
    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip complete;

    void Placed()
    {
        aSource.PlayOneShot(complete);
    }
}
