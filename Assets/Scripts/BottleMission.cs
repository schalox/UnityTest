using UnityEngine.UI;

public class BottleMission : Mission
{
    public PlayerCharacter Player;
    /// <summary>
    /// How many bottles the player needs to collect.
    /// </summary>
    public int BottleGoal;

    /// <summary>
    /// Text field which shows the mission's progress.
    /// </summary>
    public Text StatusText;

    void Start()
    {
        Name = "Bottle Mission";
        Status = MissionStatus.Inactive;
        BottleGoal = 5;
        Player = FindObjectOfType<PlayerCharacter>();
        StatusText = GetComponent<Text>();
    }

    /// <summary>
    /// Update the status text based on the amount of bottled in the player's inventory.
    /// </summary>
    public void UpdateMission()
    {
        int bottleCount;

        if (Player.Inventory.ItemList.TryGetValue("Beer Bottle", out bottleCount) && bottleCount >= BottleGoal)
        {
            StatusText.text = "Bottles collected, return to Dave!";
        }
        else
        {
            StatusText.text = string.Format("Bottles collected: {0}/{1}", bottleCount, BottleGoal);
        }
    }
}
