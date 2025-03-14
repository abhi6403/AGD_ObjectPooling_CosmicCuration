using System;
using CosmicCuration.Utilities;
using Unity.VisualScripting;
using UnityEngine;

namespace CosmicCuration.PowerUps
{
    public class PowerUpPool : GenericObjectPool<PowerUpController>
    {
        private PowerUpData _powerUpData;

        public PowerUpController GetPowerUp<T>(PowerUpData powerUpData) where T : PowerUpController
        {
            _powerUpData = powerUpData;
            return GetItem<T>();
        }

        protected override PowerUpController CreateItem<T>()
        {
            if (typeof(T) == typeof(Shield))
            {
                return new Shield(_powerUpData);
            }else if (typeof(T) == typeof(RapidFire))
            {
                return new RapidFire(_powerUpData);
            }
            else if (typeof(T) == typeof(DoubleTurret))
            {
                return new DoubleTurret(_powerUpData);
            } 
            throw new NotSupportedException("this is not supported") ;
        }
    }
}