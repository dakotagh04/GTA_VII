using Gameplay.Systems;
using TMPro;
using UnityEngine;

public class CoinCounterText : MonoBehaviour
{
    public TMP_Text coinText;
    [SerializeField] private Inventory _inventory;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        _inventory.OnInventoryUpdated += UpdateCoinText;
        UpdateCoinText();
    }
    public void UpdateCoinText()
    {
        coinText.text = $"{_inventory.GetCoins()}";
        _animator.SetTrigger("CoinReceived");
    }
}
