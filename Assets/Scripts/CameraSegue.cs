using UnityEngine;

public class CameraSegue : MonoBehaviour
{

    [SerializeField] private Transform player;

    void Start()
    {
        player  = FindFirstObjectByType<PlayerCodes>().transform;
    }


    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
