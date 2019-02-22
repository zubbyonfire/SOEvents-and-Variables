using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableVariableAndEventExample
{
    [RequireComponent(typeof(ParticleSystem))]
    public class PlayerParticleSystem : MonoBehaviour
    {
        [SerializeField]
        private Color healColour = new Color(0, 0, 0); //Heal colour

        [SerializeField]
        private Color damageColour = new Color(0, 0, 0); //Damage colour

        //Particle system ref + components 
        private new ParticleSystem particleSystem;
        private ParticleSystem.MainModule mainMod;
        private ParticleSystem.EmissionModule emissionMod;

        // Start is called before the first frame update
        void Start()
        {
            //Get the ParticleSystem component and module refs
            particleSystem = GetComponent<ParticleSystem>();
            mainMod = particleSystem.main;
            emissionMod = particleSystem.emission;
            emissionMod.enabled = false; //Turn off the emission for particle system
        }

        /// <summary>
        /// Switch the PS colour and then fire a burst
        /// </summary>
        public void PlayerHealed()
        {
            mainMod.startColor = new Color(healColour.r, healColour.g, healColour.b);

            ParticleBurst();
        }

        /// <summary>
        /// Switch the PS colour and then fire a burst
        /// </summary>
        public void PlayerDamaged()
        {
            mainMod.startColor = new Color(damageColour.r, damageColour.g, damageColour.b);

            ParticleBurst();
        }

        /// <summary>
        /// Enable the emissionModule and emit some particles
        /// </summary>
        public void ParticleBurst()
        {
            emissionMod.enabled = true;

            particleSystem.Emit(25);
        }
    }
}
