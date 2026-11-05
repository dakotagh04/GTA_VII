using UnityEngine;

public class CoinPickup : PickupBase
{
    protected override void PickupEffect(Picker _picker)
    {
        Inventory inventory = _picker.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.AddOrSubtractCoins(1);
        }
    }
}
