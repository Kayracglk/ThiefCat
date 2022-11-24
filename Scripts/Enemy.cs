using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float navMeshSpeed;
    [SerializeField] private float turnSpeed;
    private Transform playerTransform;

    [SerializeField] float stopDistance;
    public bool isChatched;
    public bool IsChatched { get { return isChatched; } set { isChatched = value; } }

    [SerializeField] private Transform rayStartPoint;

    private RaycastHit hitObject;

    private bool playerIsAvailable;

    public Vector3 enemyFirstPos;

    //NavMesh
    private NavMeshAgent agent;
    private bool isNavMesh = true;
    public bool IsNavMesh { get { return isNavMesh; } set { isNavMesh = value; } }
    [SerializeField] GameObject[] movementPoints;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = navMeshSpeed;
    }
    private void OnEnable()
    {
        movementPoints = GameObject.FindGameObjectsWithTag("EnemyTarget");
        StartCoroutine(NavMeshMovement(5));
    }
    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        enemyFirstPos = transform.position;
    }
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (IsNavMesh) return; // nav mesh aktifse burayi okuma
        agent.speed = 0;
        FollowTarget();
    }
    public void FollowTarget()
    {
        if (playerTransform == null) return;
        Vector3 playerVec = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
        transform.LookAt(playerVec);
        float mesafe = Vector3.Distance(transform.position, playerTransform.position);
        if (mesafe > stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerVec, moveSpeed * Time.deltaTime);
        }
    }
    public IEnumerator NavMeshMovement(float delay)
    {
        agent.speed = navMeshSpeed;
        int lastIndex = -1;
        int index = Random.Range(0, movementPoints.Length);
        while (true)
        {
            if (!IsNavMesh) break;
            if (lastIndex == index)
            {
                index = Random.Range(0, movementPoints.Length);
                continue;
            }
            agent.SetDestination(movementPoints[index].transform.position);
            lastIndex = index;
            SetBoolFalseAnim("Zombie");
            SetBoolTrueAnim("Walk");
            yield return new WaitForSeconds(delay);
        }
    }
    #region GetPlayerInfo
    public void CheckThePlayer()
    {
        Vector3 diffThePlayer = playerTransform.position - transform.position;
        bool hit = Physics.Raycast(rayStartPoint.position, diffThePlayer, out RaycastHit hitObje);
        hitObject = hitObje;
        Debug.DrawRay(rayStartPoint.position, diffThePlayer, Color.cyan);
        if (hit)
        {
            if (hitObject.collider.gameObject.CompareTag("Player")) playerIsAvailable = true;
            else playerIsAvailable = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            SetBoolFalseAnim("Walk");
            SetBoolTrueAnim("Zombie");
            CheckThePlayer();
            if (playerIsAvailable)
            {
                IsNavMesh = false;
                isChatched = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            SetBoolFalseAnim("Zombie");
            SetBoolTrueAnim("Walk");
            CheckThePlayer();
            IsNavMesh = true;
            StartCoroutine(NavMeshMovement(5));
            playerIsAvailable = false;
            IsChatched = false;
        }
    }
    #endregion
    public void Restart()
    {
        transform.position = enemyFirstPos;
        IsChatched = false;
        playerIsAvailable = false;
    }
    public void SetBoolTrueAnim(string animasyon)
    {
        anim.SetBool(animasyon,true);
    }
    public void SetBoolFalseAnim(string animasyon)
    {
        anim.SetBool(animasyon, false);
    }
}
