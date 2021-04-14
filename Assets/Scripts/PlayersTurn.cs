using UnityEngine;

public class PlayersTurn : ScriptableObject
{
    public int playersTurn;

    public void Toggle()
    {
        if (playersTurn == 1)
        {
            playersTurn = 2;
        }
        else if (playersTurn == 2)
        {
            playersTurn = 1;
        }
    }
}
