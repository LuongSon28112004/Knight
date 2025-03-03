using System.Collections.Generic;
using UnityEngine;

 [SerializeField]
public class PlayerInventory : ModelMonoBehaviour
{
    protected static PlayerInventory instance;
    public static PlayerInventory Instance
    {
        get => instance;
    }

    private Dictionary<PlayerItem, int> playerItems = new Dictionary<PlayerItem, int>(); // Kho đồ
    public Dictionary<PlayerItem, int> PlayerItems { get => playerItems; }

    protected override void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("don't exist two class PlayerInventory in project");
        }
    }

    void Update()
    {
        Debug.Log("tong=" + playerItems.Count);
    }

    // Thêm vật phẩm vào kho
    public void AddPlayerItem(PlayerItem newPlayerItem, int quantity)
    {
        if (PlayerItems.ContainsKey(newPlayerItem))
        {
            PlayerItems[newPlayerItem] += quantity; // Nếu đã có, tăng số lượng
        }
        else
        {
            PlayerItems[newPlayerItem] = quantity; // Nếu chưa có, thêm mới vào kho
        }
    }

    // Xóa vật phẩm khỏi kho
    public void RemovePlayerItem(PlayerItem PlayerItem, int quantity)
    {
        if (PlayerItems.ContainsKey(PlayerItem))
        {
            PlayerItems[PlayerItem] -= quantity;
            if (PlayerItems[PlayerItem] <= 0)
            {
                PlayerItems.Remove(PlayerItem); // Nếu số lượng = 0, xóa khỏi kho
            }
        }
    }
}
