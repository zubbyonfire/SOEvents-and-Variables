using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We need to add the ScriptableObject Variable & Event libraries
using ScriptableObjectEvent;
using ScriptableObjectVariable;

namespace ScriptableVariableAndEventExample
{
    public class LeftClick_Damage : MonoBehaviour
    {
        //Damage event
        [SerializeField]
        private SOGameEvent damagePlayer = null;

        //Game Over event
        [SerializeField]
        private SOGameEvent gameOver = null;

        //PlayerHealth and healtAmount ref
        [SerializeField]
        private SOInt playerHealth = null, damageAmount = null;

        //Ref to the playerCube
        [SerializeField]
        private GameObject playerCube = null;

        //Main camera ref
        private Camera mainCamera = null;

        // Start is called before the first frame update
        void Start()
        {
            //Get a ref to the mainCamera
            mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (playerCube != null) //If the player cube has been assigned
                    {
                        if (hit.collider.gameObject == playerCube) //If we hit the playerCube
                        {
                            DamagePlayer(); //Damage the player

                            damagePlayer.Raise(); //Raise the damage player event
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Reduce the playerHealth by the damageAmount
        /// </summary>
        private void DamagePlayer()
        {
            //Redue the playerHealth by the damageAmount
            playerHealth.value -= damageAmount.value;

            //If health value is less than 0 - set it to 0
            if (playerHealth.value < 0)
            {
                playerHealth.value = 0;
            }

            //If player health equals 0 - raise the game over event
            if (playerHealth.value == 0)
            {
                gameOver.Raise();
            }
        }
    }
}
