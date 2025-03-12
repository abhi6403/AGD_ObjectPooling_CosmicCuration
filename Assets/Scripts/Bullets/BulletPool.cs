using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private BulletView _bulletView;
        private BulletScriptableObject _bulletScriptableObject;
        private List<PooledBullet> _pooledBullets = new List<PooledBullet>();
        
        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            _bulletView = bulletView;
            _bulletScriptableObject = bulletScriptableObject;
        }

        public class PooledBullet
        {
            public BulletController bullet;
            public bool isUsed;
        }
    }
}
