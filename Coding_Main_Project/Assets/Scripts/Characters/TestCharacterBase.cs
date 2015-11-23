using UnityEngine;
using System.Collections;
using StateMachine;
using Character;
using System.Collections.Generic;
using System.Linq;

public class TestCharacterBase : MonoBehaviour
{
    CharacterAccessors characterAccessor;
    CharacterStateMachine stateMachine;
    public States[] movementStates = new States[] { States.STANDING, States.WALKING, States.SPRINTING };

    void Awake()
    {
        characterAccessor = gameObject.GetComponent<CharacterAccessors>();
        stateMachine = characterAccessor.StateMachine;
    }

    
    void Start ()
    {
        stateMachine.AddState(States.STANDING, 5f, ()=> Debug.Log("started state"), () => Debug.Log("updating state"), ()=> Debug.Log("Leaving State"));
        stateMachine.AddState(States.WALKING, 5f, () => Debug.Log("started w"), () => Debug.Log("updating w"), () => Debug.Log("Leaving w"));
    }

    public void TestCallbackFunction()
    {
        Debug.Log("Called Debug");
    }
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.A))
            stateMachine.AddState(States.SPRINTING, 0, () => stateMachine.RemoveSimilarStates(movementStates , States.SPRINTING), () => Debug.Log("in runstate update"), null);
    }

    
}
