using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Sudoku
{
	//C:\Users\yagiz\Desktop\Kitap\Mat\Algorithm\AlgorithmLearner\Sudoku\bin\Debug\net7.0
	internal class Program
	{
		static void CreateStartingPanel(int cy)
		{
			if(cy == 1)
			{
				Console.WriteLine("----------------");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("|>  New Game  <| ");
				Console.ForegroundColor= ConsoleColor.White;
				Console.WriteLine("|    Info      |");
				Console.WriteLine("|Top Scoreres  |");
				Console.WriteLine("----------------");
			}
			if (cy == 2)
			{
				Console.WriteLine("----------------");
				Console.WriteLine("|  New Game    | ");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("|>   Info     <|");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("|Top Scoreres  |");
				Console.WriteLine("----------------");
			}
			if (cy == 3)
			{
				Console.WriteLine("----------------");
				Console.WriteLine("|   New Game   | ");
				Console.WriteLine("|    Info      |");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("|>Top Scoreres<|");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("----------------");
			}
		}
		static void EmptyMap()
		{
			Console.WriteLine("  1 2 3 4 5 6 7 8 9      New Piece         Score : ");
			Console.WriteLine(" +-----+-----+-----+");
			Console.WriteLine("1|     |     |     |                    Piece No : ");
			Console.WriteLine(" |     |     |     |");
			Console.WriteLine("2|     |     |     |");
			Console.WriteLine(" |     |     |     |");
			Console.WriteLine("3|     |     |     |");
			Console.WriteLine(" +-----+-----+-----+");
			Console.WriteLine("4|     |     |     |");
			Console.WriteLine(" |     |     |     |");
			Console.WriteLine("5|     |     |     |");
			Console.WriteLine(" |     |     |     |");
			Console.WriteLine("6|     |     |     |");
			Console.WriteLine(" +-----+-----+-----+");
			Console.WriteLine("7|     |     |     |");
			Console.WriteLine(" |     |     |     |");
			Console.WriteLine("8|     |     |     |");
			Console.WriteLine(" |     |     |     |");
			Console.WriteLine("9|     |     |     |");
			Console.WriteLine(" +-----+-----+-----+");
		}
		static void Main(string[] args)
		{
			//Enter Scoreres List
			string pathName = Path.Join(@"highscores.txt");
			if (!File.Exists(pathName))
			{
				FileStream fs = File.Create(pathName);
				fs.Close();
				StreamWriter f = File.AppendText(pathName);
				f.WriteLine("Gökay;19846");
				f.WriteLine("Yüksel;1653");
				f.WriteLine("Mehmet;856");
				f.WriteLine("Ahmet;653");
				f.WriteLine("Fuat;594");
				f.WriteLine("Merve;567");
				f.WriteLine("Nadirhan;435");
				f.WriteLine("Cemre;271");
				f.WriteLine("Baran;257");
				f.Write("Emir;135");
				f.Close();
			}

			//end
			do
			{
				int cx = 0, cy = 1;
				Random rnd = new Random();

				Console.SetCursorPosition(cx, cy);
				while (true)
				{
					Console.SetCursorPosition(cx, cy);
					if (Console.KeyAvailable)
					{
						ConsoleKeyInfo keyInfo = Console.ReadKey(true);
						if ((keyInfo.Key == ConsoleKey.UpArrow) && cy != 1)
							cy--;
						else if ((keyInfo.Key == ConsoleKey.DownArrow) && cy != 3)
							cy++;
						else if (keyInfo.Key == ConsoleKey.Enter) break;
					}
					if (cy == 1)
					{
						Console.Clear();
						Program.CreateStartingPanel(1);
					}
					if (cy == 2)
					{
						Console.Clear();
						Program.CreateStartingPanel(2);
					}
					if (cy == 3)
					{
						Console.Clear();
						Program.CreateStartingPanel(3);
					}
					Thread.Sleep(100);
				}
				if (cy == 1)
				{
					Console.Clear();
					Program.EmptyMap();
					int[,] binarymatrix = new int[9, 9], piece = new int[2, 2];
					bool isPieceCreated = false;
					double totalsum = 0;
					int piececounter = 1;

					Console.SetCursorPosition(50, 0);
					Console.Write(totalsum);

					Console.SetCursorPosition(50, 2);
					Console.Write(piececounter);

					for (int i = 0; i < 9; i++)
					{
						for (int j = 0; j < 9; j++)
						{
							binarymatrix[i, j] = -1;
						}
					}
					int cursorx = 2, cursory = 2;
					while (true)
					{
						// create map 
						for (int i = 0; i < binarymatrix.GetLength(0); i++)
						{
							for (int j = 0; j < binarymatrix.GetLength(1); j++)
							{
								Console.SetCursorPosition(2 + (2 * j), 2 + (2 * i));
								if (binarymatrix[i, j] == -1)
								{
									Console.Write(".");
								}
								else Console.Write(binarymatrix[i, j]);
							}
						}

						//create pieces
						if (!isPieceCreated)
						{
							for (int i = 0; i < 2; i++)
							{
								for (int j = 0; j < 2; j++)
								{
									piece[i, j] = -1;
								}
							}
							int random = rnd.Next(4, 4);
							if (random == 1)
							{
								piece[0, 0] = rnd.Next(0, 2);
							}
							else if (random == 2)
							{
								piece[0, 0] = rnd.Next(0, 2);
								piece[0, 1] = rnd.Next(0, 2);
							}
							else if (random == 3)
							{
								piece[0, 0] = rnd.Next(0, 2);
								piece[1, 0] = rnd.Next(0, 2);
							}
							else if (random == 4)
							{
								piece[0, 0] = rnd.Next(0, 2);
								piece[0, 1] = rnd.Next(0, 2);
								piece[1, 1] = rnd.Next(0, 2);
							}
							else if (random == 5)
							{
								piece[0, 0] = rnd.Next(0, 2);
								piece[0, 1] = rnd.Next(0, 2);
								piece[1, 0] = rnd.Next(0, 2);
							}
							else if (random == 6)
							{
								piece[0, 0] = rnd.Next(0, 2);
								piece[1, 0] = rnd.Next(0, 2);
								piece[1, 1] = rnd.Next(0, 2);
							}
							else if (random == 7)
							{
								piece[0, 1] = rnd.Next(0, 2);
								piece[1, 0] = rnd.Next(0, 2);
								piece[1, 1] = rnd.Next(0, 2);
							}
							else if (random == 8)
							{
								piece[0, 0] = rnd.Next(0, 2);
								piece[0, 1] = rnd.Next(0, 2);
								piece[1, 0] = rnd.Next(0, 2);
								piece[1, 1] = rnd.Next(0, 2);
							}
							isPieceCreated = true;
						}

						//checking game ended
						int counter2 = 0, matrixlenght = 0;
						for (int i = 0; i < 9; i++)
						{
							for (int j = 0; j < 9; j++)
							{
								matrixlenght = 0;
								counter2 = 0;
								for (int y = 0; y < 2; y++)
								{
									for (int x = 0; x < 2; x++)
									{
										if (piece[y, x] != -1)
										{
											matrixlenght++;
											if ((i + y < 9 && j + x < 9) && binarymatrix[i + y, j + x] == -1) counter2++;
										}
									}
								}
								if (counter2 == matrixlenght) break;
							}
							if (counter2 == matrixlenght) break;
						}
						if (counter2 < matrixlenght)
						{
							//calculate point
							string text = File.ReadAllText(pathName);
							string[] list = text.Split("\r\n");
							int[] descendingpointstable = new int[10];
							for (int i = 0 ; i<10; i++)
							{
								descendingpointstable[i] = Convert.ToInt32(list[i].Split(";")[1]);
							}
							for (int i = 0 ;i<10; i++)
							{
								if (descendingpointstable[i] < totalsum)
								{
									list[i] = $"player;{totalsum}";
									using (FileStream fs = File.Open(pathName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
									{
										lock (fs)
										{
											fs.SetLength(0);
										}
										fs.Close();
									}
									StreamWriter f = File.AppendText(pathName);
									foreach(var item in list)
									{
										f.WriteLine(item);
									}
									f.Close();
									break;
								}
							}	
							//
							Console.Clear();
							Console.WriteLine("Game Over");
							Thread.Sleep(3000);
							Console.Clear();
							break;
						}

						//writing new piece
						Console.SetCursorPosition(25, 1);
						for (int i = 0; i < 2; i++)
						{
							for (int j = 0; j < 2; j++)
							{
								if (piece[i, j] == -1)
								{
									Console.Write(" ");
									continue;
								}
								Console.Write(piece[i, j]);
							}
							Console.SetCursorPosition(25, 2);
						}

						//writing piece on board
						for (int i = 0; i < 2; i++)
						{
							for (int j = 0; j < 2; j++)
							{
								if (piece[i, j] != -1)
								{
									Console.SetCursorPosition(cursorx + (2 * j), cursory + (2 * i));
									if (binarymatrix[((cursory + (2 * i)) / 2) - 1, ((cursorx + (2 * j)) / 2) - 1] == -1)
									{
										Console.Write(piece[i, j]);
									}
									else
									{
										Console.ForegroundColor = ConsoleColor.Red;
										Console.Write("X");
										Console.ForegroundColor = ConsoleColor.White;
									}
									Console.SetCursorPosition(cursorx - (2 * j), cursory - (2 * i));
								}
							}
						}
						//writing piece on playerboard
						Console.SetCursorPosition(cursorx, cursory);
						while (true)
						{
							if (Console.KeyAvailable)
							{
								ConsoleKeyInfo keyinfo = Console.ReadKey(true);
								if (keyinfo.Key == ConsoleKey.LeftArrow)
								{
									if ((piece[0, 0] != -1 || piece[1, 0] != -1) && cursorx > 2)
									{
										cursorx -= 2;
										break;
									}
									if (((piece[0, 1] != -1 || piece[1, 1] != -1) && (piece[0, 0] != -1 || piece[1, 0] != -1)) && cursorx > 4)
									{
										cursorx -= 2;
										break;
									}
								}
								else if (keyinfo.Key == ConsoleKey.RightArrow)
								{
									if ((piece[0, 1] != -1 || piece[1, 1] != -1) && cursorx < 15)
									{
										cursorx += 2;
										break;
									}
									if (((piece[0, 0] != -1 || piece[1, 0] != -1) && (piece[0, 1] == -1 && piece[1, 1] == -1)) && cursorx < 17)
									{
										cursorx += 2;
										break;
									}
								}
								else if (keyinfo.Key == ConsoleKey.UpArrow)
								{
									if ((piece[0, 0] != -1 || piece[0, 1] != -1) && cursory > 2)
									{
										cursory -= 2;
										break;
									}
									if (((piece[1, 0] != -1 || piece[1, 1] != -1) && (piece[0, 0] == -1 || piece[0, 1] == -1)) && cursory > 4)
									{
										cursory -= 2;
										break;
									}
								}
								else if (keyinfo.Key == ConsoleKey.DownArrow)
								{
									if ((piece[1, 0] != -1 || piece[1, 1] != -1) && cursory < 15)
									{
										cursory += 2;
										break;
									}
									if (((piece[0, 1] != -1 || piece[0, 0] != -1) && (piece[1, 0] == -1 && piece[1, 1] == -1)) && cursory < 17)
									{
										cursory += 2;
										break;
									}
								}
								//storing variable on binarymatrix
								else if (keyinfo.Key == ConsoleKey.Enter)
								{
									bool flag = true;
									for (int i = 0; i < 2; i++)
									{
										for (int j = 0; j < 2; j++)
										{
											if (piece[i, j] != -1)
											{
												if (binarymatrix[(cursory / 2) - 1 + i, (cursorx / 2) - 1 + j] != -1)
												{
													flag = false;
												}
											}
										}
									}

									if (flag)
									{
										for (int i = 0; i < 2; i++)
										{
											for (int j = 0; j < 2; j++)
											{
												if (piece[i, j] != -1)
												{
													binarymatrix[(cursory / 2) - 1 + i, (cursorx / 2) - 1 + j] = piece[i, j];

												}
											}
										}
										piececounter++;
										isPieceCreated = false;
										cursorx = 2; cursory = 2;
									}

									break;
								};
							}

						}

						;
						//end of while loop

						//Calculations
						//Calculating rows
						List<int> indexoffinishedrows = new();
						for (int i = 0; i < 9; i++)
						{
							int counter = 0;
							for (int j = 0; j < 9; j++)
							{
								if (binarymatrix[i, j] != -1) counter++;
							}
							if (counter == 9)
								indexoffinishedrows.Add(i);
						}
						//end

						//Calculating finished Columns
						List<int> indexoffinishedcolumns = new();
						for (int i = 0; i < 9; i++)
						{
							int counter = 0;
							for (int j = 0; j < 9; j++)
							{
								if (binarymatrix[j, i] != -1) counter++;
							}
							if (counter == 9)
								indexoffinishedcolumns.Add(i);
						}
						//Calculating finished blocks
						List<int> indexoffinishedblocks = new();

						for (int i = 0; i < 3; i++)
						{
							for (int j = 0; j < 3; j++)
							{
								int counter = 0;
								for (int y = (i * 3); y < (i * 3) + 3; y++)
								{
									for (int x = (j * 3); x < (j * 3) + 3; x++)
									{
										if (binarymatrix[y, x] != -1)
										{
											counter++;
										}
									}
								}
								if (counter == 9)
									indexoffinishedblocks.Add((3 * i) + j);
							}
						}

						//end
						//end
						//clearing rows and calculating points

						if (indexoffinishedrows.Count() > 0)
						{
							//calculate points of rows
							double sum = 0;
							for (int i = 0; i < indexoffinishedrows.Count(); i++)
							{
								for (int j = 0; j < 9; j++)
								{
									if (binarymatrix[indexoffinishedrows[i], j] != 0)
										sum += Math.Ceiling(Math.Pow(2, 8 - j) / 1000);
									binarymatrix[indexoffinishedrows[i], j] = -1;
								}
							}
							indexoffinishedrows = new();
							totalsum += sum;
						}

						//clearing columns
						if (indexoffinishedcolumns.Count() > 0)
						{
							double sum = 0;
							for (int i = 0; i < indexoffinishedcolumns.Count(); i++)
							{
								for (int j = 0; j < 9; j++)
								{
									if (binarymatrix[j, indexoffinishedcolumns[i]] != 0)
										sum += Math.Ceiling(Math.Pow(2, 8 - j) / 1000);
									binarymatrix[j, indexoffinishedcolumns[i]] = -1;
								}
							}
							indexoffinishedrows = new();
							totalsum += sum;
						}
						//clearing blocks
						if (indexoffinishedblocks.Count() > 0)
						{
							double sum = 0;
							for (int i = 0; i < indexoffinishedblocks.Count(); i++)
							{
								int rowindex = 0, columnindex = 0;
								int counter = 0;

								if (indexoffinishedblocks[i] >= 0 && indexoffinishedblocks[i] <= 2)
									rowindex = 0;
								if (indexoffinishedblocks[i] >= 3 && indexoffinishedblocks[i] <= 5)
									rowindex = 3;
								if (indexoffinishedblocks[i] >= 6 && indexoffinishedblocks[i] <= 8)
									rowindex = 6;

								if (indexoffinishedblocks[i] % 3 == 0)
									columnindex = 0;
								if (indexoffinishedblocks[i] % 3 == 1)
									columnindex = 3;
								if (indexoffinishedblocks[i] % 3 == 2)
									columnindex = 6;

								for (int y = rowindex; y < rowindex + 3; y++)
								{
									for (int x = columnindex; x < columnindex + 3; x++)
									{
										if (binarymatrix[y, x] != 0)
											sum += Math.Ceiling(Math.Pow(2, 8 - counter) / 1000);
										binarymatrix[y, x] = -1;
										counter--;
									}
								}
							}
							indexoffinishedblocks = new();
							totalsum += sum;
						}
						Console.SetCursorPosition(50, 0);
						Console.Write(totalsum);
						Console.SetCursorPosition(50, 2);
						Console.Write(piececounter);

					}

				}
				else if (cy == 2)
				{
					Console.Clear();
					Console.WriteLine("Created by yagiz erdem");
					Console.ReadKey();
				}
				else if (cy == 3)
				{
					Console.Clear();

					if (File.Exists(pathName))
					{
						Console.WriteLine("Top 10 scorers");
						string text = File.ReadAllText(pathName);
						Console.WriteLine(text);
						
						Console.ReadKey();
					}

				}
			} while (true);

			
		
		}
	}
}