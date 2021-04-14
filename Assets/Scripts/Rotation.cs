using UnityEngine;

[ExecuteInEditMode]
public class Rotation : MonoBehaviour
{
    [SerializeField] private int rotation;

    private void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, rotation * 90);
    }
}
