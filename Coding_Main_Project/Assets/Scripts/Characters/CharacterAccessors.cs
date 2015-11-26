using UnityEngine;
using System.Collections;
using StateMachine;
using HelperFunctions;

namespace Character
{

    public class CharacterAccessors : MonoBehaviour
    {
        CharacterStateMachine characterStateMachine;

        void Awake()
        {
            characterStateMachine = gameObject.GetComponent<CharacterStateMachine>();
            Vector3 s = new Vector3();
            if(s.Aprox(.1f)) { }
            
        }

        
        //might not need
        public CharacterStateMachine StateMachine
        {
            get
            {
                return characterStateMachine;
            }
        }

    }
}