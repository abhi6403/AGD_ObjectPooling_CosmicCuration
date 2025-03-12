using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        public EnemyView _enemyView;
        public EnemyData _enemyData;
        public List<PooledEnemy> _pooledEnemies = new List<PooledEnemy>();

        public EnemyPool(EnemyView enemyView,EnemyData enemyData)
        {
            _enemyView = enemyView;
            _enemyData = enemyData;
        }

        public EnemyController GetEnemy()
        {
            if (_pooledEnemies.Count > 0)
            {
                PooledEnemy pooledEnemy = _pooledEnemies.Find(item => !item.isUsed);
                if (pooledEnemy != null)
                {
                    pooledEnemy.isUsed = true;
                    return pooledEnemy.enemyController;
                }
            }
            return CreateEnemyController();
        }

        private EnemyController CreateEnemyController()
        {
            PooledEnemy pooledEnemy = new PooledEnemy();
            pooledEnemy.enemyController = new EnemyController(_enemyView,_enemyData);
            pooledEnemy.isUsed = true;
            _pooledEnemies.Add(pooledEnemy);
            return pooledEnemy.enemyController;
        }

        public void ReturnEnemyPool(EnemyController returnController)
        {
            PooledEnemy pooledEnemy = _pooledEnemies.Find(item => item.enemyController.Equals(returnController));
            pooledEnemy.isUsed = false;
        }
        public class PooledEnemy
        {
            public EnemyController enemyController;
            public bool isUsed;
        }
    }
}
