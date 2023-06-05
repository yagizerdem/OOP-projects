using System.Security.Cryptography.X509Certificates;

namespace Deneme2
{
	internal class Program
	{
		int Height = 20;
		int Width = 30;

		int fruitX = 5, fruitY=20, parts = 3;
		Random rnd = new Random();

		int[] X = new int[50];
		int[] Y = new int[50];

		bool flag = false;

		ConsoleKeyInfo keyinfo = new();
		string key = "";
		public void WriteBoard()
		{
			Console.Clear();
			for (int i = 1; i <= (Width + 2); i++)
			{
				Console.SetCursorPosition(i, 0);
				Console.Write("-");
			}
			for (int i = 1; i <= (Width + 2); i++)
			{
				Console.SetCursorPosition(i, (Height + 2));
				Console.Write("-");
			}
			for (int i = 1; i <= (Height + 1); i++)
			{
				Console.SetCursorPosition(1, i);
				Console.Write("|");
			}
			for (int i = 1; i <= (Height + 1); i++)
			{
				Console.SetCursorPosition((Width + 2), i);
				Console.Write("|");
			}
			CreateSnake(X, Y);
			PositionFruit();
		}
		public void Input()
		{
			keyinfo = Console.ReadKey();
			key = keyinfo.Key.ToString().ToLower();
		}
		public void Logic()
		{
		

			if(key != null)
			{
				int tempx = 0, tempy = 0 , tempx2 = 0, tempy2 =0;
				for (int i = 0; i < parts; i++)
				{

					if (i==0)
					{
						tempx = X[i + 1];
						tempy = Y[i + 1];
						X[i + 1] = X[i];
						Y[i + 1] = Y[i];
					}
					else
					{
						tempx2 = X[i+1];
						tempy2 = Y[i+1];
						X[i + 1] = (int)tempx;
						Y[i + 1] =(int)tempy;
						tempx = tempx2;
						tempy = tempy2;
					}
				
				}
			}
			switch (key) 
			{
				case "w":
					if (Y[0] != 1)
					{
						Y[0]--;
					}
					break;
				case "a":
					if(X[0] != 2)
					{
						X[0]--;

					}
					break;
				case "s":
					if (Y[0] != 21)
					{
						Y[0]++;
					}
					break;
				case "d":
					if (X[0] != 31)
					{
						X[0]++;
					}
					break;
			}
			key = "";
			if (X[0] == fruitX && Y[0] == fruitY)
			{
				parts++;
				flag = true;
			}
		}
		public void CreateSnake(int[] x , int[] y)
		{
			for (int i = 0; i < x.Length; i++)
			{
				Console.SetCursorPosition(X[i], Y[i]);
				Console.Write("#");
			}
		}
		public void PositionFruit()
		{
			if (flag)
			{
			int positionx = 0 , positiony =0;
			do
			{
					positionx = rnd.Next(4, Width);
					positiony = rnd.Next(4, Height);
					fruitX = positionx;
					fruitY = positiony;
					flag =false;
			} while (X.Contains(positionx)&&Y.Contains(positiony));
			}
			Console.SetCursorPosition(fruitX, fruitY);
			Console.Write("#");
			Console.SetCursorPosition(0,0);
		}
		static void Main(string[] args)
		{
			Program program = new Program();
			program.X[0] = 10;
			program.Y[0] = 10;
			program.X[1] = 10;
			program.Y[1] = 11;
			program.X[2] = 10;
			program.Y[2] = 12;
			program.CreateSnake(program.X, program.Y);
			Console.CursorVisible = false;
			while (program.parts<=20)
			{
				program.WriteBoard();
				program.Input();
				program.Logic();
				program.CreateSnake(program.X, program.Y);
				program.PositionFruit();
				Thread.Sleep(100);
			}
			Console.Clear();
			Thread.Sleep(2000);
			Console.WriteLine("tebrikler oyunu bitirdiniz");
			Console.ReadKey();
			Console.Clear();
			Console.Write(@"
		*   *			*			******      *     ******* 
		 * *		   * *			*	 		*		   *		
		  *			  *	  *			*  ***		*         *
		  *			 *******        *    *		*        * 
	      *		    * 		*	    ******		*       ******* 
");


		}
	}
}