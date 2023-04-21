using System;
using UnityEngine;

namespace GameSystem
{
    public interface IMoveInput
    {
        event Action<Vector3> OnMove;
    }

    public sealed class KeyboardInput :
        IMoveInput,
        IStartGameListener,
        IUpdateGameListener,
        IFinishGameListener
    {
        public event Action<Vector3> OnMove;

        private bool isActive;

        void IUpdateGameListener.OnUpdate(float deltaTime)
        {
            if (this.isActive)
            {
                this.HandleKeyboard();
            }
        }

        void IStartGameListener.OnStartGame()
        {
            this.isActive = true;
        }

        void IFinishGameListener.OnFinishGame()
        {
            this.isActive = false;
        }


        private void HandleKeyboard()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.Move(Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.Move(Vector3.back);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.Move(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.Move(Vector3.right);
            }
        }

        private void Move(Vector3 direction)
        {
            this.OnMove?.Invoke(direction);
        }
    }
}