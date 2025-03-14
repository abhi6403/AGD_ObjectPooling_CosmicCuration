using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private VFXPool _vfxPool;

        public VFXService(VFXView vfxPrefab) => _vfxPool = new VFXPool(vfxPrefab);

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXController vfxToPlay = _vfxPool.GetVFXController();
            vfxToPlay.Configure(spawnPosition,type);
        }

        public void ReturnVFXToPool(VFXController vfxController) => _vfxPool.ReturnItem(vfxController);
    } 
}