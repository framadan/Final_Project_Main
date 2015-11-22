using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine
{
    /*                                              Velocity Based?
         THESE MIGHT NEED TO BE SEPPARATED SINCE THEY ARE NOT EXPLICITLY STATES:   Character Movements States: Standing, (Might be the same)(Walking, Running)
            Character Disable States:   Helpless(falling: ie after up B)(can still move side to side), LedgeGrab, Disabled (when hit with high percent)(nothing works)
            Character Ability States:   Invincible(cant take dmg, everything available), UnMoveable(when using a move), AbilityLockOut(cant use anyothers when using a move), UnCollidable(dashing)
    */
    public class CharacterStateMachine
    {
        List<States> activeStates = new List<States>();
        Dictionary<States, StateStruct> activeStatesDict = new Dictionary<States, StateStruct>();
        

        public struct StateStruct
        {
            public States state;
            public System.Action callbackFunction;
            public float time;
            //needs access to the timer 

            public StateStruct( States state, System.Action callbackFunction , float time )
            {
                this.state = state;
                this.callbackFunction = callbackFunction;
                this.time = time;
            }
        }

        public void AddState(States state, System.Action callbackFunction = null, float time = 0)
        {
            if(activeStates.Contains(state))
            { // need to add functionallity here to add to the reset time if it contains is.
                if(!activeStatesDict.ContainsKey(state))
                    Debug.Log("WT: State " + state + " existed in List but was not in Dict");
                else
                    return;
            }
            else
            {
                if(activeStatesDict.ContainsKey(state))
                    if(!activeStates.Contains(state))
                        Debug.Log("WT: State " + state + " existed in Dict but was not in List");

                activeStates.Add(state);
                //Create timer class
                StateStruct temp = new StateStruct(state, callbackFunction , time);// and later pass the Timer that was created
                activeStatesDict.Add(state, temp);
            }

            //add state, needs to check if current state is in it and if it is, prolong state.
            //if timer is not 0 then create a new instance of a timer class and pass it struct
        }

        public void RemoveState(States state)
        {
            if(activeStates.Contains(state))
            {
                if(activeStatesDict.ContainsKey(state))
                {
                    StateStruct temp = activeStatesDict[state];
                    if(temp.callbackFunction != null)
                        temp.callbackFunction();
                    activeStatesDict.Remove(state);
                    activeStates.Remove(state);
                }
            }
           // Also end the Timer
        }

        public List<States> ActiveStates
        {
            get
            {
                return activeStates;
            }
        }

        /// <summary>
        /// Returns true if all of the States passed in are active. False if one or more was not active.
        /// </summary>
        /// <param name="states">
        /// States you want to check.
        /// </param>
        /// <returns></returns>
        public bool AreStatesActive(params States[] states)
        {
            foreach(States s in states)
            {
                if(!activeStates.Contains(s))
                    return false;
            }
            return true;
        }

        public bool IsStateActive(States state)
        {
            return activeStates.Contains(state);
        }

        public void DebugActiveStates()
        {
            foreach(States s in activeStates) { Debug.Log(s.ToString()); }
        }

    }
    public enum States
    {
        test1, test2
    };

}