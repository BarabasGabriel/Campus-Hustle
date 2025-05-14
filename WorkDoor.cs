using UnityEngine;

public class WorkDoor : MonoBehaviour
{
    public TeleportManager teleportManager;
    public TimeManager timeManager;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Going to work...");
            teleportManager.TeleportToRestaurant();
            StartCoroutine(WorkShiftCoroutine());
        }
    }

    private System.Collections.IEnumerator WorkShiftCoroutine()
    {
        int hours = timeManager.workHoursToday;
        float seconds = hours * 1f; // 1 real second = 1 hour in-game (adjust if needed)

        yield return new WaitForSeconds(seconds);

        Debug.Log("Work ended.");
        teleportManager.TeleportToFlat();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
