using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    private Coroutine _controlVolume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            CoroutineControl(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            CoroutineControl(0);
        }
    }

    private void CoroutineControl(float target)
    {
        if (_controlVolume != null)
        {
            StopCoroutine(_controlVolume);
        }

        _controlVolume = StartCoroutine(VolumeUpDown(target));
    }

    private IEnumerator VolumeUpDown(float target)
    {   
        float _maxStrength = target;
        float _recoveryRate = 0.1f;
                
        while (_sound.volume != target)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, _maxStrength, _recoveryRate * Time.deltaTime);
            yield return null;
        }              
    }
}
