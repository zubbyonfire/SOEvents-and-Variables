using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We need to add the ScriptableObject Variable & Event libraries
using ScriptableObjectEvent;
using ScriptableObjectVariable;

public class LeftClick_Damage : MonoBehaviour
{
    //Heal and Damage events
    [SerializeField]
    private SOGameEvent damagePlayer;

    [SerializeField]
    private SOInt playerHealth, damageAmount;

    [SerializeField]
    private GameObject playerCube;

    private Camera mainCamera = null;

    // Start is called before the first frame update
    void Start()
    {
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

    private void DamagePlayer()
    {
        playerHealth.value -= damageAmount.value;
    }
}
