using UnityEngine;

public class InitialItemOfGame : ModelMonoBehaviour
{
    protected override void  Awake()
    {
        Debug.Log("initial success");
        base.Awake();
        PlayerInventory.Instance.AddPlayerItem(new PlayerItem("Apple", "none"), 5);
    }

    
}
