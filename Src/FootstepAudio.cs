using Godot;

public partial class FootstepAudio : AudioStreamPlayer
{
    [Export]
    public AudioStream RightFootstep;
    [Export]
    public AudioStream LeftFootstep;

    [Export]
    public float Interval = 1f;

    private Vector2 moveDir = Vector2.Zero;

    private float counter = 0;

    private bool leftNext = false;

    public void MoveDirectionChanged(Vector2 moveDirection)
    {
        moveDir = moveDirection;
    }

    public override void _Process(double delta)
    {
        if (moveDir == Vector2.Zero)
        {
            counter = Interval;
            return;
        }

        counter += (float)delta;

        if (counter >= Interval)
        {
            if (leftNext)
            {
                Stop();
                Stream = LeftFootstep;
                Play();
            }
            else
            {
                Stop();
                Stream = RightFootstep;
                Play();
            }

            counter = 0;
            leftNext = !leftNext;
        }
    }
}
