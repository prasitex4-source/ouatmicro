using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> slotPrefabs;
    [SerializeField] private PuzzlePiece piecePrefabs;
    [SerializeField] private Transform slotParent, pieceParent;

    void start()
    {
        Spawn();
    }

    void Spawn()
    {
        var randomSet = slotPrefabs.OrderBy(s = Random.value).take(2).Tolist();

        for (int i = 0; i < randomSet.Count; i++)
        {
            var spawnedSlot = Instantiate(randomSet[i], slotParent.GetChild(i).position, Quaternion.identity);

            var spawnedPiece = Instantiate(piecePrefab, pieceParent.GetChild(i).position, Quaternion.identity);
            spawnedPiece.Init(spawnedSlot);
        }
    }

}
