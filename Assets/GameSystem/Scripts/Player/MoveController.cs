using UnityEngine;

namespace GameSystem
{
    public sealed class MoveController : 
        IStartGameListener,
        IFinishGameListener
    {
        private IMoveInput input;

        private IPlayer player;

        public void Construct(IMoveInput input, IPlayer player)
        {
            this.input = input;
            this.player = player;
        }

        void IStartGameListener.OnStartGame()
        {
            this.input.OnMove += this.OnMove;
        }

        void IFinishGameListener.OnFinishGame()
        {
            this.input.OnMove -= this.OnMove;
        }

        private void OnMove(Vector3 direction)
        {
            this.player.Move(direction);
        }
    }
}