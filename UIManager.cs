using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject planningPanel;

    public TMP_Text moneyText;
    public TMP_Text studyProgressText;
    public TMP_Text staminaText;
    public TMP_Text sicknessText;

    public PlayerStats playerStats;

    public Slider sleepSlider;
    public Slider workSlider;
    public Slider studySlider;

    public TMP_Text sleepLabel;
    public TMP_Text workLabel;
    public TMP_Text studyLabel;
    public TMP_Text totalHoursText;

    public Button startDayButton;

    public TimeManager timeManager;  // Reference to TimeManager

    public void OnBuyCoffeeClicked()
    {
        if (playerStats.money >= 5)
        {
            playerStats.money -= 5;
            playerStats.stamina += 20;
        }
    }

    public void OnBuyEnergyDrinkClicked()
    {
        if (playerStats.money >= 8)
        {
            playerStats.money -= 8;
            playerStats.stamina += 35;
        }
    }

    public void OnBuyMedicationClicked()
    {
        if (playerStats.money >= 10 && playerStats.isSick)
        {
            playerStats.money -= 10;
            playerStats.recoverNextDay = true;  // This will be checked by TimeManager
        }
    }


    void Update()
    {
        int sleep = (int)sleepSlider.value;
        int work = (int)workSlider.value;
        int study = (int)studySlider.value;
        int total = sleep + work + study;

        sleepLabel.text = $"Sleep Hours: {sleep}";
        workLabel.text = $"Work Hours: {work}";
        studyLabel.text = $"Study Hours: {study}";
        totalHoursText.text = $"Total Hours: {total} / 24";

        startDayButton.interactable = (total == 24);

        moneyText.text = $"Money: ${playerStats.money}";
        studyProgressText.text = $"Study: {playerStats.studyProgress}";
        staminaText.text = $"Stamina: {playerStats.stamina:F0}";

        sicknessText.text = playerStats.isSick ? "Status: Sick " : "Status: Healthy ";

    }

    // This method must be OUTSIDE of Update or any other method
    public void OnStartDayButtonClicked()
    {
        int sleep = (int)sleepSlider.value;
        int work = (int)workSlider.value;
        int study = (int)studySlider.value;

        timeManager.StartNewDay(sleep, work, study);

        planningPanel.SetActive(false);
    }
}
