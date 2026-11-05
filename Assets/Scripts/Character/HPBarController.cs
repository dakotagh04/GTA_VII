using Gameplay.Systems;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    public TMP_Text healthText;
    public Image healthFill;
    [SerializeField]
    private Damageable _damageable;
    void Start()
    {
        Damaged(0);
        _damageable.OnDamageTaken += Damaged;
    }

    public void Damaged(float damage)
    {
        healthText.text = $"{_damageable.CurrentHitpoints}/{_damageable.MaxHitpoints}";
        healthFill.fillAmount = _damageable.CurrentHitpoints / _damageable.MaxHitpoints;
    }

    //public void Healed()
    //{
        
    //}
}
