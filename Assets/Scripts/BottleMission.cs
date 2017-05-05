using UnityEngine.UI;

public class BottleMission : Mission
{
    public PlayerCharacter Player;
    public int BottleGoal;
    public Text StatusText;

    void Start()
    {
        Name = "Bottle Mission";
        Status = MissionStatus.Inactive;
        BottleGoal = 5;
        Player = FindObjectOfType<PlayerCharacter>();
        StatusText = GetComponent<Text>();
    }

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
