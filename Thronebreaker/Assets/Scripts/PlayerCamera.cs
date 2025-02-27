using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        //sets camera position to player position
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
