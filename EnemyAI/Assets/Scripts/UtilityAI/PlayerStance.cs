using UnityEngine;
using UtilityAI;

namespace UtilityAI
{
    public class PlayerStance : MonoBehaviour
    {
        [SerializeField]
        private Stance _currentStance = Stance.Peaceful;

        public Stance CurrentStance => _currentStance;
    }
}