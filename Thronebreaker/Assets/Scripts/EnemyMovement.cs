using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private static int patrolPointsNum;
    [SerializeField] private Transform[] turningPoint;

    private static int curPos = 0;
    private int maxPos;

    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        //sets up a variable for the last position in the array
        maxPos = turningPoint.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the enemy towards the desired node
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, turningPoint[curPos].position, step);

        //checks if the enemy has reached the next node
        if ((Vector3.Distance(transform.position, turningPoint[curPos].position) < 0.001f) /*&& posCheck*/)
        {
            /* Makes enemy move back towards next node in the array
             * If the enemy is at the last node, set curPos to the first node
             */
            if (curPos == maxPos)
            {
                curPos = 0;
            }
            else
            {
                curPos++;
            }
        }
    }
}

