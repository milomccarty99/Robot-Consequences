using Godot;
using System;

public partial class Dialogue : Node2D
{
	private RichTextLabel tB; 
	private RichTextLabel introTB;
	private Timer dialogueCounter;
	private Sprite2D garciaPic;
	private Sprite2D steinbeckPic;
	private Sprite2D saviorPic;
	private String[] dKeys;
	private String[] introKeys;
	private char[] portraitDisplay;
	private int[] dLength;
	private int dCounter;
	private int introLength;
	private bool displayDialogue;
	//to-do
	// add methods for start and stop of level
	// looking for input to skip dialogue
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		tB = (RichTextLabel)GetNode("Textbox");
		introTB = (RichTextLabel)GetNode("IntroTextbox");
		dialogueCounter = (Timer)GetNode("DialogueCounter");
		garciaPic = (Sprite2D)GetNode("GarciaPic");
		steinbeckPic = (Sprite2D)GetNode("SteinbeckPic");
		saviorPic = (Sprite2D)GetNode("SaviorPic");
		dKeys = new String[]{"1a", "1b", "1c", "1d", "1d2", "1e", "1f", "1g", "1h",
		 "1i", "1j", "1k", "1l", "1m", "1n", "1o", "1p", "1q", "1r", "1s", 
		"1t", "2a", "2b", "2c", "2d", "2e", "2f", "2g", "2h", "2i",
		 "3a", "3a1", "3b", "3c", "3d", "3e", "3f", "3g", "3h", "3i", "3j", "3k", "3l"};
		introKeys = new String[]{"Intro1", "Intro2", "Intro3", "Intro4", "Intro5", "Intro6",
		 "Intro7", "Intro8", "Intro9"};
		dLength = new int[]{13, 8, 6, 3, 8, 5};
		introLength = 9;
		dCounter = -introLength;
		displayDialogue = true;
		
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (dCounter < 0)
		{
			String line = Tr(introKeys[dCounter + introLength]);
			introTB.Text = line;
		}
		if (displayDialogue && (dCounter < dKeys.Length) && dCounter >= 0)
		{
			introTB.Text = "";
			String line = Tr(dKeys[dCounter]);
			if (line.StartsWith("Savior"))
			{
				saviorPic.Visible = true;
			}
			else if(line.StartsWith("Dr. Steinbeck"))
			{
				steinbeckPic.Visible = true;
			}
			else if(line.StartsWith("Dr. Garcia"))
			{
				garciaPic.Visible = true;
			}
			
			tB.Text =  line;// + delta.ToString();
		}
		else 
		{
			
		}
		
	}
	
	public void DisplayLevelStart(int level)
	{
		int startKeyIndex = 0;
		for(int i = 0; i< level * 2; i++)
		{
			startKeyIndex += dLength[i];
		}
		
	}
	
	public void DisplayLevelEnd(int level)
	{
		
	}
	
	private void _on_dialogue_counter_timeout()
	{
		// Replace with function body.
		// the switch may be frame perfect, so we reset visibility here
		steinbeckPic.Visible = false;
		garciaPic.Visible = false;
		saviorPic.Visible = false;
		if (displayDialogue)
		{
			dCounter++;
		}
	}	
}



