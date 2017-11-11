using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter.States
{
	public enum GameStateType
	{
		Error = -1,
		MainMenu = 0,
		Level1 = 1,
		Level2 = 2,
		GameOver = 3
	}

	public abstract class GameStateBase
	{
		public abstract string SceneName { get; }
		public abstract GameStateType StateType { get; }

		private List<GameStateType> _validTargetStates = new List<GameStateType>();

		public bool AddTargetState( GameStateType targetStateType )
		{
			bool result = false;

			if( !_validTargetStates.Contains(targetStateType) &&
				targetStateType != GameStateType.Error )
			{
				_validTargetStates.Add(targetStateType);
				result = true;
			}

			return result;
		}

		public bool RemoveTargetState(GameStateType targetStateType)
		{
			return _validTargetStates.Remove(targetStateType);
		}

		public bool IsValidTargetState( GameStateType targetStateType )
		{
			return _validTargetStates.Contains(targetStateType);
		}

		public virtual void Activate()
		{
			if( SceneManager.GetActiveScene().name != SceneName )
			{
				SceneManager.LoadScene(SceneName);
			}
		}

		public virtual void Deactivate()
		{
		}
	}
}
