using Godot;
using System;

public partial class EnemySpawner : Node2D
{
	PackedScene tEScene = GD.Load<PackedScene>("res://scenes/turret_enemy.tscn");
	PackedScene fBScene = GD.Load<PackedScene>("res://scenes/flying_boss.tscn");
	[Export]
	PackedScene spiderScene = GD.Load<PackedScene>("res://scenes/spider_enemy.tscn");
	[Export]
	PackedScene flyingBossScene = GD.Load<PackedScene>("res://scenes/flying_enemy.tscn");
	[Export]
	PackedScene spiderBossScene = GD.Load<PackedScene>("res://scenes/spider_boss_enemy.tscn");
	bool spawnEnemies = true;
	[Export]
	public int spawnRemaining = 60;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _on_wave_timer_timeout()
	{
		if (GetChildCount() < 5 && spawnEnemies)
		{
			var world = GetTree().CurrentScene;
			var inst = (TurretEnemy)tEScene.Instantiate();
			AddChild(inst);
			inst.GlobalPosition = new Vector2(255f,20f);
			var inst2 = (TurretEnemy)tEScene.Instantiate();
			AddChild(inst2);
			inst2.GlobalPosition = new Vector2(450f,30f);
			// Replace with function body.
			spawnRemaining -= 2;
		}
	}
	
	private void _on_spider_wave_timer_timeout()
	{
		float[] spawnX = {56f, 72f, 93f, 169f, 245f, 341f, 412f, 453f, 445f, 255f};
		float[] spawnY = {408f, 300f, 204f, 137f, 130f, 133f, 170f, 249f, 346f, 241f};
		for (int i = 0; i < 10; i++)
		{
			var world = GetTree().CurrentScene;
			var inst = (Enemy)spiderScene.Instantiate();
			inst.GlobalPosition = new Vector2(spawnX[i], spawnY[i]);
			AddChild(inst);
		}
		// Replace with function body.
	}


	private void _on_flying_boss_timer_timeout()
	{
		// Replace with function body.
		var world = GetTree().CurrentScene;
		var inst = (Enemy)flyingBossScene.Instantiate();
		//inst.GlobalPosition = new Vector2(spawnX[i], spawnY[i]);
		AddChild(inst);
	}


	private void _on_spider_boss_timer_timeout()
	{
		// Replace with function body.
		var world = GetTree().CurrentScene;
		var inst = (Enemy)spiderBossScene.Instantiate();
		//inst.GlobalPosition = new Vector2(spawnX[i], spawnY[i]);
		AddChild(inst);
	}
	
	public bool IsLevelComplete()
	{
		return (GetChildCount() <= 1) && spawnRemaining <= 0;  // this is a quick fix for counting number of enemies.
	}
	
	public void StopSpawn()
	{
		spawnEnemies = false;
	}
	
	public void StartSpawn()
	{
		spawnEnemies = true;
	}
	
}






