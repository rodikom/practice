using UnityEngine;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(menuName = "UtilityAI/Actions/Idle")]
    public class IdleAction : Action
    {
        [SerializeField] private float _utility = 0.2f;

        public override float Evaluate(Context context)
        {
            return _utility;
        }
    }
}