using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We need to add the ScriptableObject Variable & Event libraries
using ScriptableObjectEvent;
using ScriptableObjectVariable;

namespace ScriptableVariableAndEventExample
{
    public class RightClick_Heal : MonoBehaviour
    {
        //Heal event
        [SerializeField]
        private SOGameEvent healPlayer = null;

        //PlayerHealth and healtAmount ref
        [SerializeField]
        private SOInt playerHealth = null, healAmount = null;

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
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (playerCube != null) //If the player cube has been assigned
                    {
                        if (hit.collider.gameObject == playerCube) //If we hit the playerCube
                        {
                            HealPlayer(); //Heal the player

                            healPlayer.Raise(); //Raise the heal player event
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Increase the playerHealth by the healAmount
        /// </summary>
        private void HealPlayer()
        {
            //Add healAmount to the playerHealth value
            playerHealth.value += healAmount.value;

            //If the health is greater or equal to 100 set the value to 100
            if (playerHealth.value >= 100)
            {
                playerHealth.value = 100;
            }
        }
    }
}
