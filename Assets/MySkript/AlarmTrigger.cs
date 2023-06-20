using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent[] _activated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefController>(out ThiefController thief))
        {
            Debug.Log("Зашел");
            int numberOfEvent = 0;
            _activated[numberOfEvent].Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ThiefController>(out ThiefController thief))
        {
            Debug.Log("Вышел");
            int numberOfEvent = 1;
            _activated[numberOfEvent].Invoke();
        }
    }
}
