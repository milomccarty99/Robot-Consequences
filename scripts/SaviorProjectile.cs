using Godot;
using System;

public partial class SaviorProjectile : Area2D
{
	[Export]
	public float speed = 350f;
	public Vector2 direction = Vector2.Up;
	
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
		
		
		// update position
		Vector2 pos = GlobalPosition;
		pos.Y = pos.Y + direction.Y * speed * (float)delta;
		pos.X = pos.X + direction.X * speed * (float)delta;
		GlobalPosition = pos;
		
		if (GlobalPosition.X < 0f || GlobalPosition.X > 512f || GlobalPosition.Y < 0f || GlobalPosition.Y > 512f)
		{
			QueueFree();
		}
	}
	
	public void _on_area_entered(Area2D area)
	{
		//area.GlobalPosition = new Vector2(255f,255f);
		//GD.Print(area.GetType());
		String enemyType = area.GetType().ToString();
		if (enemyType == "Enemy")
		{
			//((TurretEnemy)area).TakeDamage();
			((Enemy)area).TakeDamage();
		}
		if (enemyType == "TurretEnemy")
		{
			((TurretEnemy)area).TakeDamage();
		}
		
		// Replace with function body.
		//area.QueueFree();
		//QueueFree();
	}
}



