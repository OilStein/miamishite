using Godot;

public partial class CharacterAnimations : AnimatedSprite2D
{
    public void MoveDirectionChanged(Vector2 moveDirection)
    {
        if (moveDirection == Vector2.Zero)
        {
            Play("idle");
        }
        else
        {
            Play("run");
        }
    }
}
