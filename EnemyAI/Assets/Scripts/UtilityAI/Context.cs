using System.Collections.Generic;
using UnityEngine;
using UnityUtils;

namespace UtilityAI
{
    public class Context
    {
        public readonly Brain Brain;
        public readonly Transform Self;
        public readonly Transform Player;

        public readonly ActorStance ActorStance;
        public readonly PlayerStance PlayerStance;

        public float DistanceToPlayer { get; private set; }
        public Transform HeadTransform { get; private set; }

        private readonly Dictionary<string, object> _data;

        public Context(Brain brain, Transform player)
        {
            Preconditions.CheckNotNull(brain, nameof(brain));
            Preconditions.CheckNotNull(player, nameof(player));

            Brain = brain;
            Self = brain.transform;
            Player = player;

            ActorStance = brain.GetComponent<ActorStance>();
            PlayerStance = player.GetComponent<PlayerStance>();

            _data = new Dictionary<string, object>();
            
            var animator = brain.GetComponent<Animator>();
            if (animator != null)
            {
                HeadTransform = animator.GetBoneTransform(HumanBodyBones.Head);
            }
        }

        public void Update()
        {
            DistanceToPlayer = Vector3.Distance(Self.position, Player.position);
        }

        public T GetData<T>(string key)
        {
            return _data.TryGetValue(key, out var value) ? (T)value : default;
        }

        public void SetData(string key, object value)
        {
            _data[key] = value;
        }
    }
}