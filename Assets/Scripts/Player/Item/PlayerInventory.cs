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
            DontDestroyOnLoad(gameObject); // Giữ lại đối tượng này khi chuyển cảnh
            this.InitItem(); // Khởi tạo kho đồ
        }
        else
        {
            Debug.LogWarning("don't exist two class PlayerInventory in project");
            Destroy(gameObject); // Hủy đối tượng này nếu đã tồn tại
        }
    }


    private void InitItem()
    {
        // Thêm một số vật phẩm mẫu vào kho
        AddPlayerItem(new PlayerItem("Apple", "none"), PlayerPrefs.GetInt("Apple",0)); // Lấy số lượng từ PlayerPrefs
    }

    void Update()
    {
        // Debug.Log("tong=" + playerItems.Count);
    }

    // Thêm vật phẩm vào kho
    public void AddPlayerItem(PlayerItem newPlayerItem, int quantity)
    {
        if (PlayerItems.ContainsKey(newPlayerItem))
        {
            PlayerItems[newPlayerItem] += quantity; // Nếu đã có, tăng số lượng
            if (newPlayerItem.Name == "Apple")
            {
                PlayerPrefs.SetInt("Apple", PlayerItems[newPlayerItem]); // Lưu số lượng vào PlayerPrefs
            }
        }
        else
        {
            PlayerItems[newPlayerItem] = quantity; // Nếu chưa có, thêm mới vào kho
            if (newPlayerItem.Name == "Apple")
            {
                PlayerPrefs.SetInt("Apple", PlayerItems[newPlayerItem]); // Lưu số lượng vào PlayerPrefs
            }
        }
    }

    // Xóa vật phẩm khỏi kho
    public void RemovePlayerItem(PlayerItem PlayerItem, int quantity)
    {
        if (PlayerItems.ContainsKey(PlayerItem))
        {
            PlayerItems[PlayerItem] -= quantity;
            if (PlayerItem.Name == "Apple")
            {
                PlayerPrefs.SetInt("Apple", PlayerItems[PlayerItem]); // Lưu số lượng vào PlayerPrefs
            }
            if (PlayerItems[PlayerItem] <= 0)
            {
                PlayerItems.Remove(PlayerItem); // Nếu số lượng = 0, xóa khỏi kho
            }
        }
    }
}
