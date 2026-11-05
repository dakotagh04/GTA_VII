using UnityEngine;
using UnityEngine.InputSystem;

public class TimedBomb : MonoBehaviour
{
    public Animator animator_bomba;
    public GameObject explosion_effect;

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.fKey.wasPressedThisFrame)
        {
            animator_bomba.SetTrigger("Start_Bomb");
        }
    }
    public void BombFinished()
    {
        Instantiate(explosion_effect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
