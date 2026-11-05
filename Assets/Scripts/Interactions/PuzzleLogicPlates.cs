using System.Collections.Generic;
using UnityEngine;

public class PuzzleLogicPlates : ActivatorBase
{
    // Se tienen que pillar las palancas
    // public ActivatorBase lever1;
    // public ActivatorBase lever2;
    // public ActivatorBase lever3;

    private bool solved = false;

    [System.Serializable]
    public class ActivatorPuzzleState
    {
        public ActivatorBase activator;
        public bool correctState = false;
    }

    public List<ActivatorPuzzleState> activators;

    void Start()
    {
        foreach (var activatorState in activators)
        {
            activatorState.activator.ToActivate.AddListener(ActivatorUpdated);
        }
    }

    private void ActivatorUpdated(ActivatorBase.ActivatorInfo info)
    {
        if (CheckIfPuzzleHasBeenSolved() || solved)
        {
            Debug.Log("Puzzle Solved!");
            ActivateObjects(true);
            solved = true;
        }
        else if (solved!)
        {
            Debug.Log("Puzzle not solved");
            ActivateObjects(false);
        }

    }
    private bool CheckIfPuzzleHasBeenSolved()
    {
        foreach (var activatorState in activators)
        {
            if (activatorState.activator.IsActivated != activatorState.correctState)
            {
                return false;
            }
        }
        return true;
    }
}