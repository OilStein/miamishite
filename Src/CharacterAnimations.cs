using Godot;

public partial class CharacterAnimations : AnimatedSprite2D
{
    [Export]
    public CharacterMovement CharacterMovement;

    public override void _Process(double delta)
    {
        if (CharacterMovement.MoveDirection == Vector2.Zero)
        {
            Play("run");
        }
        else
        {
            Play("run");
        }
    }
}
