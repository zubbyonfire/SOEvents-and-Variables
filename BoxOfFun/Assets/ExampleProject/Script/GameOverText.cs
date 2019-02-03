using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//We need to add the ScriptableObject Variable & Event libraries
using ScriptableObjectVariable;

[RequireComponent(typeof(TextMeshPro))]
public class GameOverText : MonoBehaviour
{
    private TextMeshPro gameOverText;

    [SerializeField]


    // Start is called before the first frame update
    void Start()
    {
        gameOverText = GetComponent<TextMeshPro>();
        gameOverText.enabled = false;
    }

    void GameOverEnabled()
    {
        gameOverText.enabled = true;
    }

}
