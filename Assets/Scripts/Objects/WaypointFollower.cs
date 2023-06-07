using UnityEngine;

namespace Objects
{
    public class WaypointFollower : MonoBehaviour
    {
        [SerializeField] private GameObject[] waypoints;
        [SerializeField] private float speed = 2f;
        private int _currentWaypointIndex = 0;

        private void Update()
        {
            if (Vector2.Distance(waypoints[_currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                _currentWaypointIndex++;
                if (_currentWaypointIndex >= waypoints.Length)
                {
                    _currentWaypointIndex = 0;
                }
            }

            transform.position = Vector3.MoveTowards(
                transform.position,
                waypoints[_currentWaypointIndex].transform.position,
                Time.deltaTime * speed);
        }
    }
}