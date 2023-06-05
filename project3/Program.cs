using System.Security.Cryptography.X509Certificates;

namespace HangedMan
{
	internal class HangedMan
	{
		static void UI(int stage)
		{
			
			if(stage == 0)
			{
				Console.SetCursorPosition(5, 20);
				Console.Write("******");
			}
			else if(stage == 1)
			{		
				for (int i = 0; i < 6; i++)
				{
					Console.SetCursorPosition(7, 14+i);
					Console.WriteLine("*");
				}
				Console.SetCursorPosition(5, 20);
				Console.Write("******");
			}
			else if (stage == 2)
			{
				Console.SetCursorPosition(7, 13);
				Console.Write("*************");
				for (int i = 0; i < 6; i++)
				{
					Console.SetCursorPosition(7, 14 + i);
						if(i<2)
						Console.WriteLine("*           *");
						else Console.WriteLine("*");
				}
				Console.SetCursorPosition(5, 20);
				Console.Write("******");
			}
			else if (stage == 3)
			{
				Console.SetCursorPosition(7, 13);
				Console.Write("*************");
				for (int i = 0; i < 6; i++)
				{
					Console.SetCursorPosition(7, 14 + i);
					if (i < 2)
						Console.WriteLine("*           *");
					else
					{
						if(i<4)
							Console.WriteLine("*          ***");
						else Console.WriteLine("*");
					}
				}
				Console.SetCursorPosition(5, 20);
				Console.Write("******");
			}
			else if (stage == 4)
			{
				Console.SetCursorPosition(7, 13);
				Console.Write("*************");
				for (int i = 0; i < 6; i++)
				{
					Console.SetCursorPosition(7, 14 + i);
					if (i < 2)
						Console.WriteLine("*           *");
					else
					{
						if (i < 4)
							Console.WriteLine("*          ***");
						else Console.WriteLine("*           *");
					}
				}
				for (int i = 0; i < 6; i++)
				{
					Console.WriteLine("                   *");
				}
				Console.SetCursorPosition(5, 20);
				Console.Write("******");
			}
			else if (stage == 5)
			{
				Console.SetCursorPosition(7, 13);
				Console.Write("*************");
				for (int i = 0; i < 6; i++)
				{
					Console.SetCursorPosition(7, 14 + i);
					if (i < 2)
						Console.WriteLine("*           *");
					else
					{
						if (i < 4)
							Console.WriteLine("*          ***");
						else Console.WriteLine("*           *");
					}
				}

				Console.WriteLine("                  ***");
				Console.WriteLine("                 * * *");
				Console.WriteLine("                *  *  *");
				Console.WriteLine("               *   *   *");
				Console.WriteLine("                   *");
				Console.WriteLine("                   *");
				Console.SetCursorPosition(5, 20);
				Console.Write("******");
			}
			else if (stage == 6)
			{
				Console.SetCursorPosition(7, 13);
				Console.Write("*************");
				for (int i = 0; i < 6; i++)
				{
					Console.SetCursorPosition(7, 14 + i);
					if (i < 2)
						Console.WriteLine("*           *");
					else
					{
						if (i < 4)
							Console.WriteLine("*          ***");
						else Console.WriteLine("*           *");
					}
				}

				Console.WriteLine("                  ***");
				Console.WriteLine("                 * * *");
				Console.WriteLine("                *  *  *");
				Console.WriteLine("               *   *   *");
				Console.WriteLine("                   *");
				Console.WriteLine("                  ***");
				Console.WriteLine("                 * * *");
				Console.WriteLine("                *  *  *");
				Console.WriteLine("               *   *   *");
				Console.SetCursorPosition(5, 20);
				Console.Write("******");
			}
		}
		static void Main(string[] args)
		{
			string[] questins = new string[5] { "ankara", "tokyo", "paris", "moskova", "berlin" };
			List<string> knownLetters = new List<string>() { },unkownLetters = new List<string>();
			bool flag = false;
			int counter = 0 ;
			Random rand = new Random();
			string question = "";
			while (!flag)
			{
				//UI
					HangedMan.UI(counter);	
				//end
				Console.SetCursorPosition(20, 3);
				Console.WriteLine($"healt = {6-counter}");
				if (question == "")
				{
					int random = rand.Next(0, questins.Length);
					question = questins[random];
				}

				Console.SetCursorPosition(3, 5);
				for(int i = 0; i<question.Length; i++)
				{
					if (knownLetters.Contains(question[i].ToString()))
					{
						Console.Write(question[i]+" ");
					}
					else
					{
						Console.Write("_ ");
					}
				}
				Console.SetCursorPosition(20, 5);
				Console.Write("known letters");
				Console.SetCursorPosition(20, 6);
				foreach (var item in knownLetters)
				{
					Console.Write(item.ToString()+" ");
				}
				Console.SetCursorPosition(20, 7);
				Console.Write("unkownLetters letters");
				Console.SetCursorPosition(20, 8);
				foreach (var item in unkownLetters)
				{

						Console.Write(item.ToString() + " ");
				}

				Console.WriteLine("\n enter a letter");
				string letter = Console.ReadLine();
				if(letter.Length > 1)
				{
					Console.ForegroundColor= ConsoleColor.Red;
					Console.WriteLine("enter a valid letter");
					Console.ForegroundColor = ConsoleColor.White;
					Thread.Sleep(2000);
					Console.Clear();
					continue;
				}
				if (question.Contains(letter))
				{
					if (!knownLetters.Contains(letter))
						knownLetters.Add(letter);
				}
				else
				{
					if (!unkownLetters.Contains(letter))
						unkownLetters.Add(letter);
					counter++;
				}

				if (counter > 5)
				{
					//display last stage of UI
					HangedMan.UI(6);
					//
					Console.SetCursorPosition(28, 3);
					Console.WriteLine("0");
					Console.SetCursorPosition(28, 10);
					Console.WriteLine("you lose ,  to try again enter 1 , to quit enter 2");
					int a = Convert.ToInt32(Console.ReadLine());
					if (a == 1)
					{
						counter = 0;
						question = "";
						knownLetters = new List<string>();
						unkownLetters = new List<string>();
						Console.Clear();
						continue;
					}
					else
						flag = true;
				}
				if (knownLetters.Count() == question.Distinct().Count())
				{
					Console.Clear();
					Thread.Sleep(1000);
					Console.ForegroundColor=ConsoleColor.Blue;
					Console.WriteLine("you win to try again enter 1 , to quit enter 2");
					Console.ForegroundColor = ConsoleColor.White;

					int a = Convert.ToInt32(Console.ReadLine());
					if (a == 1)
					{
						counter = 0;
						question = "";
						knownLetters = new List<string>();
						unkownLetters = new List<string>();
					}
					else
						flag = true;
				}
				Console.Clear();


				// en of while loop
			}
		}
	}
}