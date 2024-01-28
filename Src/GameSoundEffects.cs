using Godot;

public partial class GameSoundEffects : AudioStreamPlayer
{
	[Export]
	public AudioStream VictorySound;
	[Export]
	public AudioStream FailureSound;

	public void GameStatusChanged(GameStatus oldStatus, GameStatus newStatus)
	{
		Stop();
		var sound = SoundToPlay(newStatus);
		if (sound != null)
		{
			Stream = sound;
			Play();
		}
	}

	private AudioStream SoundToPlay(GameStatus status)
	{
		switch (status)
		{
			case GameStatus.Victory:
				return VictorySound;
			case GameStatus.GameOver:
				return FailureSound;
			default:
				return null;
		}
	}
}
