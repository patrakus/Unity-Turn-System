using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    private Dictionary<int, GameObject> charactersOnSceneDictionary;
    private int turnCounter;
    private List<KeyValuePair<int, GameObject>> turnQueue;
    private int characterID;

    private GameObject currentActiveCharacter;

    public delegate void OnNextMove(GameObject gameObject);
    public event OnNextMove onNextMove;
    
    //TODO: check how works sorted list

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        NextMove();
	}

    public void AddToSystem(GameObject gameObject)
    {
        if (!charactersOnSceneDictionary.ContainsValue(gameObject))
        {
            charactersOnSceneDictionary.Add(characterID, gameObject);
            characterID++;
        }
        else
        {
            Debug.LogError("This " + gameObject.ToString() + " is already in system. Check if TurnSystemAgent isn't duplicated for this GameObject");
        }
    }

    public void RemoveFromSystem(GameObject gameObject)
    {
        if (charactersOnSceneDictionary.ContainsValue(gameObject))
        {
            
        }

        throw new NotImplementedException();
    }

    /// <summary>
    /// Zastosować tutaj może sortowanie dla tej metody?
    /// przetestować
    /// </summary>
    private void prepareNextTurn()
    {
        foreach (var character in charactersOnSceneDictionary)
        {
            turnQueue.Add(character);
        }

        SortTurnQueueBySpeed();

        throw new NotImplementedException();
    }

    private void NextMove()
    {
        if (turnQueue.Count != 0)
        {
            if (currentActiveCharacter == null)
            {
                currentActiveCharacter = turnQueue[0].Value;

                onNextMove(currentActiveCharacter);
            }
        }
        else
        {
            prepareNextTurn();
            turnCounter++;
        }

        throw new NotImplementedException();
    }

    //TODO: poprawic ten kod tutaj bo jest brzydki
    public void MoveDone(GameObject gameObject)
    {
        IsThisCurrentActiveObject(gameObject);

        currentActiveCharacter = null;

        turnQueue.RemoveAt(0);

        if (turnQueue.Count == 0)
        {
            prepareNextTurn();
            turnCounter++;

        }

        throw new NotImplementedException();
    }

    private void IsThisCurrentActiveObject(GameObject gameObject)
    {
        if (currentActiveCharacter != gameObject)
        {
            Debug.LogError(gameObject.ToString() + "is not a object which have turn now.");
        }
    }

    private void SortTurnQueueBySpeed()
    {
        throw new NotImplementedException();
    }
}
