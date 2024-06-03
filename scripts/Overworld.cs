using Godot;
using System;

public partial class Overworld : Node2D
{
	Node2D gui;// = (Node2D) GetNode("Gui");
	Button lP;
	public int levelCounter;
	EnemySpawner es;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		levelCounter = 1;
		gui = (Node2D) GetNode("Gui");
		gui.Visible = true;
		lP = (Button)GetNode("Gui/LanguagePicker");
		GetTree().Paused = true;
		TranslationServer.SetLocale("en");
		es = (EnemySpawner)GetNode("EnemySpawner");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//GetTree().Paused = gui.Visible;
		 
		
		if (es.IsLevelComplete())
		{
			//es.StopSpawn();
			//dialogue.PlayEndLevel(levelCounter);
			levelCounter++;
			// wait for dialogue to finish
			// start next level dialogue
			//start next level
		}
	}
	
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("pause_menu"))
		{
			gui.Visible = true;
			GetTree().Paused = true;
		}
	}
	
	private void _on_new_game_button_pressed()
	{
		// Replace with function body.
		gui.Visible = false;
		GetTree().Paused = false;
	}


	private void _on_continue_button_pressed()
	{
		// Replace with function body.
		gui.Visible = false;
		GetTree().Paused = false;
	}


	private void _on_how_to_play_button_pressed()
	{
		// Replace with function body.
	}
		
	private void _on_quit_button_pressed()
	{
		// Replace with function body.
		GetTree().Quit();
	}
	
	private void _on_main_music_finished()
	{
		var mM = (AudioStreamPlayer) GetNode("MainMusic");
		mM.Playing = true;
	}
	
	private void _on_title_music_finished()
	{
		var tM = (AudioStreamPlayer) GetNode("Gui/TitleMusic");
		tM.Playing = true;
	}
	
	private void _on_language_picker_pressed()
	{
		if (TranslationServer.GetLocale() == "en")
		{
			TranslationServer.SetLocale("ja");
			lP.Text = "Japanese";
		}
		else
		{
			TranslationServer.SetLocale("en");
			lP.Text = "English";
		}
	}
}
