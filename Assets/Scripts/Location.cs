using UnityEngine;

[ExecuteInEditMode]
public class Location : MonoBehaviour
{
    [SerializeField] private Vector2 size = new Vector2(9, 9);
    [SerializeField] private int x;
    [SerializeField] private int y;

    private void Update()
    {
        var offset = (-size + Vector2.one) / 2;
        transform.position = new Vector2(x, y) + offset;
    }
}
