using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Presenter
{
    public class HealthPresenter : MonoBehaviour
    {
       [SerializeField] Health _health; 
       [SerializeField] Slider healthSlider;

       void Start()
       {
           if (_health != null)
           {
               _health.HealthChanged += OnHealthChanged;
               
           }

           UpdateView();

       }

       void OnDestroy()
       {
              if (_health != null)
              {
                _health.HealthChanged -= OnHealthChanged;
              }
           
       }

       public void Damage(int amount)
       {
           _health?.Decrement(amount);
       }
       
       public void Heal(int amount)
       {
           _health?.Increment(amount);
       }

       public void Reset()
       {
           _health?.Restore();
       }

       public void UpdateView()
       {
           if (_health == null) return;

           if (healthSlider != null && _health.MaxHealthValue != 0)
           {
               healthSlider.value = (float) _health.CurrentHealth / (float)_health.MaxHealthValue;
           }
       }
       
       public void OnHealthChanged()
       {
           UpdateView();
       }
    }
}
