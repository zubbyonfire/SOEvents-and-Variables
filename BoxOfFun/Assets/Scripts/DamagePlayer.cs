using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectVariable;

public class DamagePlayer : MonoBehaviour
{
    public SOFloat playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        playerHealth.AddValue(-10);
    }
}
