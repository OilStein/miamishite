using System;
using Godot;

public partial class GodScene : Node
{
    [Export]
    public PackedScene Main;

    private GameState gameState;

    public override void _Ready()
    {
        Start();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("reload")
            && (gameState.GameStatus == GameStatus.GameOver || gameState.GameStatus == GameStatus.Victory))
        {
            RemoveChild(gameState);
            gameState.QueueFree();
            Start();
        }
    }

    private void Start()
    {
        gameState = Main.Instantiate<GameState>();
        AddChild(gameState);
    }
}
