using UnityEngine;

namespace UtilityAI
{
    public class Brain : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _player;

        [Header("Actions")]
        [SerializeField] private Action[] _actions;

        [Header("Debug")]
        [SerializeField] private float _thinkInterval = 0.5f;

        private float _nextThinkTime;
        private Context _context;
        private Action _bestAction;

        private void Start()
        {
            if (_player == null)
            {
                var playerObj = GameObject.FindWithTag("Player");
                if (playerObj != null)
                {
                    _player = playerObj.transform;
                }
            }

            if (_player == null)
            {
                Debug.LogError("[Brain] Player not found");
                enabled = false;
                return;
            }

            _context = new Context(this, _player);
        }

        private void Update()
        {
            _context.Update();

            if (Time.time < _nextThinkTime)
            {
                return;
            }

            _nextThinkTime = Time.time + _thinkInterval;
            Think();
            Execute();
        }

        private void Think()
        {
            Action bestAction = null;
            float bestUtility = float.MinValue;

            foreach (var action in _actions)
            {
                if (action == null)
                    continue;

                float utility = action.Evaluate(_context);

                if (utility > bestUtility)
                {
                    bestUtility = utility;
                    bestAction = action;
                }
                
                _bestAction = bestAction;
            }

            Debug.Log(
                $"[Brain] BestAction={bestAction?.name ?? "None"}, Utility={bestUtility:F2}, " +
                $"Distance={_context.DistanceToPlayer:F2}, " +
                $"ActorStance={_context.ActorStance?.CurrentStance}, " +
                $"PlayerStance={_context.PlayerStance?.CurrentStance}"
            );
        }
        
        private void Execute()
        {
            _bestAction?.Execute(_context);
        }

    }
}
