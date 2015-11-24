using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine
{


    public class CharacterStateMachine : MonoBehaviour
    {
        [ReadOnly][SerializeField]
        List<States> activeStates = new List<States>();
        Dictionary<States, StateStruct> activeStatesDict = new Dictionary<States, StateStruct>();
        

        public struct StateStruct
        {
            public States state;
            public System.Action onEnterFunction;
            public System.Action onUpdateFunction;
            public System.Action onExitFunction;
            public float time;
            public Timer timer;


            public StateStruct( States state, System.Action onEnterFunction, System.Action onUpdateFunction, System.Action onExitFunction, float time, CharacterStateMachine stateMachine )
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

        public void AddState( States state, float time = 0, System.Action onEnterFunction = null, System.Action onUpdateFunction = null, System.Action onExitFunction = null )
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

    }

    /*                                              Velocity Based?
           Character Movements States: Standing, (Might be the same)(Walking, Running)
           Character Disable States:   Helpless(falling: ie after up B)(can still move side to side), LedgeGrab, Disabled (when hit with high percent)(nothing works)
           Character Ability States:   Invincible(cant take dmg, everything available), UnMoveable(when using a move), AbilityLockOut(cant use anyothers when using a move), UnCollidable(dashing)
   */
    

    public enum States
    {
        /*MOVEMENT STATES*/ STANDING, WALKING, SPRINTING, JUMPING, CROUCHING, GROUNDED,
        /*DISABLE STATES*/  FLINCH, HELPLESS,  LEDGEGRAB, DISABLED,
        /*ABILITY STATES*/  INVINCIBLE, NOFLINCH, ABILITYLOCKOUT, NOCOLLISION, NOKNOCKBACK, HASITEM
    };

}