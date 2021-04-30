using UnityEngine;

namespace RPG.Core
{
    public class CameraFollowPoint : MonoBehaviour
    {
        [SerializeField] private Transform target;

        void LateUpdate()
        {
            transform.position = target.position;
        }
    }
}
