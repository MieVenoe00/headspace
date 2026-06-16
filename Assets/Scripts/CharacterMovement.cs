using UnityEngine;
using Pathfinding;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float nextWaypointDistance = 0.1f;
    public string targetScene = "";

    [Header("Retnings-sprites")]
    public Sprite spriteNed;
    public Sprite spriteOp;
    public Sprite spriteVenstre;
    public Sprite spriteHøjre;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEnd = false;
    private Seeker seeker;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        }
    }

    void FixedUpdate()
    {
        if (path == null) return;
        if (reachedEnd) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEnd = true;
            if (targetScene != "")
                UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene);
            return;
        }

        Vector2 target = path.vectorPath[currentWaypoint];
        Vector2 direction = (target - rb.position).normalized;

        SkiftSprite(direction);

        rb.MovePosition(Vector2.MoveTowards(rb.position, target, moveSpeed * Time.fixedDeltaTime));

        if (Vector2.Distance(rb.position, target) < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void SkiftSprite(Vector2 direction)
{
    float threshold = 0.3f; // Hvor meget mere dominant en retning skal være

    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y) + threshold)
    {
        spriteRenderer.sprite = direction.x > 0 ? spriteHøjre : spriteVenstre;
    }
    else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x) + threshold)
    {
        spriteRenderer.sprite = direction.y > 0 ? spriteOp : spriteNed;
    }
    // Hvis ingen retning er tydeligt dominant, behold nuværende sprite
}
}