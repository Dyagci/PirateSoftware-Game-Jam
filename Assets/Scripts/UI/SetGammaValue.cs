using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

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
}
