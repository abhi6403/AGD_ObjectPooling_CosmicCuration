using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CosmicCuration.VFX
{
    public class VFXView : MonoBehaviour
    {
        private VFXController controller;
        
        [SerializeField] private List<VFXData> particleSystemMap;
        private ParticleSystem currentParticleSystem;

        public void SetController(VFXController controllerToSet) => controller = controllerToSet;

        public void ConfigureAndPlay(Vector2 positionToSet,VFXType type)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = positionToSet;

            foreach (VFXData item in particleSystemMap)
            {
                if (item.type == type)
                {
                    item.particleSystem.gameObject.SetActive(true);
                    currentParticleSystem = item.particleSystem;
                }
                else
                {
                        item.particleSystem.gameObject.SetActive(false);
                }
            }
        }

        private void Update()
        {
            if (currentParticleSystem != null)
            {
                if (currentParticleSystem.isStopped)
                {
                    currentParticleSystem.gameObject.SetActive(false);
                    currentParticleSystem = null;
                    controller.OnParticleEffectCompleted();
                    gameObject.SetActive(false);
                }
            }
        }
        
    }
    [Serializable]
    public struct VFXData
    {
        public VFXType type;
        public ParticleSystem particleSystem;
    }
}