using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;

    #region "Model-View Player"
    private Player player;
    private PlayerView view;
    #endregion

    InputAction moveAction;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    float lookRotationSpeed = 8f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        // Init Inputs
        InitInputs();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Init Player MVC
        player = new Player();
        view = GetComponent<PlayerView>();
    }

    // Update is called once per frame
    void Update()
    {
        FaceTarget();
    }

    void InitInputs()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.performed += ctx => Move();
    }

    void Move()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            agent.destination = hit.point;
            //Debug.Log("GO TO DESTINATION");
            if (clickEffect != null)
                Instantiate(clickEffect, hit.point += new Vector3(0, 0.1f, 0), clickEffect.transform.rotation);
        }
    }

    void FaceTarget()
    {
        Vector3 dir = (agent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
    }
}
