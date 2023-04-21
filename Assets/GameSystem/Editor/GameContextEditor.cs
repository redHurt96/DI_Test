using System;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace GameSystem
{
    [CustomEditor(typeof(GameContext))]
    public sealed class GameContextEditor : UnityEditor.Editor
    {
        private GameContext gameContext;

        private void OnEnable()
        {
            this.gameContext = this.target as GameContext;
        }

        public override void OnInspectorGUI()
        {
            GUI.enabled = false;
            EditorGUILayout.EnumPopup("State:", this.gameContext.GameState);
            GUI.enabled = true;

            EditorGUILayout.Space(12);
            if (GUILayout.Button("Start Game"))
            {
                this.gameContext.StartGame();
            }

            if (GUILayout.Button("Pause Game"))
            {
                this.gameContext.PauseGame();
            }
            
            if (GUILayout.Button("Resume Game"))
            {
                this.gameContext.ResumeGame();
            }

            if (GUILayout.Button("Finish Game"))
            {
                this.gameContext.FinishGame();
            }
        }
    }
}
#endif