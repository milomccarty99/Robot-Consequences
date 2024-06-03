using Godot;
using System;

public partial class ProjectileSpawner : Node2D
{
	// to-do: 
	// arc length, direction, number of bullets
	// variable paths based off sin, cos, line
	[Export]
	public float spawnWait = 3.0f;
	[Export]
	public float directionSpawn = 0f;
	[Export]
	public float shotArc = 360f;
	[Export]
	public int numShots = 1;
	// find a way to evenly distribute
	public Timer hBeat;
	//public float emitRate = 2f; // 2 bullets every second
	//public Timer heartbeat = $Heartbeat;
	
	PackedScene projectileScene = GD.Load<PackedScene>("res://scenes/projectile.tscn");
	// pooling projectiles: keep them off screen
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		hBeat = (Timer)GetNode("Heartbeat");
		hBeat.WaitTime = spawnWait;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	public override void _PhysicsProcess(double delta)
	{
		
	}
	
	/*public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent)
		{
			var instance = projectileScene.Instantiate();
			//instance.direction = directionSpawn;
			instance.Set("direction", Vector2.Right);
			AddChild(instance);
		}
	} */
	private void _on_heartbeat_timeout()
	{
		float angleDiff = shotArc/(float)numShots;
		//GD.Print(angleDiff.ToString());
		for(int i =0; i < numShots; i++)
		{
			var instance = projectileScene.Instantiate();
			instance.Set("direction", (new Vector2(Mathf.Cos((i * angleDiff + directionSpawn)*Mathf.Pi/180f),Mathf.Sin((i * angleDiff + directionSpawn)*Mathf.Pi/180f))));
			AddChild(instance);
			
		}
		//Child(instance);
		
	}
	
}



