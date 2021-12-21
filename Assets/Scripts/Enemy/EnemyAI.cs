using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming,
        ChaseTarget,
        AttackTarget,
    }

    // Player detection params
    [Header("Enemy Detection Parameters")]
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private LayerMask detectorLayerMask;

    // enemy variables
    private Enemy currEnemy;
    private Transform detectionOrigin;
    private readonly float detectionDelay = 0.2f;
    private readonly float enemySpawnWait = 0.5f;
    private State state;

    // target variables
    private GameObject target;
    private bool targetDetected;
    private Vector2 positionOfDetectedTarget;

    // roaming variables
    [SerializeField] private readonly float startRoamingWaitTime = 3f;
    private float roamingWaitTime;
    private Vector2 roamingPoint;
    private Vector2 nextPointToRoam;
    private float roamingRadius = 10f;
    private bool setRoamingPoint = false;

    // Gizmos params
    [Header("Gizmo Detection Parameters")]
    [SerializeField] private Color gizmoIdleColor = Color.green;
    [SerializeField] private Color gizmoDetectedColor = Color.red;
    [SerializeField] private bool showGizmox = true;


    private void Awake()
    {
        currEnemy = GetComponent<Enemy>();
        detectorLayerMask = (int)Layers.Player;
        detectionOrigin = transform;
        state = State.Roaming;
        roamingWaitTime = startRoamingWaitTime;
    }
    private void Start()
    {
        // start player detection system
        StartCoroutine(DetectionCoroutine());
    }
    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Roaming: // Roam the spawn point
                Roam();
                break;
            case State.ChaseTarget: // If player is found, chase him!
                currEnemy.UpdateMovement(Mover.DirectionToMove(positionOfDetectedTarget, transform.position));
                break;
            case State.AttackTarget: // If we are in attack range, Attack!
                currEnemy.Attack(target.transform.position - transform.position);
                break;
        }
    }
    // makes the enemy roam randomly on a radius
    private void Roam()
    {
        if (Vector2.Distance(transform.position, nextPointToRoam) < 0.2f)
        {
            if (roamingWaitTime <= 0)
            {
                nextPointToRoam = Random.insideUnitCircle * roamingRadius + roamingPoint;
                roamingWaitTime = startRoamingWaitTime;
            }
            else
            {
                roamingWaitTime -= Time.deltaTime;
            }
        }
        else if (setRoamingPoint)
        {
            currEnemy.UpdateMovement(Mover.DirectionToMove(nextPointToRoam, transform.position));
        }
    }
    // Summary:
    //      every detectionDelay seconds, perform player detection and start new detection coroutine
    private IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionDelay);
        PerformDetection();
        StartCoroutine(DetectionCoroutine());
    }

    // before we start, we need to init point and radius
    private IEnumerator WaitAndSetRoaming(float seconds, Vector2 point, float radius)
    {
        yield return new WaitForSeconds(seconds);
        this.roamingPoint = point;
        this.roamingRadius = radius;
        nextPointToRoam = Random.insideUnitCircle * roamingRadius + roamingPoint;
        setRoamingPoint = true;
    }
    // perform detection, overlap circle, if any players are found, target is player, pos is player, else target is null and pos is zeroes
    private void PerformDetection()
    {
        // the player collider, if not found, it is null
        Collider2D playerCollider = Physics2D.OverlapCircle((Vector2)detectionOrigin.position, detectionRadius, detectorLayerMask);
        // if player is found, assign all params 
        if (playerCollider != null)
        {
            target = playerCollider.gameObject;
            positionOfDetectedTarget = playerCollider.transform.position;
            targetDetected = true;
            if (Vector2.Distance(transform.position, positionOfDetectedTarget) < currEnemy.GetAttackRadius() - 0.2f) // 0.2f is a little offset to make it more dynamic
            {
                state = State.AttackTarget;
            }
            else
            {
                state = State.ChaseTarget;
            }
        }
        else if (target != null) // if we are outside the detector but still want to search the target
        {
            targetDetected = false;
            if (Vector2.Distance(positionOfDetectedTarget, (Vector2)transform.position) < 0.2f)
            {
                state = State.Roaming;
                target = null;
            }
        }
    }

    // draw detection radius on scene
    private void OnDrawGizmos()
    {
        if (showGizmox && detectionOrigin != null)
        {
            Gizmos.color = gizmoIdleColor;
            if (targetDetected)
            {
                Gizmos.color = gizmoDetectedColor;
            }
            Gizmos.DrawWireSphere((Vector2)detectionOrigin.position, detectionRadius);
        }
    }
    public void SetRoaming(Vector2 point, float radius)
    {
        StartCoroutine(WaitAndSetRoaming(enemySpawnWait, point, radius));
    }

    protected void SetMaskLayers(Layers layers)
    {
        this.detectorLayerMask = (int)layers;
    }
    protected void SetDetectionRadius(float radius)
    {
        if (radius > 5f && radius < 80f)
        {
            this.detectionRadius = radius;
        }
        else
        {
            Debug.LogError("Radius is invalid");
        }
    }
    public Transform getTargetPos() {
        return target.transform;
    }
}
