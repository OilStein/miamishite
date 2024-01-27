using Godot;

public partial class GameState : Node
{
	[Signal]
	public delegate void GameStatusChangeEventHandler(GameStatus oldStatus, GameStatus newStatus);

	[Export]
	public float MaxShite = 100;

	[Export]
	public float BaseBuildupSpeed = 2;

	public GameStatus GameStatus => gameStatus;
	private GameStatus gameStatus = GameStatus.Running;

	public float CurrentShite => shite;
	private float shite = 0;

	public override void _Process(double delta)
	{
		if (gameStatus != GameStatus.Running)
		{
			return;
		}

		shite += BaseBuildupSpeed * (float)delta;

		if (shite >= MaxShite)
		{
			SetGameStatus(GameStatus.GameOver);
		}
	}

	public void WinTriggerEntered()
	{
		SetGameStatus(GameStatus.Victory);
	}

	private void SetGameStatus(GameStatus status)
	{
		var currentStatus = gameStatus;
		gameStatus = status;
		EmitSignal(SignalName.GameStatusChange, (int)currentStatus, (int)gameStatus);
	}
}