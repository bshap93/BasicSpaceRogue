using System;
using DG.Tweening;
using UnityEngine;

namespace Model
{
    public class Speed
    {
       public event Action SpeedChanged; 
       
       const float MinSpeed = 0;
       const float MaxSpeed = 50;
        const float DecelRate = 0.5f;
        
        public float CurrentYSpeed { get; set; }
        public float CurrentXSpeed { get; set; }
        
        
        public float MinSpeedValue => MinSpeed;
        public float MaxSpeedValue => MaxSpeed;
        
        public void IncreaseSpeed(float ySpeed, float xSpeed)
        {
            CurrentYSpeed += ySpeed;
            CurrentXSpeed += xSpeed;
            CurrentYSpeed = Mathf.Clamp(CurrentYSpeed, MinSpeed, MaxSpeed);
            CurrentXSpeed = Mathf.Clamp(CurrentXSpeed, MinSpeed, MaxSpeed);
            UpdateSpeed();
        }
        
        public void DecreaseSpeed(float ySpeed, float xSpeed)
        {
            CurrentYSpeed -= ySpeed;
            CurrentXSpeed -= xSpeed;
            CurrentYSpeed = Mathf.Clamp(CurrentYSpeed, MinSpeed, MaxSpeed);
            CurrentXSpeed = Mathf.Clamp(CurrentXSpeed, MinSpeed, MaxSpeed);
            UpdateSpeed();
        }
        
        public void ResetSpeed()
        {
            CurrentYSpeed = MinSpeed;
            CurrentXSpeed = MinSpeed;
            UpdateSpeed();
        }
        
        public void DecreaseSpeedToZero()
        {
            // DoTween the speed to zero
            
            DOTween.To(() => CurrentYSpeed, x => CurrentYSpeed = x, 0, DecelRate);
            DOTween.To(() => CurrentXSpeed, x => CurrentXSpeed = x, 0, DecelRate);
            
            UpdateSpeed();
        }
        
        
        
        
        
        
        
       protected virtual void UpdateSpeed()
       {
           SpeedChanged?.Invoke();
       }
    }
}
