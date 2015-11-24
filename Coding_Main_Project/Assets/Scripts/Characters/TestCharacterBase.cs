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
		stateMachine = characterAccessor.StateMachine;
	}
	
	
	void Update ()
	{
		
	}
}
