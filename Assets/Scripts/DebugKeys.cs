using UnityEngine;

public class DebugKeys : MonoBehaviour
{
    [SerializeField] private PlayersTurn playersTurn;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            playersTurn.playersTurn = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            playersTurn.playersTurn = 2;
    }
}
