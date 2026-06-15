using UnityEngine;
using Pathfinding;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float nextWaypointDistance = 0.1f;
    public string targetScene = "";

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEnd = false;
    private Seeker seeker;
    private Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void GoToLocation(Vector3 destination, string sceneName)
    {
        targetScene = sceneName;
        reachedEnd = false;
        seeker.StartPath(rb.position, destination, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
            reachedEnd = false;
            Debug.Log("Sti fundet! Antal waypoints: " + path.vectorPath.Count);
        }
        else
        {
            Debug.Log("Sti fejl: " + p.errorLog);
        }
    }

    void FixedUpdate()
    {
        if (path == null) return;
        if (reachedEnd) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEnd = true;
            Debug.Log("Nået frem!");
            if (targetScene != "")
                UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene);
            return;
        }

        Vector2 target = path.vectorPath[currentWaypoint];
        Debug.Log("Går mod waypoint " + currentWaypoint + " af " + path.vectorPath.Count);
        rb.MovePosition(Vector2.MoveTowards(rb.position, target, moveSpeed * Time.fixedDeltaTime));

        if (Vector2.Distance(rb.position, target) < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}