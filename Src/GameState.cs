using Godot;

public partial class GameState : Node
{
	[Signal]
	public delegate void GameStatusChangeEventHandler(int oldStatus, int newStatus);

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
			var currentStatus = gameStatus;
			gameStatus = GameStatus.GameOver;
			EmitSignal(SignalName.GameStatusChange, (int)currentStatus, (int)gameStatus);
		}
	}
}
