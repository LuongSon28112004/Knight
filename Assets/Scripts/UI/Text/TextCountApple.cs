using UnityEngine;

public class TextCountApple : BaseText
{
    void Update()
    {
        updateCountApple();
    }

    private void updateCountApple()
    {
        PlayerItem item = new PlayerItem("Apple", "none");

        // Kiểm tra nếu từ điển null hoặc không chứa key
        if (PlayerInventory.Instance.PlayerItems == null || 
            !PlayerInventory.Instance.PlayerItems.ContainsKey(item))
        {
            text.SetText("x0");
            return;
        }

        // Lấy số lượng nếu key tồn tại
        int count = PlayerInventory.Instance.PlayerItems[item];
        text.SetText("x" + count.ToString());
    }
}
