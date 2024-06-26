using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    [SerializeField] private AudioSource themeSong;
    
    public UnityEvent onPlayerEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Won");
            themeSong.Stop();
            Time.timeScale = 0;
            //onPlayerEnter?.Invoke();
        }
    }
}
