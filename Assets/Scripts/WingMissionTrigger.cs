using UnityEngine;
using UnityEngine.SceneManagement;

public class WingMissionTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WingMission wingMission = FindObjectOfType<WingMission>();

            switch (wingMission.Status)
            {
                case MissionStatus.Inactive:
                    Debug.Log("Start wing mission");
                    wingMission.Status = MissionStatus.Active;
                    wingMission.UpdateMission();
                    break;
                case MissionStatus.Completed:
                    Debug.Log("Game complete");
                    wingMission.StatusText.text = string.Empty;
                    FindObjectOfType<PlayerCharacter>().gameObject.SetActive(false);
                    SceneManager.LoadScene(0);
                    break;
            }
        }
    }
}
