using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : ModelMonoBehaviour
{
    [SerializeField]
    protected Slider slider;

    protected override void Awake()
    {
        base.Awake();
        LoadSlider();
        AddOnValueChangeEvent();
    }

    private void LoadSlider()
    {
        slider = GetComponent<Slider>();
    }

    protected void AddOnValueChangeEvent()
    {
        slider.onValueChanged.RemoveAllListeners(); 
        slider.onValueChanged.AddListener((value) => OnValueChanged(value));
    }

    public abstract void OnValueChanged(float value);
}
