using Gameplay.Character;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AIBrain : MonoBehaviour
{

    private CharacterMovement _characterMovement;

    private CharacterHabilities _characterHabilities;

    private float timeInState = 0f;

    private Vector3 initialPosition;

    [SerializeField] private float chaseRange = 3f;

    private float _currentAttackCooldown = 1f;

    private float attackCooldown = 1f;





    void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();


        if (_characterMovement == null)
        {
            Debug.LogError("[UserInputMovement] CharacterMovement is null! Add a CharacterMovement component to the GameObject.");
        }

        _characterHabilities = GetComponent<CharacterHabilities>();

        if (_characterHabilities == null)
        {
            Debug.LogError("[UserInputMovement] CharacterHabilities is null! Add a CharacterHabilities component to the GameObject.");
        }

    }

    enum AIState
    {
        Idle,
        Patrol,
        Chase,
        ReturnHome,

    }

    private AIState _currentState = AIState.Idle;

    private NavMeshPath path;

    public Transform target;


    void Start()
    {
        path = new NavMeshPath();
        initialPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        timeInState += Time.deltaTime;

        float distanceInitialToTarget = Vector3.Distance(target.position, initialPosition);

        float distanceSelfToHome = Vector3.Distance(initialPosition, transform.position);

        float distanceSelfToTarget = Vector3.Distance(transform.position, target.position);



        switch (_currentState)
        {
            case AIState.Idle:
                // Implement idle behavior

                //Not even move
                _characterMovement.Move(Vector3.zero);

                if (distanceInitialToTarget < chaseRange)
                {
                    ChangeState(AIState.Chase);
                }
                break;

            case AIState.Patrol:
                // Buscar posicion aleatoria y después 

                break;

            case AIState.ReturnHome:

                MoveTo(initialPosition, 0.2f);

                if (distanceInitialToTarget < chaseRange)
                {
                    ChangeState(AIState.Chase);
                }

                if (distanceSelfToHome < 0.3f)
                {
                    ChangeState(AIState.Idle);
                }


                break;

            case AIState.Chase:
                MoveTo(target.position);
                //Debug.Log("State update Chase");

                _currentAttackCooldown += Time.deltaTime;

                if (distanceInitialToTarget > chaseRange)
                {

                    ChangeState(AIState.ReturnHome);
                }

                if (distanceSelfToTarget < 0.6f && _currentAttackCooldown >= attackCooldown)
                {
                    Debug.Log("AI Attack");

                    _characterHabilities.Attack();
                    _currentAttackCooldown = 0;
                }

                break;
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (Application.isPlaying)
        {
            Gizmos.DrawWireSphere(initialPosition, chaseRange);
        }
        else
        {
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }

    }

    private void ChangeState(AIState newState)
    {
        Debug.Log("[AIBrain] Changing state from " + _currentState + " to " + newState);
        switch (_currentState)
        {
            case AIState.Idle:

                break;

            case AIState.ReturnHome:

                break;
            case AIState.Patrol:

                break;
            case AIState.Chase:

                break;
        }

        timeInState = 0;
        _currentState = newState;

        switch (newState)
        {
            case AIState.Idle:

                break;
            case AIState.Patrol:


                break;

            case AIState.ReturnHome:


                break;
            case AIState.Chase:

                break;
        }
    }
    private void MoveTo(Vector3 targetPosition, float stoppingDistance = 0.6f)
    {
        //float stoppingDistance = 

        CalculatePath(targetPosition);
        if (path.corners.Length < 2)
        {
            _characterMovement.Move(Vector2.zero);
            return;
        }

        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawRay(path.corners[i], path.corners[i + 1], Color.red);
        }
        Vector3 directionToNextCorner = path.corners[1] - path.corners[0];
        Vector2 simulatedInput = new Vector2(directionToNextCorner.x, directionToNextCorner.z).normalized;
        Vector3 lookVector = new Vector3(simulatedInput.x, 0, simulatedInput.y);

        //Sumatorio de las distancias de los corners 
        float totalPathDistance = 0f;

        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawRay(path.corners[i], path.corners[i + 1], Color.green);
            totalPathDistance += Vector3.Distance(path.corners[i], path.corners[i + 1]);
        }
        if (totalPathDistance > stoppingDistance)
        {
            //                    Debug.Log("Reached Stopping Distance");
            _characterMovement.Move(simulatedInput);
            _characterMovement.LookAt(lookVector + transform.position);
        }
        else
        {
            _characterMovement.Move(Vector2.zero);
        }
    }
    private void CalculatePath(Vector3 targetPosition)
    {
        NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);

        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawRay(path.corners[i], path.corners[i + 1], Color.red);
        }
    }
}