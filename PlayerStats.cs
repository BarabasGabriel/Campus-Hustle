using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float stamina;
    public int money;
    public float studyProgress;

    public bool isSick = false;
    public int sickDays = 0;

    public bool recoverNextDay = false;

    public void ApplyDailyStats(int sleep, int work, int study)
    {
        float baseStamina = sleep * 10f;
        if (isSick)
            baseStamina *= 0.75f;

        stamina = baseStamina;

        float staminaCost = (work + study) * (isSick ? 1.1f : 1f);
        stamina -= staminaCost;

        money += work * 10;
        studyProgress += study * 5;

        money -= 10; // food cost

        if (isSick)
        {
            sickDays--;
            if (sickDays <= 0)
                isSick = false;
        }
        else if (Random.value < 0.1f)
        {
            isSick = true;
            sickDays = 3;
            Debug.Log("You got sick!");
        }

        Debug.Log($"Money: ${money}, Study Progress: {studyProgress}, Stamina: {stamina}");
    }
}
