using UnityEngine;
using FMOD;
using FMODUnity;
using Debug = UnityEngine.Debug;

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
}
