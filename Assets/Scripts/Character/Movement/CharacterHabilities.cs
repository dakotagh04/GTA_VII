using Gameplay.Systems;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHabilities : MonoBehaviour
{
    [SerializeField] private Collider _basicAttackCollider;

    public float dmgToMake = 1.0f;

    public UnityAction OnAttack;
    public void Attack()
    {
        OnAttack?.Invoke();
        Debug.Log("[UserInputMovement] Attack triggered.");
    }

    public void HurtDamagables()
    {
        Debug.Log("Doing damage");

        Collider[] damageablesFound = Physics.OverlapBox(_basicAttackCollider.bounds.center, _basicAttackCollider.bounds.extents, _basicAttackCollider.transform.rotation);

        foreach (var hit in damageablesFound)
        {
            var damageable = hit.GetComponent<Damageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(dmgToMake);
            }
        }
    }
}
