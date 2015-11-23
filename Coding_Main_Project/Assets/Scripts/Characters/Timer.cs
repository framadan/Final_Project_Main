using UnityEngine;
using System.Collections;
using code.TimeManager;
using System.Collections.Generic;
using StateMachine;

public class Timer
{
    public event System.Action timerStarted;
    public event System.Action timerUpdate;
    public event System.Action timerCompleted;

    private States state;
    private CharacterStateMachine stateMachine;

    private bool running;
    public bool Running { get { return running;} }

    private bool paused;
    public bool Paused { get { return paused;} }

    private float targetTime;
    public float TargetTime {get{return targetTime;} set {targetTime = value;} }

    private float currentTime;
    public float CurrentTime{ get { return currentTime;} }

    public float TimeRemaining {get{return targetTime - currentTime;}}

    public bool timerWasKilled;

    public Timer( float targetTime, CharacterStateMachine stateMachine, States state)
    {
        if(targetTime == 0)
            targetTime = 180;
        this.targetTime = targetTime;
        this.stateMachine = stateMachine;
        this.state = state;
        StartTimer();
    }

    public void StartTimer()
    {
        running = true;
        TimeManager.instance.StartCoroutine(MainCoroutineTimer());
    }

    public void ResetTimer( float targetTime )
    {
        currentTime = 0;
        this.targetTime = targetTime;
    }

    public static void RemoveState( CharacterStateMachine stateMachine, States state )
    {
        stateMachine.RemoveState(state);
    }

    public void Pause()
    {
        paused = true;
    }

    public void UnPause()
    {
        paused = false;
    }

    public void kill()
    {
        timerWasKilled = true;
        running = false;
        paused = false;
    }

    private IEnumerator MainCoroutineTimer()
    {
        
        yield return null;

        if(timerStarted != null)
            timerStarted();

        while(running)
        {
            if(paused)
            {
                yield return null;
            }
            else
            {
                if(timerUpdate != null)
                    timerUpdate();
                currentTime += Time.deltaTime;
                if(currentTime >= targetTime)
                    running = false;
                yield return null;
            }
        }

        if(timerCompleted != null)
            timerCompleted();
        RemoveState(stateMachine, state);
    }


}
