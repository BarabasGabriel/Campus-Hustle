using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public Transform flatSpawnPoint;
    public Transform restaurantSpawnPoint;
    public GameObject player;

    public void TeleportToFlat()
    {
        player.transform.position = flatSpawnPoint.position;
    }

    public void TeleportToRestaurant()
    {
        player.transform.position = restaurantSpawnPoint.position;
    }
}
