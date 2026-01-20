using UnityEngine;

namespace UtilityAI.Considerations
{
    [CreateAssetMenu(menuName = "UtilityAI/Considerations/DistanceToPlayer")]
    public class DistanceToPlayerConsideration : Consideration
    {
        [SerializeField] private float _minDistance = 0f;
        [SerializeField] private float _maxDistance = 10f;

        public override float Evaluate(Context context)
        {
            float distance = context.DistanceToPlayer;

            if (distance <= _minDistance)
                return 1f;

            if (distance >= _maxDistance)
                return 0f;

            // нормалізуємо 0..1
            return 1f - ((distance - _minDistance) / (_maxDistance - _minDistance));
        }
    }
}