using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private static int patrolPointsNum;
    [SerializeField] private Transform[] turningPoint;
    public bool turnsRight;
    public bool turnsLeft;
    public bool backAndForth;

    private int curPos = 0;
    private int maxPos;

    public float detectionRadius = 3f;
    public float detectionAngle = 60f;
    // public PolygonCollider2D visionCone;
    public BoxCollider2D visionBox;

    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        //sets up a variable for the last position in the array
        maxPos = turningPoint.Length - 1;
    }

    void Start()
    {
        if (visionBox != null)
        {
            visionBox.isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    /*public void UpdateVisionCone()
    {
        if (visionCone == null) return;

        visionCone.pathCount = 1;

        int numVertices = 6;
        List<Vector2> points = new List<Vector2> {Vector2.zero};

        float halfAngle = detectionAngle / 2f;

        // Get forward direction
        Vector2 forward = transform.right;

        // Generate the cone shape
        for (int i = 0; i <= numVertices; i++)
        {
            float angle = -halfAngle + i / (float)numVertices * detectionAngle;
            Vector2 direction = Quaternion.Euler(0, 0, angle) * forward;
            points.Add(direction * detectionRadius);
        }

        visionCone.SetPath(0, points.ToArray());
    }*/

    public void Patrol()
    {

        Transform targetPoint = turningPoint[curPos];

        // Moves the enemy towards the desired node
        transform.position = Vector3.MoveTowards(transform.position, turningPoint[curPos].position, speed * Time.deltaTime);

        //checks if the enemy has reached the next node
        if (Vector2.Distance(transform.position, turningPoint[curPos].position) < 0.001f)
        {
            curPos++;
            if (curPos >= turningPoint.Length)
                curPos = 0;

            if (turnsLeft)
            {
                transform.Rotate(0, 0, 90);
            }
            else if (turnsRight)
            {
                transform.Rotate(0, 0, -90);
            }
            if (backAndForth)
            {
                transform.Rotate(0, 0, 180);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Sending to battle scene");
            SceneManager.LoadScene(3);
        }
    }
}

