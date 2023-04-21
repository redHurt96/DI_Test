using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public sealed class InputInstaller : MonoBehaviour,
        IGameServiceProvider,
        IGameListenerProvider
    {
        private readonly KeyboardInput keyboardInput = new();

        //[SerializeField]
        //private MouseInput mouseInput;

        IEnumerable<object> IGameServiceProvider.GetServices()
        {
            yield return this.keyboardInput;
            //yield return this.mouseInput;
        }

        IEnumerable<object> IGameListenerProvider.GetListeners()
        {
            yield return this.keyboardInput;
            //yield return this.mouseInput;
        }
    }
}