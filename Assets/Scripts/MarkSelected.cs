using System;
using UnityEngine;

public class MarkSelected : MonoBehaviour
{
    [SerializeField] private SelectedPiece selectedPiece;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        selectedPiece.selected = null;
    }

    private void OnDisable()
    {
        selectedPiece.selected = null;
    }

    void Update()
    {
        if (selectedPiece.selected)
        {
            spriteRenderer.enabled = true;
            transform.position = selectedPiece.selected.transform.position;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }
}
