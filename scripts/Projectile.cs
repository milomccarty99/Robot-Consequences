using Godot;
using System;

public partial class Projectile : Area2D
{
	[Export]
	public float speed = 100f;
	[Export]
	public Vector2 direction = Vector2.Right;
	private float stepCounter = 0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	public override void _PhysicsProcess(double delta)
	{
		// set path 
		//direction.Y = (float)Mathf.Sin((double)stepCounter);
		//direction.X = (float)Mathf.Cos((double)stepCounter);
		
		stepCounter+=.005f;
		//SetGlobalPosition( new Vector2(0f,100f));
		//Transform.position = new Vector2(0f, 0f);
		Position += direction * (float)(speed * delta); //* delta;
		//GD.Print(GlobalPosition.ToString());
		if (GlobalPosition.Y > 512 || GlobalPosition.X > 512 || GlobalPosition.X < 0 || GlobalPosition.Y < 0) 
		{
			QueueFree();
		}
		
		var bodies = GetOverlappingBodies();
		for (int i = 0; i < bodies.Count; i++)
		{
			if (bodies[i].Equals(GetNode("../../../../Player")))  // projectile in proj spawner
			{
				//GD.Print("bingo");
				((PlayerMovement)bodies[i]).ProjectileHit();
				//bodies[i].ProjectileHit();
				QueueFree();
			}
			else if (bodies[i].Equals(GetNode("../CharacterBody2D"))) // loose proj
			{
				
			}
			else
			{
				GD.Print(bodies[i].ToString());
			}
		}
	}
	
	/*private void _on_timer_timeout()
	{
		//QueueFree();
		GD.Print("timeout projectile");
	}*/
}



