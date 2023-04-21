using System.Threading.Tasks;
using GameSystem;
using UnityEngine;

namespace Lessons.Articles.GameSystem
{
    [CreateAssetMenu(
        fileName = "Task «Start Game»",
        menuName = "GameTasks/Task «Start Game»"
    )]
    public sealed class GameTask_StartGame : GameTask
    {
        public override Task Do()
        {
            GameObject
                .FindGameObjectWithTag(TagManager.GAME_CONTEXT)
                .GetComponent<GameContext>()
                .StartGame();

            return Task.CompletedTask;
        }
    }
}