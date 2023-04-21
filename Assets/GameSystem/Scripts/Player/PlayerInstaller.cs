using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public sealed class PlayerInstaller : MonoBehaviour,
        IGameServiceProvider,
        IGameListenerProvider,
        IGameConstructor
    {
        private readonly MoveController moveController = new();

        //private readonly CameraController cameraController = new();

        [SerializeField]
        private Player player;


        IEnumerable<object> IGameServiceProvider.GetServices()
        {
            yield return this.player;
        }

        IEnumerable<object> IGameListenerProvider.GetListeners()
        {
            yield return this.moveController;
            //yield return this.cameraController;
        }

        void IGameConstructor.ConstructGame(IGameLocator serviceLocator)
        {
            var keyboardInput = serviceLocator.GetService<IMoveInput>();
            this.moveController.Construct(keyboardInput, this.player);

            //var camera = serviceLocator.GetService<WorldCamera>();
            // this.cameraController.Construct(camera, this.player)
        }
    }
}