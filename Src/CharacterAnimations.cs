using Godot;

public partial class CharacterAnimations : AnimatedSprite2D
{
    private GameStatus gameStatus = GameStatus.Starting;

    public void MoveDirectionChanged(Vector2 moveDirection)
    {
        if (gameStatus != GameStatus.Running)
        {
            return;
        }

        if (moveDirection == Vector2.Zero)
        {
            Play("idle");
        }
        else
        {
            Play("run");
        }
    }

    public void GameStatusChanged(GameStatus oldState, GameStatus newState)
    {
        gameStatus = newState;
        if (gameStatus == GameStatus.GameOver)
        {
            Play("death");
        }
        else
        {
            Play("idle");
        }
    }
}
