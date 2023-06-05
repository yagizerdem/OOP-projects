using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace MineField
{
	internal class MineField
	{
		static void CreateMap()
		{
			// x = 13 (1,13) , y = 8 (1,8) 
			for (int i = 1; i <= 10; i++)
			{
				for (int j = 1; j <= 15; j++)
				{
					if(i==1 || i == 10)
					{
						Console.Write("-");
						continue;
					}
					else
					{
						if(j==1 || j == 15)
							Console.Write("|");
						else
							Console.Write(".");
					}
				}
				Console.Write("\n");
			}
		}
		static int[,]  MayinDoseme(int level)
		{

			Random rnd = new Random();
			int[,] mines = new int[0, 0];
			int requiredmine = 0;
			if (level == 1)
			{
				mines = new int[15, 2];
				requiredmine = 10;
			}
			if (level == 2)
			{
				mines = new int[20, 2];
				requiredmine = 14;
			}
			if (level == 3)
			{
				 mines = new int[25, 2];
				requiredmine = 25;
			}
			int indexer = 0 ;
			while (indexer +1 <= requiredmine)
			{
				bool flag = true;
				int x = rnd.Next(1, 14);
				int y = rnd.Next(1, 9);
				int[,] temp = new int[1, 2] { { x, y } };
				for (int i = 0; i < mines.GetLength(0); i++)
				{
					if (mines[i, 0] == temp[0, 0] && mines[i, 1] == temp[0, 1])
						flag = false;
				}
				if (flag)
				{
					mines[indexer, 0] = x;
					mines[indexer, 1] = y;
					indexer++;
				}
				else
				{
					continue;

				}
			}
			return mines;
		}
		static bool IsBusted(int[,] matrix ,int x , int y)
		{
			bool flag = false;
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				if (matrix[i,0] == x && matrix[i,1] == y)
				{
					flag = true;
				}
			}

			return flag;
		}
		static int CivarMayinlar(int[,] matrix ,int x , int y)
		{
			int result = 0;

			for (int i = 0; i <matrix.GetLength(0) ; i++)
			{
				if (matrix[i, 0] == x + 1 && matrix[i, 1] == y)
					result++;
				if(matrix[i, 0] == x - 1 && matrix[i,1] == y)
					result++;
				if (matrix[i, 1] == y + 1 && matrix[i,0]==x)
					result++;
				if (matrix[i, 1] == y - 1 && matrix[i, 0] == x)
					result++;

				if (matrix[i, 1] == y - 1 && matrix[i, 0] == x-1)
					result++;
				if (matrix[i, 1] == y + 1 && matrix[i, 0] == x - 1)
					result++;
				if (matrix[i, 1] == y - 1 && matrix[i, 0] == x + 1)
					result++;
				if (matrix[i, 1] == y + 1 && matrix[i, 0] == x + 1)
					result++;
			}

			return result;
		}
		static void Main(string[] args)
		{
			bool againOrnot = false;
			int levelnum = 0;
	
			do
			{
				Console.WriteLine("enter a level 1-3 ,3 is hardes");
				do
				{
					levelnum = Convert.ToInt32(Console.ReadLine());
				} while (levelnum != 1 && levelnum != 2 && levelnum != 3);
				Console.Clear();
				//Create Map
				MineField.CreateMap();
				//
				//Enter Mine koordinates randomly
				int[,] mines = MineField.MayinDoseme(levelnum);
				//
				int consolex = 1;
				int consoley = 1;
				int healt = 7, success = 0, exposedlistcounter = 0;
				int[,] listexposed = new int[104, 2];
			

				Console.SetCursorPosition(20, 5);
				Console.Write("Your healt");
				Console.SetCursorPosition(20, 6);
				Console.Write(healt);
				Console.SetCursorPosition(consolex, consolex);
				while (true)
				{
					bool flag = false;
					if (Console.KeyAvailable)
					{
						ConsoleKeyInfo key = Console.ReadKey(true);
						if (key.Key == ConsoleKey.UpArrow && consoley != 1)
						{
							consoley = consoley - 1;
						}
						else if (key.Key == ConsoleKey.LeftArrow && consolex != 1)
						{
							consolex = consolex - 1;
						}
						else if (key.Key == ConsoleKey.DownArrow && consoley != 8)
						{
							consoley = consoley + 1;
						}
						else if (key.Key == ConsoleKey.RightArrow && consolex != 13)
						{
							consolex = consolex + 1;
						}
						else if (key.Key == ConsoleKey.Enter)
						{
							bool isExpoesed = false;
							for (int i = 0; i < listexposed.GetLength(0); i++)
							{
								if (listexposed[i, 0] == consolex && listexposed[i, 1] == consoley)
								{
									isExpoesed = true;
								}
							}
							if (!isExpoesed)
							{
								flag = MineField.IsBusted(mines, consolex, consoley);
								if (flag)
								{
									healt--;
									Console.SetCursorPosition(20, 6);
									Console.Write(healt);
									Console.SetCursorPosition(consolex, consoley);
									Console.Write("*");
								}
								if (!flag)
								{
									int result = MineField.CivarMayinlar(mines, consolex, consoley);
									success++;
									Console.SetCursorPosition(consolex, consoley);
									Console.Write(result);

								}
								if (success >= 104 - mines.GetLength(0))
								{
									Console.Clear();
									Console.WriteLine("başarılı");
									break;
								}
								listexposed[exposedlistcounter, 0] = consolex;
								listexposed[exposedlistcounter, 1] = consoley;
								exposedlistcounter++;
							}
						}
						Console.SetCursorPosition(consolex, consoley);
					}

					if (healt <= 0)
					{
						Console.Clear();
						Console.WriteLine("you lose");
						break;
					}
				}
				Console.WriteLine("To play again enter 2 , to quit enter 1");
				int number;
				do
				{
					number = Convert.ToInt32(Console.ReadLine());
					Console.Clear();
				} while (number != 1 && number != 2);

				if(number == 1)
					againOrnot = false;
				if(number == 2)
					againOrnot = true;
			} while (againOrnot);

		

		}
	}
}