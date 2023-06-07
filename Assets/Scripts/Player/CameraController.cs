using UnityEngine;

namespace Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        
        private void Update()
        {
            var position = player.position;
            var tf = transform;
            tf.position = new Vector3(position.x, position.y, tf.position.z);
        }
    }
}
