using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//We need to add the ScriptableObjectVariable library
using ScriptableObjectVariable;

namespace ScriptableVariableAndEventExample
{
    [RequireComponent(typeof(Image))]
    public class HealthBarLogic : MonoBehaviour
    {
        [SerializeField]
        private SOInt playerHealth = null; //How much health the player has

        private Image healthBar; //Ref to the health bar canvas image

        // Start is called before the first frame update
        void Start()
        {
            healthBar = GetComponent<Image>();

            //Update the fill amount at the start of the level
            UpdateFillBar();
        }

        public void UpdateFillBar()
        {
            //If the player health is greater or equal to 0 set the image fill accordingly
            //If the value is less than 0, then set it to 0
            if (playerHealth.value >= 100)
            {
                healthBar.fillAmount = 1;
            }
            else if (playerHealth.value >= 0)
            {
                //Divide the health value by 100, to get an amount between 0 and 100 (cast it to a float)
                healthBar.fillAmount = (float)playerHealth.value / 100;
            }
            else
            {
                healthBar.fillAmount = 0;
            }

        }
    }
}
