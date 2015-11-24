using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace StateMachine
{


    public class CharacterStateMachine : MonoBehaviour
    {
        [ReadOnly][SerializeField]
        List<States> activeStates = new List<States>();
        Dictionary<States, StateStruct> activeStatesDict = new Dictionary<States, StateStruct>();

        States[] movementStates = new States[]  { States.m_WALKING, States.m_STANDING, States.m_SPRINTING};
        States[] disabledStates = new States[]  { States.d_FLINCH, States.d_HELPLESS, States.d_LEDGE_GRAB, States.d_LAUNCHED, States.d_ABILITY_LOCK, States.d_GRABBED, States.d_BURIED, States.d_ASLEEP, States.d_FROZEN, States.d_VULNERABLE, States.d_STUNNED, States.d_THROWN, States.d_SLOW_MOTION, States.d_TRIPPED };
        States[] protectiveStates = new States[] { States.NO_COLLISION, States.NO_DAMAGE, States.NO_FLINCH, States.NO_GRAB, States.NO_KNOCKBACK };

        public struct StateStruct
        {
            public States state;
            public Action onEnterFunction;
            public Action onUpdateFunction;
            public Action onExitFunction;
            public float time;
            public Timer timer;


            public StateStruct( States state, Action onEnterFunction, Action onUpdateFunction, Action onExitFunction, float time, CharacterStateMachine stateMachine )
            {
                this.state = state;
                this.onEnterFunction = onEnterFunction;
                this.onUpdateFunction = onUpdateFunction;
                this.onExitFunction = onExitFunction;
                this.time = time;

                this.timer = new Timer(time, stateMachine, state);
                if(onEnterFunction != null)
                    timer.timerStarted += onEnterFunction;
                if(onUpdateFunction != null)
                    timer.timerUpdate += onUpdateFunction;
                if(onExitFunction != null)
                    timer.timerCompleted += onExitFunction;
            }
        }

        public void AddState( States state, float time = 0, Action onEnterFunction = null, Action onUpdateFunction = null, Action onExitFunction = null )
        {
            if(activeStates.Contains(state))
            {
                if(!activeStatesDict.ContainsKey(state))
                    Debug.Log("WT: State " + state + " existed in List but was not in Dict");
                else
                {
                    if(activeStatesDict[state].timer == null || activeStatesDict[state].timer.TimeRemaining > time)
                        return;
                    else
                    {
                        if(activeStatesDict[state].timer != null)
                            activeStatesDict[state].timer.ResetTimer(time);
                        return;
                    }
                }
            }
            else
            {
                if(activeStatesDict.ContainsKey(state))
                    if(!activeStates.Contains(state))
                        Debug.Log("WT: State " + state + " existed in Dict but was not in List");

                activeStates.Add(state);
                StateStruct temp = new StateStruct(state, onEnterFunction, onUpdateFunction, onExitFunction, time, this);
                activeStatesDict.Add(state, temp);
            }
        }

        public void RemoveState( States state )
        {
            if(activeStates.Contains(state))
            {
                if(activeStatesDict.ContainsKey(state))
                {
                    StateStruct temp = activeStatesDict[state];
                    temp.timer.kill();
                    activeStatesDict.Remove(state);
                    activeStates.Remove(state);
                }
            }
        }

        public List<States> ActiveStates
        {
            get
            {
                return activeStates.AsReadOnly().ToList();
            }
        }

        /// <summary>
        /// Returns true if all of the States passed in are active. False if one or more was not active.
        /// </summary>
        /// <param name="states">
        /// States you want to check.
        /// </param>
        /// <returns></returns>
        public bool AreStatesActive( params States[] states )
        {
            foreach(States s in states)
            {
                if(!activeStates.Contains(s))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Returns true if all of the States passed in are Not Active. False if one or more was active.
        /// </summary>
        /// <param name="states">
        /// States you want to check.
        /// </param>
        /// <returns></returns>
        public bool AreStatesInActive( params States[] states )
        {
            foreach(States s in states)
            {
                if(activeStates.Contains(s))
                    return false;
            }
            return true;
        }

        public bool IsStateActive( States state )
        {
            return activeStates.Contains(state);
        }

        public void DebugActiveStates()
        {
            foreach(States s in activeStates) { Debug.Log(s.ToString()); }
        }

        public void RemoveSimilarStates( States[] stateType, States stateToIgnore )
        {
            foreach(States state in stateType)
            {
                if(state == stateToIgnore)
                    continue;
                RemoveState(state);
            }
        }

        public void RemoveAllStates()
        {
            foreach(States state in Enum.GetValues(typeof(States)))
            {
                RemoveState(state);
            }
        }

    }

    public enum States
    {
        /*MOVEMENT STATES*/     m_STANDING, m_WALKING, m_SPRINTING, m_CROUCHING, m_AERIAL, 
        /*DISABLE STATES*/      d_FLINCH, d_HELPLESS,  d_LEDGE_GRAB, d_LAUNCHED, d_ABILITY_LOCK, d_GRABBED, d_BURIED, d_ASLEEP, d_FROZEN, d_VULNERABLE, d_STUNNED, d_THROWN, d_SLOW_MOTION, d_TRIPPED,
        /*PROTECTIVE STATES*/   NO_FLINCH, NO_COLLISION, NO_KNOCKBACK, HAS_ITEM, NO_DAMAGE, NO_GRAB
    };

}