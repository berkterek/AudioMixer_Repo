using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteUnmuteButton : MonoBehaviour
{
    [SerializeField] bool _isMute = false;
    [SerializeField] string _parameterName = string.Empty;
    [SerializeField] Button _button;
    [SerializeField] AudioMixerGroup _audioMixerGroup;

    void OnValidate()
    {
        if (_button == null) _button.GetComponent<Button>();
    }

    void OnEnable()
    {
        _button.onClick.AddListener(HandleOnButtonClicked);
    }

    void OnDisable()
    {
        _button.onClick.RemoveListener(HandleOnButtonClicked);
    }
    
    void HandleOnButtonClicked()
    {
        _isMute = !_isMute;
        
        if (_isMute)
        {
            _audioMixerGroup.audioMixer.SetFloat(_parameterName, -80f);
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat(_parameterName, 0f);
        }
    }
}
