using UnityEngine;
using System.Collections;
using StateMachine;

namespace Character
{

    public class CharacterAccessors : MonoBehaviour
    {
        CharacterStateMachine characterStateMachine;

        void Awake()
        {
            characterStateMachine = gameObject.GetComponent<CharacterStateMachine>();
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