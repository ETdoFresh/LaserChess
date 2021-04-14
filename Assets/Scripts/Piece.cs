using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private PieceDB pieceDB;

    private void OnEnable()
    {
        pieceDB.Add(gameObject);
    }

    private void OnDisable()
    {
        pieceDB.Remove(gameObject);
    }
}
