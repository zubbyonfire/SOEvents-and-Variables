using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ScriptableVariableAndEventExample
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class GameOverText : MonoBehaviour
    {
        private TextMeshProUGUI gameOverText; //Ref to the textMeshProUGUI component

        // Start is called before the first frame update
        private void Start()
        {
            //Get the component and disable it
            gameOverText = GetComponent<TextMeshProUGUI>();
            gameOverText.enabled = false;
        }

        /// <summary>
        /// Enable the text when the game is over
        /// </summary>
        public void GameOverEnabled()
        {
            gameOverText.enabled = true;
        }
    }
}
