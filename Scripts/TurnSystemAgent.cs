using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnSystemAgent : MonoBehaviour {

    public UnityEvent activeTarget;
    private TurnSystem turnSystem;

    // Use this for initialization
    void Start ()
    {
        turnSystem = FindObjectOfType<TurnSystem>();

        if (turnSystem == null)
        {
            Debug.LogError("No TurnSystem object could be found.");
        }
        else
        {
            NotifySystem();

            turnSystem.onNextMove += ActiveTarget;
        }
	}

    private void OnDisable()
    {
        
    }

    /// <summary>
    /// This method will add this gameobject to TurnSystem
    /// </summary>
    private void NotifySystem()
    {
        turnSystem.AddToSystem(transform.gameObject);
    }

    /// <summary>
    /// Should notify gameObject with this script when TurnSystem...
    /// </summary>
    /// <param name="gameObject"></param>
    private void ActiveTarget(GameObject gameObject)
    {
        if (gameObject == transform.gameObject)
        {
            activeTarget.Invoke();
        }
    }

    /// <summary>
    /// Should be called when player make a move
    /// </summary>
    public void Done()
    {
        turnSystem.MoveDone(transform.gameObject);
    }
}
