using Godot;

public partial class PlayerMovement : Node, CharacterController
{
    public CharacterMovement.ChangeMoveDirectionCall ChangeMoveDirection { get; set; }

    private bool enabled = true;

    public override void _Process(double delta)
    {
        if (!enabled)
        {
            return;
        }

        Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        ChangeMoveDirection?.Invoke(direction);
    }

    public void OnGameStatusChanged(GameStatus oldStatus, GameStatus newStatus)
    {
        enabled = newStatus == GameStatus.Running;
        if (!enabled)
        {
            ChangeMoveDirection?.Invoke(Vector2.Zero);
        }
    }
}
