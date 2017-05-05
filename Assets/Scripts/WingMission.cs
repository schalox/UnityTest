using UnityEngine.UI;

public class WingMission : Mission
{
    public PlayerCharacter Player;
    public Text StatusText;

    void Start()
    {
        Name = "Wing Mission";
        Status = MissionStatus.Inactive;
        Player = FindObjectOfType<PlayerCharacter>();
        StatusText = GetComponent<Text>();
    }

    public void UpdateMission()
    {
        if (Player.Inventory.ItemList.ContainsKey("Broken Wing"))
        {
            Status = MissionStatus.Completed;
            StatusText.text = "Wing found, return to crash site!";
        }
        else
        {
            StatusText.text = string.Format("Find a broken wing!");
        }
    }
}
