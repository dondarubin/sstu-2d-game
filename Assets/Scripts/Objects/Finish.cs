using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Objects
{
    public class Finish : MonoBehaviour
    {
        private AudioSource _finishSound;
        public static bool IsCompleted = false;

        private void Start()
        {
            IsCompleted = false;
            _finishSound = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Player" && !IsCompleted)
            {
                _finishSound.Play();
                IsCompleted = true;
                Invoke(nameof(CompleteLevel), 2.5f);
            }
        }
        
        private void CompleteLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}