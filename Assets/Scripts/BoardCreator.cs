using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private Vector2 size = new Vector2(9, 9);
    [SerializeField] private Color squareColorA = Color.white;
    [SerializeField] private Color squareColorB = Color.black;
    [SerializeField] private List<GameObject> squares = new List<GameObject>();

    private void ClearSquares()
    {
        foreach (var square in squares)
        {
            DestroyImmediate(square);
        }

        squares.Clear();
    }

    private void CreateSquares()
    {
#if UNITY_EDITOR
        var offset = (-size + Vector2.one) / 2;
        for (var y = 0; y < size.y; y++)
        for (var x = 0; x < size.x; x++)
        {
            var square = (GameObject)UnityEditor.PrefabUtility.InstantiatePrefab(squarePrefab);
            square.transform.SetParent(transform);
            square.transform.position = new Vector2(x, y) + offset;
            squares.Add(square);
            square.GetComponent<SpriteRenderer>().color = (size.x * y + x) % 2 == 1 ? squareColorA : squareColorB;
            square.name = $"Square{(char) (65 + y)}{x}";
        }
#endif
    }

#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(BoardCreator))]
    public class Editor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Create Squares"))
                ((BoardCreator) target).CreateSquares();
            if (GUILayout.Button("Clear Squares"))
                ((BoardCreator) target).ClearSquares();
        }
    }
#endif
}