using UnityEngine;

public class TextTotalPrice : BaseText
{
    private void Start()
    {
        QuantityAppleController.Instance.OnQuantityChanged += UpdateTotalPrice; // Đăng ký sự kiện
        UpdateTotalPrice(QuantityAppleController.Instance.Quantity); // Cập nhật ngay khi bắt đầu
    }

    private void UpdateTotalPrice(int quantity)
    {
        int pricePerItem = 10; // Giá mỗi sản phẩm, có thể thay đổi theo yêu cầu
        int totalPrice = quantity * pricePerItem;
        text.SetText(totalPrice.ToString());
    }
}
