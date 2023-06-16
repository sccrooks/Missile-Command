using UnityEngine;

namespace Sccrooks.Utility.ScriptableObjects.Events
{
    public class ColourEventListener : MonoBehaviour
    {
        [Tooltip("Event to reguster with.")]
        public ColourEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public MyColourEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(Color data)
        {
            Response.Invoke(data);
        }
    }
}
