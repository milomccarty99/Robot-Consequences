using Godot;
using System;

public partial class Enemy : Area2D
{
	[Export]
	public float health = 100f;
	[Export]
	public ProjectileSpawner pSpawner;
	[Export]
	public float speed = .5f;
	[Export]
	public String eType = "turret";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		pSpawner = (ProjectileSpawner) GetNode("ProjectileSpawner");
		((AnimatedSprite2D)GetNode("AnimatedSprite2D")).Play();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (eType == "spider" || eType == "spiderboss")
		{
			StepTowardsPosition(delta, ((PlayerMovement)GetNode("../../Player")).GlobalPosition);
			var playerBody = (PlayerMovement)GetNode("../../Player");
			if (OverlapsBody(playerBody))
			{
			
				playerBody.TouchDamage();
			}
		}
		else if (eType == "flying")
		{
			
		}
	}
	
	
	
	public void CheckDeathCondition()
	{
		if (health <= 0f)
		{
			QueueFree();
		}
	}
	
	public void TakeDamage()
	{
		health -= 50;
		CheckDeathCondition();
	}
	
	public void StepTowardsPosition(double delta, Vector2 target)
	{
		float xMov = -GlobalPosition.X + target.X;
		float yMov = -GlobalPosition.Y + target.Y;
		GlobalPosition = new Vector2 (GlobalPosition.X + xMov * speed * (float)delta,GlobalPosition.Y + yMov * speed * (float)delta);
		
	}
	
}
