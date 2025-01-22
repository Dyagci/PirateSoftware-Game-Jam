using UnityEngine;

public class SetSliderValue : MonoBehaviour
{
    [SerializeField] protected Vector2 _outMinMax = new Vector2(-0.5f,0.5f);
    [SerializeField] protected float _sliderMaxValue = 10f;

    public virtual void SetValue(float value)
    {

    }

    protected float SliderValueToOutputValue(float value)
    {
        // remaps from slider to outMinMax range
        float percentage = value / _sliderMaxValue;
        float remappedValue = Mathf.Lerp(_outMinMax.x, _outMinMax.y, percentage);
        return remappedValue;
    }

    protected float OutputValueToSliderValue(float value)
    {
        // remaps from outMinMax to slider range
        float percentage = Mathf.InverseLerp(_outMinMax.x,_outMinMax.y,value);
        float sliderValue = percentage * _sliderMaxValue;
        return sliderValue;
    }
}
