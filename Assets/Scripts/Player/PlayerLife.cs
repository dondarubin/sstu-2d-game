using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerLife : MonoBehaviour
    {
        private Animator _anim;
        private Rigidbody2D _rb;

        private static readonly int Death = Animator.StringToHash("Death");
        [SerializeField] private AudioSource deathSound;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag($"Trap") || collision.gameObject.name == "DeathZone")
            {
                Die();
            }
        }

        private void Die()
        {
            deathSound.Play();
            _rb.bodyType = RigidbodyType2D.Static;
            _anim.SetTrigger(Death);
        }

        private void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
