using UnityEngine;

namespace UtilityAI
{
    public class ActorStance: MonoBehaviour
    {
        [SerializeField]
        private Stance _currentStance = Stance.Peaceful;

        public Stance CurrentStance => _currentStance;
    }
}