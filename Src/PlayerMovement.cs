using Godot;

public partial class PlayerMovement : Node
{
    private CharacterMovement characterMovement;

    private bool enabled = true;

    public override void _Ready()
    {
        characterMovement = GetParent<CharacterMovement>();
    }

    public override void _Process(double delta)
    {
        if (!enabled)
        {
            return;
        }

        Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        characterMovement.MoveDirection = direction;
    }

    public void OnGameStatusChanged(GameStatus oldStatus, GameStatus newStatus)
    {
        enabled = newStatus == GameStatus.Running;
        if (!enabled)
        {
            characterMovement.MoveDirection = Vector2.Zero;
        }
    }
}
