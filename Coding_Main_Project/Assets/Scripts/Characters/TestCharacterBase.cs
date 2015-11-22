using UnityEngine;
using System.Collections;
using StateMachine;
using Character;

public class TestCharacterBase : MonoBehaviour
{
    CharacterAccessors characterAccessor;
    CharacterStateMachine stateMachine;

    void Awake()
    {
        characterAccessor = gameObject.GetComponent<CharacterAccessors>();
        
    }

    
    void Start ()
    {
        stateMachine = characterAccessor.States;
        stateMachine.AddState(States.test1, ()=> Debug.Log("called Callback Function"));
        stateMachine.DebugActiveStates();
        //stateMachine.RemoveState(States.test1);

	}
	
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.A))
            stateMachine.AddState(States.test2);
	}
}
