using UnityEngine;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(menuName = "UtilityAI/Actions/FacePlayer")]
    public class FacePlayerAction : Action
    {
        [SerializeField] private Consideration _distanceConsideration;

        [SerializeField, Range(0f, 180f)]
        private float _maxTurnAngle = 90f;

        [SerializeField]
        private float _turnSpeed = 5f;

        public override float Evaluate(Context context)
        {
            if (_distanceConsideration == null)
                return 0f;

            return _distanceConsideration.Evaluate(context);
        }

        public override void Execute(Context context)
        {
            if (context.HeadTransform == null)
                return;

            Vector3 toPlayer = (context.Player.position - context.HeadTransform.position).normalized;
            toPlayer.y = 0;

            Vector3 headForward = context.HeadTransform.forward;
            headForward.y = 0;

            float angle = Vector3.SignedAngle(headForward, toPlayer, Vector3.up);

            float clampedAngle = Mathf.Clamp(angle, -_maxTurnAngle, _maxTurnAngle);

            Quaternion targetRotation = Quaternion.AngleAxis(clampedAngle, Vector3.up) * context.HeadTransform.rotation;

            context.HeadTransform.rotation = Quaternion.Slerp(
                context.HeadTransform.rotation,
                targetRotation,
                Time.deltaTime * _turnSpeed
            );
        }
    }
}