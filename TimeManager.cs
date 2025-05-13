using UnityEngine;
using System.Collections; // Needed for Coroutine

public class TimeManager : MonoBehaviour
{
    public int currentDay = 1;
    public int maxDays = 10;

    public PlayerStats playerStats;
    public UIManager uiManager;

    public void StartNewDay(int sleepHours, int workHours, int studyHours)
    {
        if (currentDay > maxDays)
        {
            Debug.Log("Game is already over.");
            return;
        }

        playerStats.ApplyDailyStats(sleepHours, workHours, studyHours);

        Debug.Log($"Day {currentDay} complete.");

        currentDay++;

        CheckEndGame();
    }

    private void CheckEndGame()
    {
        if (currentDay > maxDays)
        {
            if (playerStats.money >= 200 && playerStats.studyProgress >= 300)
            {
                Debug.Log("You WIN!");
            }
            else
            {
                Debug.Log("You FAIL!");
            }

            // TODO: Show final result UI if needed
        }
        else
        {
            // Delay UI reactivation for smoother transition
            StartCoroutine(ReactivatePlanningUI());
        }
    }

    private IEnumerator ReactivatePlanningUI()
    {
        yield return new WaitForSeconds(2f); // 2-second delay
        uiManager.planningPanel.SetActive(true);
    }
}
