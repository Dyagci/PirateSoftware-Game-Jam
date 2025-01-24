using UnityEngine;
using FMOD;
using FMODUnity;
using Debug = UnityEngine.Debug;
using UnityEngine.Profiling;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SetFMODValue : SetSliderValue
{
    [SerializeField] private string _parameterName;

    public override void SetValue(float value)
    {
        base.SetValue(value);

        if(string.IsNullOrEmpty(_parameterName))
        {
            return;
        }

        float remappedValue = SliderValueToOutputValue(value);
        RESULT result = RuntimeManager.StudioSystem.setParameterByName(_parameterName, remappedValue);

        if(result != RESULT.OK)
        {
            Debug.Log($"FMOD parameter set fail: {result}");
        }
    }

    private void OnEnable()
    {
        if (string.IsNullOrEmpty(_parameterName))
        {
            return;
        }

        if (TryGetComponent(out Slider slider))
        {
            RESULT result = RuntimeManager.StudioSystem.getParameterByName(_parameterName, out float value);
            if (result == RESULT.OK)
            {
                float sliderValue = OutputValueToSliderValue(value);
                slider.SetValueWithoutNotify(sliderValue);
            }
        }
    }
}
