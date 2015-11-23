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
        stateMachine.AddState(States.test1, null, 5f);
        //stateMachine.ActiveStates.Add(States.test2);
        stateMachine.DebugActiveStates();
        

	}

    public void TestCallbackFunction()
    {
        Debug.Log("Called Debug");
    }
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.A))
            stateMachine.RemoveState(States.test1);
    }
}
