using UnityEngine;

public class Item : MonoBehaviour {
    public string Name { get; private set; }
    
    private void Start()
    {
        Name = "Beer Bottle";
    }
}
