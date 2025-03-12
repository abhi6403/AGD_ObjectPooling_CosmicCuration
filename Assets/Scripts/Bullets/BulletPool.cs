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

        public BulletController GetBullet()
        {
            if (_pooledBullets.Count > 0)
            {
                PooledBullet pooledBullet = _pooledBullets.Find(item => !item.isUsed);
                if (pooledBullet != null)
                {
                    pooledBullet.isUsed = true;
                    return pooledBullet.bulletController;
                }
            }
            return CreateNewPooledBullet();
        }

        private BulletController CreateNewPooledBullet()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.bulletController = new BulletController(_bulletView, _bulletScriptableObject);
            pooledBullet.isUsed = true;
            _pooledBullets.Add(pooledBullet);
            return pooledBullet.bulletController;
        }

        public void ReturnBulletPool(BulletController returnController)
        {
            PooledBullet pooledBullet = _pooledBullets.Find(item => item.bulletController.Equals(returnController));
            pooledBullet.isUsed = false;
        }
        public class PooledBullet
        {
            public BulletController bulletController;
            public bool isUsed;
        }
    }
}
