using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private string turningPointName;
    [SerializeField] private Transform turningPoint;
    Vector3 startPos;
    bool posCheck = true;

    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        //sets the starting position to startPos
        startPos = new Vector3();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the enemy towards the desired position
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, turningPoint.position, step);

        //checks if the enemy has reached the desired position
        if ((Vector3.Distance(transform.position, turningPoint.position) < 0.001f) && posCheck)
        {
            //makes enemy move back towards start position
            posCheck = false;
            Vector3 Temp = startPos;
            startPos = turningPoint.position;
            turningPoint.position = Temp;
        }
        else if (Vector3.Distance(transform.position, turningPoint.position) > 0.001f)
        {
            //prevents the enemy from continously moving back and forth when in range of the chekpoint
            posCheck = true;
        }
    }
}

