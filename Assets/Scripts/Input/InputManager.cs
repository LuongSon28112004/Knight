using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : ModelMonoBehaviour
{
    //singleton
    protected static InputManager instance;
    public static InputManager Instance
    {
        get => instance;
    }

    //move left and right
    [SerializeField]
    private float horizontalInput;
    public float HorizontalInput
    {
        get => horizontalInput;
    }

    //click button on button space
    [SerializeField]
    private bool onSpace;
    public bool OnSpace
    {
        get => onSpace;
    }

    //click key X
    [SerializeField]
    private bool onKeyX;
    public bool OnKeyX
    {
        get => onKeyX;
    }

    [SerializeField]
    private bool onKeyC;
    public bool OnKeyC
    {
        get => onKeyC;
    }

    protected override void Awake()
    {
        if (InputManager.instance != null)
            Debug.LogWarning("can't have 2 inputManager in obj");
        InputManager.instance = this;
    }

    void Update()
    {
        this.getHorizontalInput();
        this.getOnSpaceDown();
        this.getOnKeyXDown();
        this.getOnKeyCDown();
    }

    protected void getHorizontalInput()
    {
        this.horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    protected void getOnSpaceDown()
    {
        this.onSpace = Input.GetKey(KeyCode.Space) ? true : false;
    }


    protected void getOnKeyXDown()
    {
        this.onKeyX = Input.GetKeyDown(KeyCode.X) ? true : false;
    }

    protected void getOnKeyCDown()
    {
        this.onKeyC = Input.GetKeyDown(KeyCode.C) ? true : false;
    }
}
