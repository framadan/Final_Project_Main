﻿using UnityEngine;
using System.Collections;
using StateMachine;

namespace Character
{

    public class CharacterAccessors : MonoBehaviour
    {
        CharacterStateMachine characterStateMachine;

        void Awake()
        {
            characterStateMachine = new CharacterStateMachine();
        }

        //might not need
        public CharacterStateMachine States
        {
            get
            {
                return characterStateMachine;
            }
        }

    }
}