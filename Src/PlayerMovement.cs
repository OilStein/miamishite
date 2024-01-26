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
        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        characterMovement.MoveDirection = direction;
    }
}
