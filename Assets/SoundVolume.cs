using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private Coroutine _controlVolume;

    public void VolumeUp()
    {
        int target = 1;
        CoroutineControl(target);
    }
    public void VolumeDown()
    {
        int target = 0;
        CoroutineControl(target);
    }

    private void CoroutineControl(float target)
    {
        if (_controlVolume != null)
        {
            StopCoroutine(_controlVolume);
        }

        _controlVolume = StartCoroutine(VolumeChanger(target));
    }

    private IEnumerator VolumeChanger(float target)
    { 
        float _recoveryRate = 0.1f;
                
        while (_sound.volume != target)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, target, _recoveryRate * Time.deltaTime);
            yield return null;
        }              
    }
}
