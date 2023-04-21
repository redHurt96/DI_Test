using UnityEngine;

namespace GameSystem
{
    public interface IPlayer
    {
        void Move(Vector3 direction);
    }

    public sealed class Player : MonoBehaviour, IPlayer
    {
        [SerializeField]
        private float speed = 2.0f;

        public void Move(Vector3 direction)
        {
            this.transform.position += direction * this.speed * Time.deltaTime;
        }
    }
}