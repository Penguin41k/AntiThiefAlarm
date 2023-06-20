using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeSpeed;

    private float _targetVolume;
    private Coroutine _changeVolumeJob;

    public void TurnOn()
    {
        _targetVolume = 1;
        StartChangeVolume();
    }

    public void TurnOff()
    {
        _targetVolume = 0;
        StartChangeVolume();
    }

    private void StartChangeVolume()
    {
        if (_changeVolumeJob != null)
        {
            StopCoroutine(_changeVolumeJob);
        }

        _changeVolumeJob = StartCoroutine(ChangeVolume(_targetVolume));
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
