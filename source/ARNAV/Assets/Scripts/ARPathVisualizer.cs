using UnityEngine;
using UnityEngine.AI;

public class ARPathVisualizer : MonoBehaviour
{
    public NavMeshAgent agent; // Reference to the NavMesh Agent
    private LineRenderer line; // Line Renderer for drawing the path
    public NavMeshPath path; // NavMeshPath object to store the calculated path
    public Transform startPoint; // Start point of the path
    public Transform endPoint; // End point of the path
    public float lineHeightOffset = 0.2f; // Offset to make the line appear above the floor

    //public NotificationController notificationController; // Reference to the notification system
    //public float arrivalThreshold = 1f; // Distance threshold to consider "arrived"

    //private bool hasReachedDestination = false; // Flag to avoid multiple notifications

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        line = GetComponent<LineRenderer>();

        if (line == null)
        {
            Debug.LogError("Line Renderer is not assigned!");
        }

        // Configure Line Renderer properties
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.useWorldSpace = true;
        line.positionCount = 0; // Clear the line initially

        NavMeshHit hit;

        // Try to place the agent on the NavMesh
        if (NavMesh.SamplePosition(agent.transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            agent.transform.position = hit.position;
            Debug.Log("Agent successfully repositioned on NavMesh at: " + hit.position);
        }
        else
        {
            Debug.LogError("Failed to place agent on the NavMesh.");
        }

        // Set the destination if the agent is on the NavMesh
        if (agent.isOnNavMesh && endPoint != null)
        {
            agent.SetDestination(endPoint.position);
            Debug.Log("Set destination to: " + endPoint.position);
        }
        else
        {
            Debug.LogError("Agent is not on the NavMesh, or endPoint is not assigned.");
        }
    }

    void Update()
    {
        if (startPoint == null || endPoint == null)
        {
            Debug.LogError("Start or end point is not assigned.");
            return;
        }

        // Update Line Renderer based on the calculated path
        if (NavMesh.CalculatePath(startPoint.position, endPoint.position, NavMesh.AllAreas, path) && path.status == NavMeshPathStatus.PathComplete)
        {
            if (path.corners.Length > 0)
            {
                line.positionCount = path.corners.Length;

                for (int i = 0; i < path.corners.Length; i++)
                {
                    Vector3 linePosition = path.corners[i];
                    linePosition.y += lineHeightOffset; // Raise the line slightly above the floor
                    line.SetPosition(i, linePosition);
                }

                line.enabled = true;
            }
            else
            {
                Debug.LogWarning("No corners in path.");
                line.positionCount = 0; // Clear the line if no corners
            }
        }
        else
        {
            Debug.LogWarning("Failed to calculate path.");
            line.positionCount = 0; // Clear the line if path calculation fails
        }

        // Check if the agent has reached the destination
        //if (agent != null && endPoint != null)
        //{
            //float distanceToDestination = Vector3.Distance(agent.transform.position, endPoint.position);

            //if (distanceToDestination <= arrivalThreshold && !hasReachedDestination)
            //{
                //hasReachedDestination = true; // Prevent duplicate notifications
                //notificationController.ShowNotification($"You have arrived at {endPoint.name}.");
                //Debug.Log($"Agent has reached the destination: {endPoint.name}");
            //}
            //else if (distanceToDestination > arrivalThreshold)
            //{
                //hasReachedDestination = false; // Reset the flag if the agent moves away
            //}
        //}
    }
}
