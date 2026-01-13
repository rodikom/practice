using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityUtils;

namespace UtilityAI
{
    public class Context {
        public Brain brain;
        public NavMeshAgent agent;
        public Transform target;
        public Sensor sensor;

        private readonly Dictionary<string, object> data;

        public Context(Brain brain)
        {
            Preconditions.CheckNotNull(brain, nameof (brain));
            
            this.brain = brain;
            this.agent = brain.gameObject.GetComponent<NavMeshAgent>();
            this.sensor = brain.gameObject.GetComponent<Sensor>();
        }
        
        public T GetData<T>(string key) => data.TryGetValue(key, out var value) ? (T)value : default;
        public void SetData(string key, object value) => data[key] = value;            
    }
}