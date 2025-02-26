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
        startPos = new Vector3();
        startPos = transform.position;
        print(startPos);
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, turningPoint.position, step);

        if ((Vector3.Distance(transform.position, turningPoint.position) < 0.001f) && posCheck)
        {
            print(startPos);
            posCheck = false;
            Vector3 Temp = startPos;
            startPos = turningPoint.position;
            turningPoint.position = Temp;
            print(turningPoint.position);
        }
        else if (Vector3.Distance(transform.position, turningPoint.position) > 0.001f)
        {
            posCheck = true;
        }
    }
}

