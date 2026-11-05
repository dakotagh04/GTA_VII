using UnityEngine;

public class AnimatorEvent : MonoBehaviour
{
    public CharacterHabilities _characterHabilities;
    private void Awake()
    {
        _characterHabilities = GetComponentInParent<CharacterHabilities>();
    }

    public void AttackEvent()
    {
        _characterHabilities.HurtDamagables();
    }
}
