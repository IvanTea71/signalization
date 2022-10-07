using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalZone : MonoBehaviour
{
    [SerializeField] private UnityEvent _soundTurn; 
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _soundTurn?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _soundTurn?.Invoke();
        }
    }
}
