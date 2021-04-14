using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    [SerializeField] private PlayersTurn playersTurn;
    [SerializeField] private PieceDB pieceDB;
    [SerializeField] private SelectedPiece selectedPiece;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int x;
    [SerializeField] private int y;
    private float offset = (9f - 1f) / 2;
    
    private void Update()
    {
        var screenMousePosition = Input.mousePosition;
        var worldMousePosition = mainCamera.ScreenToWorldPoint(screenMousePosition);
        x = Mathf.RoundToInt(worldMousePosition.x + offset);
        y = Mathf.RoundToInt(worldMousePosition.y + offset);
        if (pieceDB.ContainsPieceAt(playersTurn.playersTurn, x, y))
        {
            spriteRenderer.enabled = true;
            transform.position = new Vector2(x - offset, y - offset);
            if (Input.GetMouseButtonDown(0))
                selectedPiece.selected = pieceDB.GetPieceAt(playersTurn.playersTurn, x, y);
        }
        else
        {
            spriteRenderer.enabled = false;
            if (Input.GetMouseButtonDown(0))
                selectedPiece.selected = null;
        }
    }
}
