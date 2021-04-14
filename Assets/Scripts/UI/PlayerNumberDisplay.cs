using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerNumberDisplay : MonoBehaviour
    {
        [SerializeField] private PlayersTurn playersTurn;
        [SerializeField] private TextMeshProUGUI textMesh;

        private void Update()
        {
            textMesh.text = $"Player {playersTurn.playersTurn}";
        }
    }
}
