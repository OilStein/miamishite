using Godot;
using System;

public partial class BGAudio : Node
{
	private AudioStreamPlayer backgroundMusic;
	private AudioStreamPlayer officeAmbience;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		backgroundMusic = GetNode<AudioStreamPlayer>("BackgroundMusic");
		backgroundMusic.VolumeDb = -10f;
		officeAmbience = GetNode<AudioStreamPlayer>("OfficeAmbience");
		officeAmbience.VolumeDb = -15f;

		PlayTrack(true);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void PlayTrack(bool play)
	{
		if (play)
		{
			backgroundMusic.Play();
			officeAmbience.Play();
		}
		else
		{
			backgroundMusic.Stop();
			officeAmbience.Stop();
		}
	}
}
