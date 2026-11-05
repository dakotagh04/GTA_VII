using UnityEngine;

public class IncorrectPressurePlateView : MonoBehaviour
{
    Animator _animator;
    [SerializeField] ParticleSystem puffParticles;

    TrapSpawner trapSpawner;
    void Awake()
    {
        _animator = GetComponent<Animator>();

        trapSpawner = GetComponent<TrapSpawner>();

        if (TryGetComponent(out ActivatorBase activator))
        {
            activator.ToActivate.AddListener(OnActivated);
        }
    }

    private void OnActivated(ActivatorBase.ActivatorInfo info)
    {
        _animator.SetBool("isPressed", info.Activator.IsActivated);
    }

    //This method is called from the animation.
    public void PlayPuffParticles()
    {
        puffParticles.Play();
    }

    public void SpawnTrap()
    {
        trapSpawner.SpawnBomb();
    }
}
