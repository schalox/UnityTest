using UnityEngine;

public class BottleQuestTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BottleMission bottleMission = FindObjectOfType<BottleMission>();

        switch (bottleMission.Status)
        {
            case MissionStatus.Inactive:
                bottleMission.Status = MissionStatus.Active;
                bottleMission.UpdateMission();
                break;
            case MissionStatus.Active:
                int bottleCount;
                WingMission wingMission = FindObjectOfType<WingMission>();

                if (bottleMission.Player.Inventory.ItemList.TryGetValue("Beer Bottle", out bottleCount) && bottleCount >= bottleMission.BottleGoal)
                {
                    bottleMission.StatusText.text = string.Empty;
                    for (int i = 0; i < 5; i++)
                    {
                        bottleMission.Player.Inventory.RemoveItem("Beer Bottle");
                    }
                    bottleMission.Player.Inventory.AddItem("Broken Wing");

                    bottleMission.Status = MissionStatus.Completed;
                    wingMission.UpdateMission();
                }
                break;
        }
    }
}
