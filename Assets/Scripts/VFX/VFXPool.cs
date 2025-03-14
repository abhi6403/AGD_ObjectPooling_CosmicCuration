using CosmicCuration.Utilities;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXPool : GenericObjectPool<VFXController>
    {
        private VFXView _vfxPrefab;
        
        public VFXPool(VFXView vfxPrefab) => _vfxPrefab = vfxPrefab;

        public VFXController GetVFXController() => GetItem<VFXController>();

        protected override VFXController CreateItem<T>() => new VFXController(_vfxPrefab);
    }
}
