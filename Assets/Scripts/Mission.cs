using UnityEngine;

public enum MissionStatus
{
    Inactive,
    Active,
    Completed
}

public abstract class Mission : MonoBehaviour
{
    /// <summary>
    /// Mission's name.
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Mission's status.
    /// </summary>
    public MissionStatus Status { get; set; }
}
