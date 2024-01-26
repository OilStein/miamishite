using Godot;

public partial class PlayerMovement : Node
{
    private CharacterMovement characterMovement;

    public override void _Ready()
    {
        characterMovement = GetParent<CharacterMovement>();
    }

    public override void _Process(double delta)
    {
        Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        characterMovement.MoveDirection = direction;
    }
}
