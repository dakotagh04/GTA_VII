using Gameplay.Character;
using UnityEngine;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour
{
    private CharacterMovement _characterMovement;

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();
    }

    enum AIState
    {
        Idle,
        Patrol,
        Chase
    }

    private AIState _currentState = AIState.Patrol;
    private NavMeshPath path;
    public Transform target;

    private void Start()
    {
        path = new NavMeshPath();
    }

    private void Update()
    {
        switch (_currentState)
        {
            case AIState.Idle:
                _characterMovement.Move(Vector3.zero);
            break;
            case AIState.Patrol:
                NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
                for (int i = 0; i < path.corners.Length - 1; i++)
                {
                    Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
                }

                Vector3 directionToNextCorner = (path.corners[1] - path.corners[0]);

                Vector2 simulatedInput = new Vector2(directionToNextCorner.x, directionToNextCorner.z).normalized;

                Vector3 lookVector = new Vector3(simulatedInput.x, 0, simulatedInput.y);

                if (directionToNextCorner.magnitude > 1f)
                {
                    _characterMovement.Move(simulatedInput);
                    _characterMovement.LookAt(lookVector + transform.position);
                }
                else
                {
                    _characterMovement.Move(Vector2.zero);
                }

                    break;
            case AIState.Chase:
            break;
        }
    }
}
