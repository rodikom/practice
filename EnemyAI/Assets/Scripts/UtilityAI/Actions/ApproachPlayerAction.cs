using UnityEngine;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(menuName = "UtilityAI/Actions/ApproachPlayer")]
    public class ApproachPlayerAction : Action
    {
        [SerializeField] private Consideration _distanceConsideration;

        public override float Evaluate(Context context)
        {
            if (_distanceConsideration == null)
                return 0f;

            return _distanceConsideration.Evaluate(context);
        }
    }
}