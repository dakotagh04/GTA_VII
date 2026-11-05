using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject bomb;

    public float spawnHeight = 0.0f;

    public void SpawnBomb()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnHeight, transform.position.z);

        Quaternion spawnRotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));

        GameObject spawnedBomb = Instantiate(bomb, spawnPosition, spawnRotation);

        Animator bombAnimator = spawnedBomb.GetComponent<Animator>();

        if (bombAnimator == null)
        {
            Debug.LogWarning("La bomba no tiene componente Animator.");
            return;
        }

        if (bombAnimator.runtimeAnimatorController == null)
        {
            Debug.LogWarning("La bomba no tiene Animator Controller asignado.");
            return;
        }

        bombAnimator.Rebind();
        bombAnimator.SetTrigger("Start_Bomb");
    }
}
