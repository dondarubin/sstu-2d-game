using UnityEngine;

namespace Objects
{
    public class Rotate : MonoBehaviour
    {
        [SerializeField] private float speed = 1.5f;

        public void Update()
        {
            transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
        }
    }
}
