using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public enum GameState
    {
        Hub,
        Play,
        Items,
        Tools,
        Salon
    }

    public class GameFlow : MonoBehaviour
    {
        private void Awake()
        {
            mStateMachine = new StateMachine<GameState>(
                (GameState.Play, GetComponent<GameplayState>()),
                (GameState.Hub, GetComponent<HubState>()),
                (GameState.Items, GetComponent<ItemsState>()),
                (GameState.Salon, GetComponent<SalonState>())
            );
        }

        private void Start()
        {
            if (Progress.Instance.CurrentLevel == 1)
                mStateMachine.SwitchState(GameState.Play);
            else
                mStateMachine.SwitchState(GameState.Hub);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
                mStateMachine.GetCurrentState()?.OnBackButtonPressed();
        }

        // Only meant to be called by GameFlow's states
        public void _SwitchState(GameState gameState)
        {
            mStateMachine.SwitchState(gameState);
        }

        private StateMachine<GameState> mStateMachine;
    }
}
