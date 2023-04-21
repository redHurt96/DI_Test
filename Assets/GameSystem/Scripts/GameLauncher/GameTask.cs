using System.Threading.Tasks;
using UnityEngine;

namespace GameSystem
{
    public abstract class GameTask : ScriptableObject
    {
        public abstract Task Do();
    }
}