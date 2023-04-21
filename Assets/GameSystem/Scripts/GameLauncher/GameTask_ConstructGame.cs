using System.Threading.Tasks;
using UnityEngine;

namespace GameSystem
{
    [CreateAssetMenu(
        fileName = "Task «Construct Game»",
        menuName = "GameTasks/Task «Construct Game»"
    )]
    public sealed class GameTask_ConstructGame : GameTask
    {
        public override Task Do()
        {
            var gameContext = GameObject
                .FindGameObjectWithTag(TagManager.GAME_CONTEXT)
                .GetComponent<GameContext>();
            
            var installers = GameObject
                .FindGameObjectsWithTag(TagManager.GAME_INSTALLER);   
            
            foreach (var installer in installers)
            {
                if (installer.TryGetComponent(out IGameServiceProvider serviceProvider))
                {
                    gameContext.AddServices(serviceProvider.GetServices());
                }

                if (installer.TryGetComponent(out IGameListenerProvider listenerProvider))
                {
                    gameContext.AddListeners(listenerProvider.GetListeners());
                }
            }
            
            foreach (var installer in installers)
            {
                if (installer.TryGetComponent(out IGameConstructor constructor))
                {
                    constructor.ConstructGame(gameContext);
                }
            }
            
            return Task.CompletedTask;
        }
    }
}