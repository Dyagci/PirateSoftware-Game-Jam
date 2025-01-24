using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SetGammaValue : SetSliderValue
{
    [SerializeField] private VolumeProfile _profile;

    public override void SetValue(float value)
    {
        base.SetValue(value);

        // check for existing LiftGammaGain component
        if(_profile.TryGet(out LiftGammaGain liftGammaGain))
        {
            float gammaValue = SliderValueToOutputValue(value);
            liftGammaGain.gamma.value = Vector4.one * gammaValue;
        }
        else
        {
            Debug.LogWarning("No LiftGammaGain component found on Volume!", _profile);
        }
    }

    private void OnEnable()
    {
        if(_profile.TryGet(out LiftGammaGain liftGammaGain) && TryGetComponent(out Slider slider))
        {
            float currentGamma = liftGammaGain.gamma.value.x;
            float sliderValue = OutputValueToSliderValue(currentGamma);

            slider.SetValueWithoutNotify(sliderValue);
        }
    }
}
