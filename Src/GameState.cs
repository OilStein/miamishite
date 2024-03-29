using System.Threading.Tasks;
using Godot;

public partial class GameState : Node
{
	[Signal]
	public delegate void GameStatusChangeEventHandler(GameStatus oldStatus, GameStatus newStatus);

	[Signal]
	public delegate void FartedEventHandler();

	[Export]
	public float MaxShite = 100;

	[Export]
	public float BaseBuildupSpeed = 2;

	public GameStatus GameStatus => gameStatus;
	private GameStatus gameStatus = GameStatus.Running;

	public float CurrentShite => shite;
	private float shite = 0;

	public override void _Ready()
	{
		SetGameStatus(GameStatus.Starting);
		var timer = new Timer
		{
			Name = "StartTimer",
			WaitTime = 2f,
			OneShot = true
		};
		AddChild(timer);
		timer.Timeout += StartGame;
		timer.Start();
	}

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

	private void StartGame()
	{
		SetGameStatus(GameStatus.Running);
	}

	private void SetGameStatus(GameStatus status)
	{
		var currentStatus = gameStatus;
		gameStatus = status;
		EmitSignal(SignalName.GameStatusChange, (int)currentStatus, (int)gameStatus);
	}

	private void Fart()
	{
		var rand = new System.Random();
		var didAddOrRemoveShite = rand.Next(0, 4);
		if (didAddOrRemoveShite < 1)
		{
			shite -= rand.Next(1, 20) + 10;
		}
		else
		{
			shite += rand.Next(1, 20) + 10;
		}
		if (shite < 0)
		{
			shite = 0;
		}
		EmitSignal(SignalName.Farted);
	}
}
