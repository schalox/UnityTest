using UnityEngine;

public enum MissionStatus
{
    Inactive,
    Active,
    Completed
}

public abstract class Mission : MonoBehaviour
{
    public string Name { get; protected set; }
    public MissionStatus Status { get; set; }
}
