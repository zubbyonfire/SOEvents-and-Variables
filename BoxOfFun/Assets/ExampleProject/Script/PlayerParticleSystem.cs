using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We need to add the ScriptableObject Variable & Event libraries
using ScriptableObjectEvent;
using ScriptableObjectVariable;

[RequireComponent(typeof(ParticleSystem))]
public class PlayerParticleSystem : MonoBehaviour
{
    [SerializeField]
    private Color healColour;

    [SerializeField]
    private Color damageColour;

    private new ParticleSystem particleSystem;
    private ParticleSystem.MainModule mainMod;
    private ParticleSystem.EmissionModule emissionMod;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        mainMod = particleSystem.main;
        emissionMod = particleSystem.emission;
        emissionMod.enabled = false; //Turn off the emission for particle system
    }

    public void PlayerHealed()
    {
        mainMod.startColor = new Color(healColour.r, healColour.g, healColour.b);

        ParticleBurst();
    }

    public void PlayerDamaged()
    {
        mainMod.startColor =  new Color(damageColour.r, damageColour.g, damageColour.b);

        ParticleBurst();
    }

    public void ParticleBurst()
    {
        emissionMod.enabled = true;

        particleSystem.Emit(25);
    }
}
