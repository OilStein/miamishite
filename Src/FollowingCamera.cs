using Godot;

public partial class FollowingCamera : Camera2D
{
	[Export]
	public Node2D Target;

	[Export]
	public float MovementSpeed = 10f;

	public override void _Process(double delta)
	{
		Position = Position.MoveToward(Target.Position, MovementSpeed);
	}
}
