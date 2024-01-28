using Godot;
using System;

public partial class Fart : AudioStreamPlayer
{
	[Export]
	public AudioStream[] fartSounds;

  


    public override void _Ready()
    {
        
    }

    public void PlayFart()
    {
        var random = new Random();
        var sound = fartSounds[random.Next(0, fartSounds.Length)];
        Stream = sound;
        Play();
    }
	
	
}
