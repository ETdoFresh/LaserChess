using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PieceDB : ScriptableObject
{
    public List<GameObject> pieces = new List<GameObject>();
    public List<GameObject> player1Pieces = new List<GameObject>();
    public List<GameObject> player2Pieces = new List<GameObject>();

    public void Add(GameObject piece)
    {
        pieces.Add(piece);
        var owner = piece.GetComponent<PieceOwner>();
        if (owner)
            if (owner.owner == 1) player1Pieces.Add(piece);
            else if (owner.owner == 2) player2Pieces.Add(piece);
    }

    public void Clear()
    {
        pieces.Clear();
        player1Pieces.Clear();
        player2Pieces.Clear();
    }

    public void Remove(GameObject gameObject)
    {
        pieces.Remove(gameObject);
        player1Pieces.Remove(gameObject);
        player2Pieces.Remove(gameObject);
    }

    public bool ContainsPieceAt(int player, int x, int y)
    {
        if (player != 1 && player != 2) return false;
        var playerPieces = player == 1 ? player1Pieces : player2Pieces;
        return playerPieces
            .Select(piece => piece.GetComponent<Location>())
            .Any(location => location && location.X == x && location.Y == y);
    }
    
    public GameObject GetPieceAt(int player, int x, int y)
    {
        if (player != 1 && player != 2) return null;
        var playerPieces = player == 1 ? player1Pieces : player2Pieces;
        return playerPieces
            .Select(piece => piece.GetComponent<Location>())
            .Where(location => location && location.X == x && location.Y == y)
            .Select(location => location.gameObject)
            .FirstOrDefault();
    }
}