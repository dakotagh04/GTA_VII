using Gameplay.Systems;
using UnityEngine;

public class DamageableEffects : MonoBehaviour
{
    private Damageable _damageable;
    private Animator _animator;
    private void Start()
    {
        _damageable = GetComponent<Damageable>();
        if (!_damageable)
        {
            Debug.LogError("falla _damageable de [SimpleDamageableEffects]");
        }

        _animator = GetComponent<Animator>();
        if (!_animator)
        {
            Debug.LogError("falla _animator de [SimpleDamageableEffects]");
        }
    }
}