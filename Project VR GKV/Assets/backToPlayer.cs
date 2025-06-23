using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class backToPlayer : MonoBehaviour
{
    public Transform player;
    public float maxDistance = 4f;
    public float minVelocity = 0.1f;
    public bool keepUpRight = false;
    public float stopDistance = 1.5f;
    public float returnDelay = 1f;
    public float returnSpeed = 3f;
    public float spinSpeed = 180f;

    private Rigidbody rb;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool isReturning = false;
    private bool isHeld = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        // Assign main camera if player is not manually assigned
        if (player == null)
            player = Camera.main.transform;

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isHeld = true;
        isReturning = false;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isHeld = false;
        StartCoroutine(MonitorDistanceAndReturn());
    }

    private System.Collections.IEnumerator MonitorDistanceAndReturn()
    {
        // if the robot reachs max distance, it will stop
        // if the robot hasn't reached max distance but it already slowed down enough, it will start returning
        while (!isHeld)
        {
            float dist = Vector3.Distance(transform.position, player.position);

            if (dist >= maxDistance)
            {
                // Freeze movement
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
                break;
            }

            if (rb.linearVelocity.magnitude <= minVelocity)
            {
                break;
            }

            yield return null;
        }

        yield return new WaitForSeconds(returnDelay);
        // Start returning
        isReturning = true;
        rb.isKinematic = false;
    }

    private void Update()
    {
        if (!isHeld)
        {
            Vector3 lookDirection = player.position - transform.position;
            if(keepUpRight) lookDirection.y = 0f; // Keep upright
            if (lookDirection.sqrMagnitude > 0.01f)
                transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        if (isReturning && !isHeld)
        {
            float dist = Vector3.Distance(transform.position, player.position);

            if (dist > stopDistance)
            {
                Vector3 dir = (player.position - transform.position).normalized;
                rb.MovePosition(transform.position + dir * returnSpeed * Time.deltaTime);
            }
            else
            {
                isReturning = false;
            }
        }
    }
}