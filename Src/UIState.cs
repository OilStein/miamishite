using Godot;

public partial class UIState : Node
{
	[Export]
	public GameState GameState;

	[Export]
	public Control GameRunning;
	[Export]
	public Control GameOver;
	[Export]
	public Control GameWon;
	[Export]
	public Control GameStarting;

	[Export]
	public TextureProgressBar ShiteProgressBar;

	[Export]
	public UIPortraitSwitcher PortraitSwitcher;

	public override void _Process(double delta)
	{
		ShiteProgressBar.Value = GameState.CurrentShite / GameState.MaxShite * 100f;
		PortraitSwitcher.ShiteChanged(GameState.CurrentShite);
	}

	public void _GameStatusChanged(int oldStatus, int newStatus)
	{
		OnGameStatusChanged((GameStatus)oldStatus, (GameStatus)newStatus);
	}

	private void OnGameStatusChanged(GameStatus oldStatus, GameStatus newStatus)
	{
		GameRunning.Visible = newStatus == GameStatus.Running;
		GameOver.Visible = newStatus == GameStatus.GameOver;
		GameWon.Visible = newStatus == GameStatus.Victory;
		GameStarting.Visible = newStatus == GameStatus.Starting;
	}
}
