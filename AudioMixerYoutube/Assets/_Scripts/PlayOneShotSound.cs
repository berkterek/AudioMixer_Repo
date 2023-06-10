using UnityEngine;
using UnityEngine.UI;

public class PlayOneShotSound : MonoBehaviour
{
    [SerializeField] AudioClip[] _clips;
    [SerializeField] Button _button;
    [SerializeField] AudioSource _audioSource;

    int _length;

    void OnValidate()
    {
        if (_button == null) _button = GetComponent<Button>();
        if (_audioSource == null) _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        _length = _clips.Length;
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
        _audioSource.PlayOneShot(_clips[Random.Range(0, _length)]);
    }
}