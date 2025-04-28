using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; // Nếu dùng TextMeshPro

public class QuantityAppleController : MonoBehaviour
{
    public static QuantityAppleController Instance { get; private set; }
    public int Quantity { get => quantity;}

    [Header("UI Elements")]
    public Button plusButton;
    public Button minusButton;
    public TMP_Text quantityText; // Hoặc Text nếu dùng UI mặc định
    
    private int quantity = 1;
    private int minQuantity = 1;
    private int maxQuantity = 99;

    public event Action<int> OnQuantityChanged; // Sự kiện khi số lượng thay đổi
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        UpdateQuantityText();
        plusButton.onClick.AddListener(IncreaseQuantity);
        minusButton.onClick.AddListener(DecreaseQuantity);
    }

    void IncreaseQuantity()
    {
        if (quantity < maxQuantity)
        {
            quantity++;
            OnQuantityChanged?.Invoke(quantity); // Gọi sự kiện khi số lượng thay đổi
            UpdateQuantityText();
        }
    }

    void DecreaseQuantity()
    {
        if (quantity > minQuantity)
        {
            quantity--;
            OnQuantityChanged?.Invoke(quantity); // Gọi sự kiện khi số lượng thay đổi
            UpdateQuantityText();
        }
    }

    void UpdateQuantityText()
    {
        quantityText.text = quantity.ToString();
    }
}
