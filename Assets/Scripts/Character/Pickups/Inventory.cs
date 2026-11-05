using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public UnityAction OnInventoryUpdated;
    public int coins;

    public int GetCoins()
    {
        return coins;
    }

    public void AddOrSubtractCoins(int amount)
    {
        coins += amount;
        OnInventoryUpdated?.Invoke();
    }
}
