using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeSpeed;
    [SerializeField, Range (0, 1)] private float _targetVolumeInOnState;

    private float _volumeInOffState = 0;
    private Coroutine _changeVolumeJob;

    public void TurnOn()
    {
         StartChangeVolume(_targetVolumeInOnState);
    }

    public void TurnOff()
    {
         StartChangeVolume(_volumeInOffState);
    }

    private void StartChangeVolume(float targetVolume)
    {
        if (_changeVolumeJob != null)
        {
            StopCoroutine(_changeVolumeJob);
        }

        _changeVolumeJob = StartCoroutine(ChangeVolume(targetVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime * _volumeChangeSpeed);
            yield return null;
        }

        if (_audioSource.volume <= 0 && _audioSource.isPlaying == true)
        {
            _audioSource.Stop();
        }
    }
}
