using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : ModelMonoBehaviour
{
    //singleton 
    protected static InputManager instance;
    public static InputManager Instance { get => instance;}
    //move left and right
    [SerializeField] private float horizontalInput;
    public float HorizontalInput { get => horizontalInput;}
    //click button on button space
    [SerializeField] private bool onSpace;
    public bool OnSpace { get => onSpace; }

    //double click on button space
    private float doubleSpaceClicked = 0;
    private float doubleSpaceClicktime = 0;
    private float doubleSpaceClickdelay = 0.7f;
    [SerializeField] private bool onDoubleSpace;
    public bool OnDoubleSpace { get => onDoubleSpace; set => onDoubleSpace = value; }

    //click key X
    [SerializeField] private bool onKeyX;
    public bool OnKeyX { get => onKeyX;}
    

    protected override void Awake()
    {
        if(InputManager.instance != null) Debug.LogWarning("can't have 2 inputManager in obj");
        InputManager.instance = this;
    }

    void Update()
    {
        this.getHorizontalInput();
        this.getOnSpaceDown();
        this.getOnDoubleSpace();
        this.getOnKeyXDown();
    }

    protected void getHorizontalInput(){
        this.horizontalInput = Input.GetAxis("Horizontal");
    }

    protected void getOnSpaceDown(){
        this.onSpace = Input.GetKey(KeyCode.Space) ? true : false;
    }

    protected void getOnDoubleSpace()
    {
        // Chỉ thực hiện khi phím Space được nhấn xuống
        if (Input.GetKeyDown(KeyCode.Space))
        {
            doubleSpaceClicked++; // Tăng biến đếm lần nhấn

            // Nếu lần nhấn đầu tiên
            if (doubleSpaceClicked == 1)
            {
                doubleSpaceClicktime = Time.time; // Lưu lại thời gian nhấn đầu tiên
            }

            // Nếu lần nhấn thứ hai và trong khoảng thời gian hợp lệ
            if (doubleSpaceClicked > 1 && Time.time - doubleSpaceClicktime < doubleSpaceClickdelay)
            {
                doubleSpaceClicked = 0; // Reset đếm
                doubleSpaceClicktime = 0; // Reset thời gian
                this.onDoubleSpace = true; // Đặt cờ nhận diện double-tap
                Debug.Log("Double tap detected!");
            }
            // Nếu thời gian quá lâu hoặc nhấn quá 2 lần
            else if (doubleSpaceClicked > 2 || Time.time - doubleSpaceClicktime > doubleSpaceClickdelay)
            {
                doubleSpaceClicked = 0; // Reset đếm
                doubleSpaceClicktime = 0; // Reset thời gian
                this.onDoubleSpace = false; // Reset cờ double-tap
            }
        }
    }

    protected void getOnKeyXDown(){
        this.onKeyX = Input.GetKeyDown(KeyCode.X) ? true : false;
    }
} 
