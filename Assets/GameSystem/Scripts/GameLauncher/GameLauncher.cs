using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystem
{
    public sealed class GameLauncher : MonoBehaviour
    {
        [SerializeField]
        private bool autoRun = true;
        
        [SerializeField]
        private List<GameTask> taskList;

        private async void Start()
        {
            if (this.autoRun)
            {
                await this.LaunchGame();
            }
        }

        [ContextMenu("Launch Game")]
        public async Task LaunchGame()
        {
            foreach (var task in this.taskList)
            {
                await task.Do();
            }
        }
    }
}