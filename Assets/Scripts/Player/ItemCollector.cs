using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class ItemCollector : MonoBehaviour
    {
        private int _melonCount = 0;
        private int _appleCount = 0;
        private int _strawberryCount = 0;
        [SerializeField] private Text melonText;
        [SerializeField] private Text appleText;
        [SerializeField] private Text strawberryText;
        
        [SerializeField] private AudioSource collectSound;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collectSound.Play();
            if (collision.gameObject.CompareTag($"Melon"))
            {
                Destroy(collision.gameObject);
                _melonCount++;
                melonText.text = "Melons: " + _melonCount;
            }
            else if (collision.gameObject.CompareTag($"Apple"))
            {
                Destroy(collision.gameObject);
                _appleCount++;
                appleText.text = "Apples: " + _appleCount;
            }
            else if (collision.gameObject.CompareTag($"Strawberry"))
            {
                Destroy(collision.gameObject);
                _strawberryCount++;
                strawberryText.text = "Strawberry's: " + _strawberryCount;
            }
        }
    }
}
