using RpgRougeliketest.TurnBasedSystem.Units;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RpgRougeliketest.TurnBasedSystem.Events
{
    using EventFunction = Func<BaseUnit, BaseUnit, EventArgs?, int>;

    public class EventSystem
    {
        Dictionary<EventID, List<EventFunction>> eventSub = new Dictionary<EventID, List<EventFunction>>();

        public enum EventID : int
        {
            DamageTaken,
            DamageDealt,
            KillOther,
            KillSelf
        }

        public void AddFunctionToHook(EventFunction func, EventID id)
        {
            if (!eventSub.ContainsKey(id))
            {
                eventSub.Add(id, new List<EventFunction>());
            }
            if (eventSub[id] == null)
                eventSub[id] = new List<EventFunction>();

            eventSub[id].Add(func);
        }
        //public void AddHook(Action action, EventID id)
        //{
        //    if (!eventSub.ContainsKey(id))
        //    {
        //        eventSub.Add(id, new List<Action>());   
        //    }
        //    if (eventSub[id] == null)
        //        eventSub[id] = new List<Action>();

        //    eventSub[id].Add(action);
        //}

        public void RunHook(EventID id, BaseUnit me, BaseUnit other, EventArgs? e)
        {
            //if (!eventSub.ContainsKey(id))
            //{
            //    eventSub.Add(id, new List<Action>());
            //}
            //if (eventSub[id] == null)
            //    eventSub[id] = new List<Action>();
            if (eventSub.TryGetValue(id, out List<EventFunction> funcList))
            {
                foreach (var function in funcList)
                {
                    int result = function(me, other, e);
                }
            }
            else
            {
                eventSub.Add(id, new List<EventFunction>());
            }
        }

        public void RemoveHook(EventID id, int index)
        {
            if (index == -1)
            {
                eventSub.Remove(id);
                eventSub.Add(id, new List<EventFunction>());
            }
            else if(eventSub.TryGetValue(id, out List<EventFunction> funcList))
            {
                if(funcList.Count > index)
                    funcList.RemoveAt(index);
            }


        }
    }

    public struct EventArgs 
    {
        public double[] args;
        public EventArgs(double[] args) 
        { 
            this.args = args; 
        }

        public double this[int index]
        {
            get
            {
                return args[index];
            }
            internal set
            {
                args[index] = value;
            }
        }
    }
}
