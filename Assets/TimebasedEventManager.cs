using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimebasedEventManager : MonoBehaviour
{
    public List<TimeBasedEvent> events = new List<TimeBasedEvent>();

    void Update()
    {
        float year = GameManager.Singleton.getYear();
        events.ForEach(e => {
            if(e.disabled)
            {
                return;
            }
            if(e.time < year)
            {
                if(e.dialogue != "")
                {
                    DialogueBox.Singleton.Display(e.dialogue);
                }

                e.functionEvent.Invoke();

                Debug.Log("Showed");

                e.disabled = true;
            }
        });
    }

    [System.Serializable]
    public class TimeBasedEvent
    {
        public float time = 1947;
        [TextArea(5, 10)]
        public string dialogue;
        public UnityEngine.Events.UnityEvent functionEvent;
        [HideInInspector]
        public bool disabled = false;
    }
}
