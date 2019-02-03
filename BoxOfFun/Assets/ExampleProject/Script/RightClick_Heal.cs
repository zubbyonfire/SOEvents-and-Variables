using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We need to add the ScriptableObject Variable & Event libraries
using ScriptableObjectEvent;
using ScriptableObjectVariable;

public class RightClick_Heal : MonoBehaviour
{
    //Heal and Damage events
    [SerializeField]
    private SOGameEvent healPlayer;

    [SerializeField]
    private SOInt playerHealth, healAmount;

    [SerializeField]
    private GameObject playerCube = null;

    private Camera mainCamera = null;

    // Start is called before the first frame update
    void Start()
    {
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

    private void HealPlayer()
    {
        playerHealth.value += healAmount.value;
    }
}
