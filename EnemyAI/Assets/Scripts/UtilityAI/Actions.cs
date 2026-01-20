using UnityEngine;

namespace UtilityAI
{
    public abstract class Action : ScriptableObject
    {
        public abstract float Evaluate(Context context);

        public virtual void Execute(Context context)
        {
            // optional override
        }
    }
}