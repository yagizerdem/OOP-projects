using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Chess
{
	internal class Program
	{
		// 2-4-6-8-10-12-14-16 == y coordinates
		//3-6-9-12-15-18-21-24 == x coordinates
		//şah = 10  , fil = 4 , at = 3 , kale = 5 , piyon = 1;
		static void CreateBord()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 28; j++)
				{
					if (i == 0 || i == 9)
					{
						Console.Write("-");
						continue;
					}
					if (j == 0 || j == 27)
					{
						Console.Write("|");
						continue;
					}
					if (j % 3 == 0)
					{
						Console.Write(".");
						continue;
					}
					Console.Write(" ");
				}
				Console.WriteLine();
				Console.WriteLine();
			}
		}
		static void Main(string[] args)
		{
			Program.CreateBord();
			int[,] redpieces = new int[16, 3];
			int[,] bluepieces = new int[16, 3];
			int cursorx = 3, cursory = 4;
			string turn = "turnblue";
			bool isbluekingchecked = false, isredkingchecked = false;

			// create initial red pieces and locations
			Console.SetCursorPosition(cursorx, cursory);
			for (int i = 0; i < redpieces.GetLength(0); i++)
			{
				if (i < 8)
				{
					redpieces[i, 0] = 1;
					redpieces[i, 1] = cursorx;
					cursorx += 3;
					redpieces[i, 2] = cursory;
				}
				if (i == 8)
				{
					cursorx = 3;
					cursory = 2;
				}
				if (i >= 8)
				{

					switch (i)
					{
						case 8:
							redpieces[i, 0] = 5;
							redpieces[i, 1] = cursorx;
							cursorx += 3;
							redpieces[i, 2] = cursory;
							break;
						case 9:
							redpieces[i, 0] = 3;
							redpieces[i, 1] = cursorx;
							cursorx += 3;
							redpieces[i, 2] = cursory;
							break;
						case 10:
							redpieces[i, 0] = 4;
							redpieces[i, 1] = cursorx;
							cursorx += 3;
							redpieces[i, 2] = cursory;
							break;
						case 11:
							redpieces[i, 0] = 10;
							redpieces[i, 1] = cursorx;
							cursorx += 3;
							redpieces[i, 2] = cursory;
							break;
						case 12:
							redpieces[i, 0] = 9;
							redpieces[i, 1] = cursorx;
							cursorx += 3;
							redpieces[i, 2] = cursory;
							break;
						case 13:
							redpieces[i, 0] = 4;
							redpieces[i, 1] = cursorx;
							cursorx += 3;
							redpieces[i, 2] = cursory;
							break;
						case 14:
							redpieces[i, 0] = 3;
							redpieces[i, 1] = cursorx;
							cursorx += 3;
							redpieces[i, 2] = cursory;
							break;
						case 15:
							redpieces[i, 0] = 5;
							redpieces[i, 1] = cursorx;
							cursorx += 3;
							redpieces[i, 2] = cursory;
							break;
					}
				}
			}
			//end

			//create initial blue pieces and locations
			cursorx = 3; cursory = 14;
			Console.SetCursorPosition(cursorx, cursory);
			for (int i = 0; i < redpieces.GetLength(0); i++)
			{
				if (i < 8)
				{
					bluepieces[i, 0] = 1;
					bluepieces[i, 1] = cursorx;
					cursorx += 3;
					bluepieces[i, 2] = cursory;
				}
				if (i == 8)
				{
					cursorx = 3;
					cursory = 16;
				}
				if (i >= 8)
				{

					switch (i)
					{
						case 8:
							bluepieces[i, 0] = 5;
							bluepieces[i, 1] = cursorx;
							cursorx += 3;
							bluepieces[i, 2] = cursory;
							break;
						case 9:
							bluepieces[i, 0] = 3;
							bluepieces[i, 1] = cursorx;
							cursorx += 3;
							bluepieces[i, 2] = cursory;
							break;
						case 10:
							bluepieces[i, 0] = 4;
							bluepieces[i, 1] = cursorx;
							cursorx += 3;
							bluepieces[i, 2] = cursory;
							break;
						case 11:
							bluepieces[i, 0] = 10;
							bluepieces[i, 1] = cursorx;
							cursorx += 3;
							bluepieces[i, 2] = cursory;
							break;
						case 12:
							bluepieces[i, 0] = 9;
							bluepieces[i, 1] = cursorx;
							cursorx += 3;
							bluepieces[i, 2] = cursory;
							break;
						case 13:
							bluepieces[i, 0] = 4;
							bluepieces[i, 1] = cursorx;
							cursorx += 3;
							bluepieces[i, 2] = cursory;
							break;
						case 14:
							bluepieces[i, 0] = 3;
							bluepieces[i, 1] = cursorx;
							cursorx += 3;
							bluepieces[i, 2] = cursory;
							break;
						case 15:
							bluepieces[i, 0] = 5;
							bluepieces[i, 1] = cursorx;
							cursorx += 3;
							bluepieces[i, 2] = cursory;
							break;
					}
				}
			}
			//end

			cursorx = 3; cursory = 2;


			do
			{
				int goback_counter = 0;
				//write who has turn
				Console.SetCursorPosition(35, 5);
				if (turn == "turnblue")
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.Write("Blue's");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write(" turn");
				}
				if (turn == "turnred")
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("Red's");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write(" turn");
				}

				//print red piecs on borad
				for (int i = 0; i < 16; i++)
				{
					Console.SetCursorPosition(redpieces[i, 1], redpieces[i, 2]);
					Console.ForegroundColor = ConsoleColor.Red;
					if (redpieces[i, 0] == -1)
						continue;
					switch (redpieces[i, 0])
					{
						case 1:
							Console.Write("P");
							break;
						case 3:
							Console.Write("H");
							break;
						case 4:
							Console.Write("B");
							break;
						case 5:
							Console.Write("R");
							break;
						case 9:
							Console.Write("Q");
							break;
						case 10:
							Console.Write("K");
							break;
					}
				}
				Console.ForegroundColor = ConsoleColor.White;
				//end

				//print blue pieces on board
				for (int i = 0; i < 16; i++)
				{
					Console.SetCursorPosition(bluepieces[i, 1], bluepieces[i, 2]);
					Console.ForegroundColor = ConsoleColor.Blue;
					if (bluepieces[i, 0] == -1)
						continue;
					switch (bluepieces[i, 0])
					{
						case 1:
							Console.Write("P");
							break;
						case 3:
							Console.Write("H");
							break;
						case 4:
							Console.Write("B");
							break;
						case 5:
							Console.Write("R");
							break;
						case 9:
							Console.Write("Q");
							break;
						case 10:
							Console.Write("K");
							break;
					}
				}
				Console.ForegroundColor = ConsoleColor.White;
				//end

				Console.SetCursorPosition(cursorx, cursory);
				ConsoleKeyInfo ckey = Console.ReadKey(true);
				if (!Console.KeyAvailable)
				{
					if (ckey.Key == ConsoleKey.UpArrow && cursory > 2)
					{
						cursory -= 2;
						continue;
					}
					if (ckey.Key == ConsoleKey.DownArrow && cursory < 16)
					{
						cursory += 2;
						continue;
					}
					if (ckey.Key == ConsoleKey.LeftArrow && cursorx > 3)
					{
						cursorx -= 3;
						continue;
					}
					if (ckey.Key == ConsoleKey.RightArrow && cursorx < 24)
					{
						cursorx += 3;
						continue;
					}
					if (ckey.Key == ConsoleKey.Enter)
					{

						//blue turn
						if (turn == "turnblue")
						{
							int indexofselectedpiece = -1;
							string piecetype = "";
							int tempx = -1, tempy = -1;
							bool didbluemove = true;
							for (int i = 0; i < bluepieces.GetLength(0); i++)
							{
								if (bluepieces[i, 1] == cursorx && bluepieces[i, 2] == cursory && bluepieces[i, 0] != -1)
								{
									indexofselectedpiece = i; break;
								}
							}
							if (indexofselectedpiece < 0 || bluepieces[indexofselectedpiece, 0] == -1)
								continue;

							tempx = bluepieces[indexofselectedpiece, 1];
							tempy = bluepieces[indexofselectedpiece, 2];

							if (bluepieces[indexofselectedpiece, 0] == 1)
								piecetype = "P";
							if (bluepieces[indexofselectedpiece, 0] == 3)
								piecetype = "H";
							if (bluepieces[indexofselectedpiece, 0] == 4)
								piecetype = "B";
							if (bluepieces[indexofselectedpiece, 0] == 5)
								piecetype = "R";
							if (bluepieces[indexofselectedpiece, 0] == 9)
								piecetype = "Q";
							if (bluepieces[indexofselectedpiece, 0] == 10)
								piecetype = "K";

							//Console.Clear();
							//Console.WriteLine(piecetype);

							do
							{
								Console.SetCursorPosition(cursorx, cursory);
								ckey = Console.ReadKey(true);
								if (!Console.KeyAvailable)
								{
									if (ckey.Key == ConsoleKey.UpArrow && cursory > 2)
									{
										cursory -= 2;
										continue;
									}
									if (ckey.Key == ConsoleKey.DownArrow && cursory < 16)
									{
										cursory += 2;
										continue;
									}
									if (ckey.Key == ConsoleKey.LeftArrow && cursorx > 3)
									{
										cursorx -= 3;
										continue;
									}
									if (ckey.Key == ConsoleKey.RightArrow && cursorx < 24)
									{
										cursorx += 3;
										continue;
									}
									if (ckey.Key == ConsoleKey.Enter)
									{
										if (piecetype == "P")
										{
											bool canMove = true;
											bool canMakeStarterMove = true;
											bool canMoveDiagonalLeft = false, canMoveDiagonalRight = false;
											for (int i = 0; i < bluepieces.GetLength(0); i++)
											{
												if (bluepieces[i, 0] != -1)
												{
													if (i != indexofselectedpiece && (bluepieces[indexofselectedpiece, 1] == bluepieces[i, 1] && bluepieces[indexofselectedpiece, 2] - 2 == bluepieces[i, 2]))
													{
														canMove = false;
													}
												}
											}

											if (bluepieces[indexofselectedpiece, 2] == 14)
											{
												for (int i = 0; i < bluepieces.GetLength(0); i++)
												{
													if (bluepieces[i, 0] != -1)
													{
														if (i != indexofselectedpiece && (bluepieces[indexofselectedpiece, 1] == bluepieces[i, 1] && (bluepieces[indexofselectedpiece, 2] - 4 == bluepieces[i, 2] || bluepieces[indexofselectedpiece, 2] - 2 == bluepieces[i, 2])))
														{
															canMakeStarterMove = false;
														}
														if (i != indexofselectedpiece && (bluepieces[indexofselectedpiece, 1] == redpieces[i, 1] && (bluepieces[indexofselectedpiece, 2] - 4 == redpieces[i, 2] || bluepieces[indexofselectedpiece, 2] - 2 == redpieces[i, 2])))
														{
															canMakeStarterMove = false;
														}
													}
												}
											}

											for (int i = 0; i < redpieces.GetLength(0); i++)
											{
												if (redpieces[i, 0] != -1)
												{
													if ((bluepieces[indexofselectedpiece, 1] == redpieces[i, 1]) && (bluepieces[indexofselectedpiece, 2] - 2 == redpieces[i, 2]))
													{
														canMove = false;
													}
												}
											}
											if (bluepieces[indexofselectedpiece, 2] == 14)
											{
												for (int i = 0; i < redpieces.GetLength(0); i++)
												{
													if (redpieces[i, 0] != -1)
													{
														if ((bluepieces[indexofselectedpiece, 1] == redpieces[i, 1]) && (bluepieces[indexofselectedpiece, 2] - 4 == redpieces[i, 2]))
														{
															canMakeStarterMove = false;
														}
													}
												}
											}
											if (bluepieces[indexofselectedpiece, 2] != 14)
											{
												canMakeStarterMove = false;
											}
											//diagonal move calculator
											for (int i = 0; i < redpieces.GetLength(0); i++)
											{
												if (redpieces[i, 0] != -1)
												{
													if (redpieces[i, 1] == bluepieces[indexofselectedpiece, 1] - 3 && redpieces[i, 2] == bluepieces[indexofselectedpiece, 2] - 2)
													{
														canMoveDiagonalLeft = true;
													}
													if (redpieces[i, 1] == bluepieces[indexofselectedpiece, 1] + 3 && redpieces[i, 2] == bluepieces[indexofselectedpiece, 2] - 2)
													{
														canMoveDiagonalRight = true;
													}
												}
											}
											//
											if (bluepieces[indexofselectedpiece, 1] == cursorx && bluepieces[indexofselectedpiece, 2] == cursory)
											{
												didbluemove = false;
											}
											if (canMove && ((cursory == bluepieces[indexofselectedpiece, 2] - 2) && (cursorx == bluepieces[indexofselectedpiece, 1])))
											{
												bluepieces[indexofselectedpiece, 2] = cursory;
												Console.Clear();
												Program.CreateBord();
												turn = "turnred";
											}
											if (canMakeStarterMove && ((cursory == bluepieces[indexofselectedpiece, 2] - 4) && (cursorx == bluepieces[indexofselectedpiece, 1])))
											{
												bluepieces[indexofselectedpiece, 2] = cursory;
												Console.Clear();
												Program.CreateBord();
												turn = "turnred";
											}
											if (canMoveDiagonalLeft && ((cursory == bluepieces[indexofselectedpiece, 2] - 2) && (cursorx == bluepieces[indexofselectedpiece, 1] - 3)))
											{
												bluepieces[indexofselectedpiece, 2] = cursory;
												bluepieces[indexofselectedpiece, 1] = cursorx;
												for (int i = 0; i < redpieces.GetLength(0); i++)
												{
													if (redpieces[i, 1] == cursorx && redpieces[i, 2] == cursory && redpieces[i, 0] != -1)
													{
														redpieces[i, 0] = -1;
														break;
													}
												}
												Console.Clear();
												Program.CreateBord();
												turn = "turnred";
											}
											if (canMoveDiagonalRight && ((cursory == bluepieces[indexofselectedpiece, 2] - 2) && (cursorx == bluepieces[indexofselectedpiece, 1] + 3)))
											{
												bluepieces[indexofselectedpiece, 2] = cursory;
												bluepieces[indexofselectedpiece, 1] = cursorx;
												for (int i = 0; i < redpieces.GetLength(0); i++)
												{
													if (redpieces[i, 1] == cursorx && redpieces[i, 2] == cursory && redpieces[i, 0] != -1)
													{
														redpieces[i, 0] = -1;
														break;
													}
												}
												if (cursory == 2)
												{
													bluepieces[indexofselectedpiece, 0] = 9;
												}
												Console.Clear();
												Program.CreateBord();
												turn = "turnred";
											}
											break;
										}
										if (piecetype == "H")
										{
											bool canMove = true;
											if (
													(bluepieces[indexofselectedpiece, 1] + 6 == cursorx && bluepieces[indexofselectedpiece, 2] + 2 == cursory)
													||
													(bluepieces[indexofselectedpiece, 1] + 6 == cursorx && bluepieces[indexofselectedpiece, 2] - 2 == cursory)
													||
													(bluepieces[indexofselectedpiece, 1] + 3 == cursorx && bluepieces[indexofselectedpiece, 2] + 4 == cursory)
													||
													(bluepieces[indexofselectedpiece, 1] + 3 == cursorx && bluepieces[indexofselectedpiece, 2] - 4 == cursory)
													||
													(bluepieces[indexofselectedpiece, 1] - 3 == cursorx && bluepieces[indexofselectedpiece, 2] - 4 == cursory)
													||
													(bluepieces[indexofselectedpiece, 1] - 3 == cursorx && bluepieces[indexofselectedpiece, 2] + 4 == cursory)
													||
													(bluepieces[indexofselectedpiece, 1] - 6 == cursorx && bluepieces[indexofselectedpiece, 2] + 2 == cursory)
													||
													(bluepieces[indexofselectedpiece, 1] - 6 == cursorx && bluepieces[indexofselectedpiece, 2] - 2 == cursory)
													)
											{
												for (int i = 0; i < bluepieces.GetLength(0); i++)
												{
													if (bluepieces[i, 0] != -1)
													{
														if (bluepieces[i, 1] == cursorx && bluepieces[i, 2] == cursory)
														{
															canMove = false;
														}
													}
												}
												if (bluepieces[indexofselectedpiece, 1] == cursorx && bluepieces[indexofselectedpiece, 2] == cursory)
												{
													didbluemove = false;
												}
												if (canMove)
												{
													bluepieces[indexofselectedpiece, 2] = cursory;
													bluepieces[indexofselectedpiece, 1] = cursorx;
													for (int i = 0; i < redpieces.GetLength(0); i++)
													{
														if (redpieces[i, 1] == cursorx && redpieces[i, 2] == cursory && redpieces[i, 0] != -1)
														{
															redpieces[i, 0] = -1;
															break;
														}
													}
													Console.Clear();
													Program.CreateBord();
													turn = "turnred";
												}
											}
											else
											{
												didbluemove = false;
											}
											break;
										}
										if (piecetype == "B")
										{
											bool canMove = true;
											int counter = 0;
											if (Math.Abs(bluepieces[indexofselectedpiece, 1] - cursorx) / 3 == Math.Abs(bluepieces[indexofselectedpiece, 2] - cursory) / 2)
											{
												if (cursorx > bluepieces[indexofselectedpiece, 1] && cursory > bluepieces[indexofselectedpiece, 2])
												{
													//control blue piece
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x >= bluepieces[indexofselectedpiece, 1]; x -= 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}
															}
														}
													}
													//conrorl red pieces
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx - 3, y = cursory - 2; x >= bluepieces[indexofselectedpiece, 1]; x -= 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		counter++;
																	}
																}
															}
														}
													}

												}

												if (cursorx > bluepieces[indexofselectedpiece, 1] && cursory < bluepieces[indexofselectedpiece, 2])
												{
													//blue control
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x >= bluepieces[indexofselectedpiece, 1]; x -= 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}
															}
														}
													}
													//red contorl 
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx - 3, y = cursory + 2; x >= bluepieces[indexofselectedpiece, 1]; x -= 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		counter++;
																	}
																}
															}
														}
													}
												}

												if (cursorx < bluepieces[indexofselectedpiece, 1] && cursory > bluepieces[indexofselectedpiece, 2])
												{
													//blue control
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x <= bluepieces[indexofselectedpiece, 1]; x += 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}
															}
														}
													}
													//red control
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3, y = cursory - 2; x <= bluepieces[indexofselectedpiece, 1]; x += 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		counter++;
																	}
																}
															}
														}
													}
												}

												if (cursorx < bluepieces[indexofselectedpiece, 1] && cursory < bluepieces[indexofselectedpiece, 2])
												{
													//blue control
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x <= bluepieces[indexofselectedpiece, 1]; x += 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}
															}
														}
													}
													// red control
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3, y = cursory + 2; x <= bluepieces[indexofselectedpiece, 1]; x += 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		counter++;
																	}
																}
															}
														}
													}
												}
											}
											else
											{
												canMove = false;
											}
											if (bluepieces[indexofselectedpiece, 1] == cursorx && bluepieces[indexofselectedpiece, 2] == cursory)
											{
												didbluemove = false;
											}
											if (canMove && counter == 0)
											{
												bluepieces[indexofselectedpiece, 2] = cursory;
												bluepieces[indexofselectedpiece, 1] = cursorx;
												for (int i = 0; i < redpieces.GetLength(0); i++)
												{
													if (redpieces[i, 1] == cursorx && redpieces[i, 2] == cursory && redpieces[i, 0] != -1)
													{
														redpieces[i, 0] = -1;
														break;
													}
												}
												Console.Clear();
												Program.CreateBord();
												turn = "turnred";
											}
											else
											{
												didbluemove = false;
											}
											break;
										}
										if (piecetype == "R")
										{
											bool canMove = true;
											int counter = 0;
											if (cursorx == bluepieces[indexofselectedpiece, 1] || cursory == bluepieces[indexofselectedpiece, 2])
											{
												if (cursorx == bluepieces[indexofselectedpiece, 1] && cursory > bluepieces[indexofselectedpiece, 2])
												{
													// blue control
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int y = cursory; y >= bluepieces[indexofselectedpiece, 2]; y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// red control 
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int y = cursory - 2; y >= bluepieces[indexofselectedpiece, 2]; y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx == bluepieces[indexofselectedpiece, 1] && cursory < bluepieces[indexofselectedpiece, 2])
												{
													// blue conter 
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int y = cursory; y <= bluepieces[indexofselectedpiece, 2]; y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													//red counter 
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int y = cursory + 2; y <= bluepieces[indexofselectedpiece, 2]; y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursory == bluepieces[indexofselectedpiece, 2] && cursorx < bluepieces[indexofselectedpiece, 1])
												{
													// blue counter
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx; x <= bluepieces[indexofselectedpiece, 1]; x += 3)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																	{
																		canMove = false;
																	}
																}
															}
														}
													}
													// red counter
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3; x <= bluepieces[indexofselectedpiece, 1]; x += 3)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																	{
																		counter++;
																	}
																}
															}
														}
													}
												}

												if (cursory == bluepieces[indexofselectedpiece, 2] && cursorx > bluepieces[indexofselectedpiece, 1])
												{
													// blue counter
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx; x >= bluepieces[indexofselectedpiece, 1]; x -= 3)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																	{
																		canMove = false;
																	}
																}
															}
														}
													}
													// red counter 
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx - 3; x >= bluepieces[indexofselectedpiece, 1]; x -= 3)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																	{
																		counter++;
																	}
																}
															}
														}
													}
												}
											}
											else
											{
												canMove = false;
											}
											if (bluepieces[indexofselectedpiece, 1] == cursorx && bluepieces[indexofselectedpiece, 2] == cursory)
											{
												didbluemove = false;
											}
											if (canMove && counter == 0)
											{
												bluepieces[indexofselectedpiece, 2] = cursory;
												bluepieces[indexofselectedpiece, 1] = cursorx;
												for (int i = 0; i < redpieces.GetLength(0); i++)
												{
													if (redpieces[i, 1] == cursorx && redpieces[i, 2] == cursory && redpieces[i, 0] != -1)
													{
														redpieces[i, 0] = -1;
														break;
													}
												}
												Console.Clear();
												Program.CreateBord();
												turn = "turnred";
											}
											break;
										}
										if (piecetype == "Q")
										{
											bool canMove = true;
											int counter = 0;
											if (cursorx == bluepieces[indexofselectedpiece, 1] || cursory == bluepieces[indexofselectedpiece, 2] || Math.Abs(bluepieces[indexofselectedpiece, 1] - cursorx) / 3 == Math.Abs(bluepieces[indexofselectedpiece, 2] - cursory) / 2)
											{
												if (cursorx > bluepieces[indexofselectedpiece, 1] && cursory > bluepieces[indexofselectedpiece, 2])
												{
													// blue control
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x >= bluepieces[indexofselectedpiece, 1]; x -= 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}
															}
														}
													}
													//red control
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx - 3, y = cursory - 2; x >= bluepieces[indexofselectedpiece, 1]; x -= 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		counter++;
																	}
																}
															}
														}
													}
												}

												if (cursorx > bluepieces[indexofselectedpiece, 1] && cursory < bluepieces[indexofselectedpiece, 2])
												{
													//blue control
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x >= bluepieces[indexofselectedpiece, 1]; x -= 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													//red control
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx - 3, y = cursory + 2; x >= bluepieces[indexofselectedpiece, 1]; x -= 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx < bluepieces[indexofselectedpiece, 1] && cursory > bluepieces[indexofselectedpiece, 2])
												{
													// blue control
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x <= bluepieces[indexofselectedpiece, 1]; x += 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													//red control
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3, y = cursory - 2; x <= bluepieces[indexofselectedpiece, 1]; x += 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx < bluepieces[indexofselectedpiece, 1] && cursory < bluepieces[indexofselectedpiece, 2])
												{
													// blue control
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3, y = cursory + 2; x <= bluepieces[indexofselectedpiece, 1]; x += 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// red control
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3, y = cursory + 2; x <= bluepieces[indexofselectedpiece, 1]; x += 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx == bluepieces[indexofselectedpiece, 1] && cursory > bluepieces[indexofselectedpiece, 2])
												{
													// blue control
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int y = cursory; y >= bluepieces[indexofselectedpiece, 2]; y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// red control
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int y = cursory - 2; y >= bluepieces[indexofselectedpiece, 2]; y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx == bluepieces[indexofselectedpiece, 1] && cursory < bluepieces[indexofselectedpiece, 2])
												{
													// blue control
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int y = cursory; y <= bluepieces[indexofselectedpiece, 2]; y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// red control
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int y = cursory + 2; y <= bluepieces[indexofselectedpiece, 2]; y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursory == bluepieces[indexofselectedpiece, 2] && cursorx < bluepieces[indexofselectedpiece, 1])
												{
													// blue control
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx; x <= bluepieces[indexofselectedpiece, 1]; x += 3)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// red control
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3; x <= bluepieces[indexofselectedpiece, 1]; x += 3)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursory == bluepieces[indexofselectedpiece, 2] && cursorx > bluepieces[indexofselectedpiece, 1])
												{
													// blue control
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx; x >= bluepieces[indexofselectedpiece, 1]; x -= 3)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// red control
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx - 3; x >= bluepieces[indexofselectedpiece, 1]; x -= 3)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

											}
											else
											{
												canMove = false;
											}
											if (bluepieces[indexofselectedpiece, 1] == cursorx && bluepieces[indexofselectedpiece, 2] == cursory)
											{
												didbluemove = false;
											}
											if (canMove && counter == 0)
											{
												bluepieces[indexofselectedpiece, 2] = cursory;
												bluepieces[indexofselectedpiece, 1] = cursorx;
												for (int i = 0; i < redpieces.GetLength(0); i++)
												{
													if (redpieces[i, 1] == cursorx && redpieces[i, 2] == cursory && redpieces[i, 0] != -1)
													{
														redpieces[i, 0] = -1;
														break;
													}
												}
												Console.Clear();
												Program.CreateBord();
												turn = "turnred";
											}
											break;
										}
										if (piecetype == "K")
										{
											bool canMove = true;
											if (!(Math.Abs(bluepieces[indexofselectedpiece, 1] - cursorx) <= 3 && Math.Abs(bluepieces[indexofselectedpiece, 2] - cursory) <= 2))
											{
												canMove = false;
											}
											for (int i = 0; i < bluepieces.GetLength(0); i++)
											{
												if (bluepieces[i, 0] != -1)
												{
													if (bluepieces[i, 1] == cursorx && bluepieces[i, 2] == cursory)
													{
														canMove = false;
													}
												}
											}
											// finding king can eate piece 
											for (int i = 0; i < redpieces.GetLength(0); i++)
											{
												//getting enemy piece type
												string redPiecetype = "";
												if (redpieces[i, 0] != -1)
												{
													if (redpieces[i, 0] == 1)
													{
														redPiecetype = "P";
													}
													if (redpieces[i, 0] == 3)
													{
														redPiecetype = "H";
													}
													if (redpieces[i, 0] == 4)
													{
														redPiecetype = "B";
													}
													if (redpieces[i, 0] == 5)
													{
														redPiecetype = "R";
													}
													if (redpieces[i, 0] == 9)
													{
														redPiecetype = "Q";
													}
													if (redpieces[i, 0] == 10)
													{
														redPiecetype = "K";
													}
												}
												//
												if (redPiecetype == "P")
												{
													if ((redpieces[i, 1] + 3 == cursorx && redpieces[i, 2] + 2 == cursory) || redpieces[i, 1] - 3 == cursorx && redpieces[i, 2] + 2 == cursory)
													{
														canMove = false;
													}
												}
												if (redPiecetype == "H")
												{
													if (
														(redpieces[i, 1] + 6 == cursorx && redpieces[i, 2] + 2 == cursory)
													||
													(redpieces[i, 1] + 6 == cursorx && redpieces[i, 2] - 2 == cursory)
													||
													(redpieces[i, 1] + 3 == cursorx && redpieces[i, 2] + 4 == cursory)
													||
													(redpieces[i, 1] + 3 == cursorx && redpieces[i, 2] - 4 == cursory)
													||
													(redpieces[i, 1] - 3 == cursorx && redpieces[i, 2] - 4 == cursory)
													||
													(redpieces[i, 1] - 3 == cursorx && redpieces[i, 2] + 4 == cursory)
													||
													(redpieces[i, 1] - 6 == cursorx && redpieces[i, 2] + 2 == cursory)
													||
													(redpieces[i, 1] - 6 == cursorx && redpieces[i, 2] - 2 == cursory)
														)
													{
														canMove = false;
													}
												}
												if (redPiecetype == "B")
												{
													int counter = 0;
													if (Math.Abs(cursorx - redpieces[i, 1]) / 3 == Math.Abs(cursory - redpieces[i, 2]) / 2)
													{
														if (cursorx == redpieces[i, 1] && cursory == redpieces[i, 2])
														{
															counter++;
														}

														if (cursorx > redpieces[i, 1] && cursory > redpieces[i, 2])
														{
															//control red piece
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x >= redpieces[i, 1]; x -= 3, y -= 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}
																	}
																}
															}
															//conrorl blue pieces
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3, y = cursory - 2; x >= redpieces[i, 1]; x -= 3, y -= 2)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}

																}
															}

														}

														if (cursorx > redpieces[i, 1] && cursory < redpieces[i, 2])
														{
															//red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x >= redpieces[indexofselectedpiece, 1]; x -= 3, y += 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}
																	}
																}
															}
															//blue piece contorl 
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3, y = cursory + 2; x >= redpieces[i, 1]; x -= 3, y += 2)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}

																}
															}
														}

														if (cursorx < bluepieces[i, 1] && cursory > bluepieces[i, 2])
														{
															//red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x <= redpieces[i, 1]; x += 3, y -= 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}
																	}
																}
															}
															//blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx + 3, y = cursory - 2; x <= redpieces[i, 1]; x += 3, y -= 2)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}

																}
															}
														}

														if (cursorx < bluepieces[i, 1] && cursory < bluepieces[i, 2])
														{
															//red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x <= redpieces[i, 1]; x += 3, y += 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																			{
																				canMove = false;
																			}
																		}
																	}
																}
															}
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx + 3, y = cursory + 2; x <= redpieces[i, 1]; x += 3, y += 2)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}

																}
															}
														}


														if (counter == 0)
														{
															canMove = false;
														}
													}
												}
												if (redPiecetype == "R")
												{
													int counter = 0;
													if (cursorx == redpieces[i, 1] || cursory == redpieces[i, 2])
													{
														if(cursorx == redpieces[i, 1] && cursory == redpieces[i, 2])
														{
															counter++;
														}
														if (cursorx == redpieces[i, 1] && cursory > redpieces[i, 2])
														{
															// red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																
																for (int y = cursory; y >= redpieces[i, 2]; y -= 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															// blue piece control 
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int y = cursory - 2; y >= redpieces[i, 2]; y -= 2)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursorx == redpieces[i, 1] && cursory < redpieces[i, 2])
														{
															// red piece conter 
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																
																for (int y = cursory; y <= redpieces[i, 2]; y += 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															//blue piece counter 
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int y = cursory + 2; y <= redpieces[i, 2]; y += 2)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursory == redpieces[i, 2] && cursorx < redpieces[i, 1])
														{
															// red piece counter
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																
																for (int x = cursorx; x <= redpieces[i, 1]; x += 3)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																			{
																				counter++;
																			}
																		}
																	}
																}
															}
															// blue piece counter
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx + 3; x <= redpieces[i, 1]; x += 3)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																		{
																			counter++;
																		}
																	}

																}
															}
														}

														if (cursory == redpieces[i, 2] && cursorx > redpieces[i, 1])
														{
															// red piece counter
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{

																for (int x = cursorx; x >= redpieces[i, 1]; x -= 3)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																			{
																				counter++;
																			}
																		}
																	}
																}
															}
															// blue piece counter 
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3; x >= redpieces[i, 1]; x -= 3)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																		{
																			counter++;
																		}
																	}

																}
															}
														}
														if (counter == 0)
														{
															canMove = false;
														}
													}


												}
												if (redPiecetype == "Q")
												{
													int counter = 0;
													if (cursorx == redpieces[i, 1] || cursory == redpieces[i, 2] || Math.Abs(redpieces[i, 1] - cursorx) / 3 == Math.Abs(redpieces[i, 2] - cursory) / 2)
													{
														if (cursorx == redpieces[i, 1] && cursory == redpieces[i, 2])
														{
															counter++;
														}
														if (cursorx > redpieces[i, 1] && cursory > redpieces[i, 2])
														{
															// red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x >= redpieces[i, 1]; x -= 3, y -= 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}
																	}
																}
															}
															//blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3, y = cursory - 2; x >= redpieces[i, 1]; x -= 3, y -= 2)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}

																}
															}
														}

														if (cursorx > redpieces[i, 1] && cursory < redpieces[i, 2])
														{
															//red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x >= redpieces[i, 1]; x -= 3, y += 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															//blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3, y = cursory + 2; x >= redpieces[i, 1]; x -= 3, y += 2)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursorx < redpieces[i, 1] && cursory > redpieces[i, 2])
														{
															// red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x <= redpieces[i, 1]; x += 3, y -= 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															//blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx + 3, y = cursory - 2; x <= redpieces[i, 1]; x += 3, y -= 2)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursorx < redpieces[i, 1] && cursory < redpieces[i, 2])
														{
															// red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3, y = cursory - 2; x <= redpieces[i, 1]; x += 3, y += 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx + 3, y = cursory + 2; x <= redpieces[i, 1]; x += 3, y += 2)
																{
																	if (j != indexofselectedpiece)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
														}

														if (cursorx == redpieces[i, 1] && cursory > redpieces[i, 2])
														{
															// red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int y = cursory; y >= redpieces[i, 2]; y -= 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int y = cursory - 2; y >= redpieces[indexofselectedpiece, 2]; y -= 2)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursorx == redpieces[i, 1] && cursory < redpieces[i, 2])
														{
															// red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int y = cursory; y <= redpieces[i, 2]; y += 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int y = cursory + 2; y <= redpieces[i, 2]; y += 2)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursory == redpieces[i, 2] && cursorx < redpieces[i, 1])
														{
															// red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx; x <= redpieces[i, 1]; x += 3)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx + 3; x <= redpieces[i, 1]; x += 3)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursory == redpieces[i, 2] && cursorx > redpieces[i, 1])
														{
															// red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx; x >= redpieces[i, 1]; x -= 3)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3; x >= redpieces[i, 1]; x -= 3)
																{

																	if (bluepieces[j, 0] != -1)
																	{
																		if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																		{
																			counter++;
																		}
																	}


																}
															}
														}
														if (counter == 0)
														{
															canMove = false;
														}
													}
												}
												if (redPiecetype == "K")
												{
													int redkingcoordinatex = -1, redkingcoordinatey = -1;
													// finding red king x , y coordinates
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														if (redpieces[i, 0] == 10)
														{
															redkingcoordinatex = redpieces[i, 1];
															redkingcoordinatey = redpieces[i, 2];
															break;
														}
													}

													if ((cursorx + 3 == redkingcoordinatex && cursory == redkingcoordinatey) ||
														(cursorx - 3 == redkingcoordinatex && cursory == redkingcoordinatey) ||
														(cursorx + 3 == redkingcoordinatex && cursory == redkingcoordinatey + 2) ||
														(cursorx + 3 == redkingcoordinatex && cursory == redkingcoordinatey - 2) ||
														(cursorx - 3 == redkingcoordinatex && cursory == redkingcoordinatey + 2) ||
														(cursorx - 3 == redkingcoordinatex && cursory == redkingcoordinatey - 2) ||
														(cursorx == redkingcoordinatex && cursory == redkingcoordinatey + 2) ||
														(cursorx == redkingcoordinatex && cursory == redkingcoordinatey - 2)
														)
													{
														canMove = false;
													}


												}

											}


											//
											if (bluepieces[indexofselectedpiece, 1] == cursorx && bluepieces[indexofselectedpiece, 2] == cursory)
											{
												didbluemove = false;
											}
											if (canMove)
											{
												bluepieces[indexofselectedpiece, 2] = cursory;
												bluepieces[indexofselectedpiece, 1] = cursorx;
												for (int i = 0; i < redpieces.GetLength(0); i++)
												{
													if (redpieces[i, 1] == cursorx && redpieces[i, 2] == cursory && redpieces[i, 0] != -1)
													{
														redpieces[i, 0] = -1;
														break;
													}
												}
												Console.Clear();
												Program.CreateBord();
												turn = "turnred";
											}
											else
											{
												didbluemove = false;
											}
											break;
										}
									}
								}
							} while (true);

							//!!!!!!!!!

							//blue king checked algorihtms
							if (true)
							{
								isbluekingchecked = false;
								int bluekingcoordinatex = -1, bluekingcoordinatey = -1;
								// finding blue king x , y coordinates
								for (int i = 0; i < bluepieces.GetLength(0); i++)
								{
									if (redpieces[i, 0] == 10)
									{
										bluekingcoordinatex = bluepieces[i, 1];
										bluekingcoordinatey = bluepieces[i, 2];
										break;
									}
								}


								// finding is king in danger 
								for (int i = 0; i < redpieces.GetLength(0); i++)
								{
									//getting enemy piece type
									string redPiecetype = "";
									if (redpieces[i, 0] != -1)
									{
										if (redpieces[i, 0] == 1)
										{
											redPiecetype = "P";
										}
										if (redpieces[i, 0] == 3)
										{
											redPiecetype = "H";
										}
										if (redpieces[i, 0] == 4)
										{
											redPiecetype = "B";
										}
										if (redpieces[i, 0] == 5)
										{
											redPiecetype = "R";
										}
										if (redpieces[i, 0] == 9)
										{
											redPiecetype = "Q";
										}
										if (redpieces[i, 0] == 10)
										{
											redPiecetype = "K";
										}
									}
									//
									if (redPiecetype == "P")
									{
										if ((redpieces[i, 1] + 3 == bluekingcoordinatex && redpieces[i, 2] + 2 == bluekingcoordinatey) || redpieces[i, 1] - 3 == bluekingcoordinatex && redpieces[i, 2] + 2 == bluekingcoordinatey)
										{
											isbluekingchecked = true;
										}
									}
									if (redPiecetype == "H")
									{
										if (
											(redpieces[i, 1] + 6 == bluekingcoordinatex && redpieces[i, 2] + 2 == bluekingcoordinatey)
										||
										(redpieces[i, 1] + 6 == bluekingcoordinatex && redpieces[i, 2] - 2 == bluekingcoordinatey)
										||
										(redpieces[i, 1] + 3 == bluekingcoordinatex && redpieces[i, 2] + 4 == bluekingcoordinatey)
										||
										(redpieces[i, 1] + 3 == bluekingcoordinatex && redpieces[i, 2] - 4 == bluekingcoordinatey)
										||
										(redpieces[i, 1] - 3 == bluekingcoordinatex && redpieces[i, 2] - 4 == bluekingcoordinatey)
										||
										(redpieces[i, 1] - 3 == bluekingcoordinatex && redpieces[i, 2] + 4 == bluekingcoordinatey)
										||
										(redpieces[i, 1] - 6 == bluekingcoordinatex && redpieces[i, 2] + 2 == bluekingcoordinatey)
										||
										(redpieces[i, 1] - 6 == bluekingcoordinatex && redpieces[i, 2] - 2 == bluekingcoordinatey)
											)
										{
											isbluekingchecked = true;
										}
									}
									if (redPiecetype == "B")
									{
										int counter = 0;
										if (Math.Abs(bluekingcoordinatex - redpieces[i, 1]) / 3 == Math.Abs(bluekingcoordinatey - redpieces[i, 2]) / 2)
										{

											if (bluekingcoordinatex > redpieces[i, 1] && bluekingcoordinatey > redpieces[i, 2])
											{
												//control red piece
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex, y = bluekingcoordinatey; x >= redpieces[i, 1]; x -= 3, y -= 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																{
																	counter++;
																}
															}
														}
													}
												}
												//conrorl blue pieces
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex - 3, y = bluekingcoordinatey - 2; x >= redpieces[i, 1]; x -= 3, y -= 2)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
															{
																counter++;
															}
														}

													}
												}

											}

											if (bluekingcoordinatex > redpieces[i, 1] && bluekingcoordinatey < redpieces[i, 2])
											{
												//red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex, y = bluekingcoordinatey; x >= redpieces[indexofselectedpiece, 1]; x -= 3, y += 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																{
																	counter++;
																}
															}
														}
													}
												}
												//blue piece contorl 
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex - 3, y = bluekingcoordinatey + 2; x >= redpieces[i, 1]; x -= 3, y += 2)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
															{
																counter++;
															}
														}

													}
												}
											}

											if (bluekingcoordinatex < bluepieces[i, 1] && bluekingcoordinatey > bluepieces[i, 2])
											{
												//red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex, y = bluekingcoordinatey; x <= redpieces[i, 1]; x += 3, y -= 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																{
																	counter++;
																}
															}
														}
													}
												}
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex + 3, y = bluekingcoordinatey - 2; x <= redpieces[i, 1]; x += 3, y -= 2)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
															{
																counter++;
															}
														}

													}
												}
											}

											if (bluekingcoordinatex < bluepieces[i, 1] && bluekingcoordinatey < bluepieces[i, 2])
											{
												//red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex, y = bluekingcoordinatey; x <= redpieces[i, 1]; x += 3, y += 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																{
																	counter++;
																}
															}
														}
													}
												}
												// red control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex + 3, y = bluekingcoordinatey + 2; x <= redpieces[i, 1]; x += 3, y += 2)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
															{
																counter++;
															}
														}

													}
												}
											}


											if (counter == 0)
											{
												isbluekingchecked=true;
											}
										}
									}
									if (redPiecetype == "R")
									{
										int counter = 0;
										if (bluekingcoordinatex == redpieces[i, 1] || bluekingcoordinatey == redpieces[i, 2])
										{
											if (bluekingcoordinatex == redpieces[i, 1] && bluekingcoordinatey > redpieces[i, 2])
											{
												// red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int y = bluekingcoordinatey; y >= redpieces[i, 2]; y -= 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 2] == y && redpieces[j, 1] == bluekingcoordinatex)
																{
																	counter++;
																}
															}

														}
													}
												}
												// blue piece control 
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int y = bluekingcoordinatey - 2; y >= redpieces[i, 2]; y -= 2)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 2] == y && bluepieces[j, 1] == bluekingcoordinatex)
															{
																counter++;
															}
														}


													}
												}
											}

											if (bluekingcoordinatex == redpieces[i, 1] && bluekingcoordinatey < redpieces[i, 2])
											{
												// red piece conter 
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int y = bluekingcoordinatey; y <= redpieces[i, 2]; y += 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 2] == y && redpieces[j, 1] == bluekingcoordinatex)
																{
																	counter++;
																}
															}

														}
													}
												}
												//blue piece counter 
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int y = bluekingcoordinatey + 2; y <= redpieces[i, 2]; y += 2)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 2] == y && bluepieces[j, 1] == bluekingcoordinatex)
															{
																counter++;
															}
														}


													}
												}
											}

											if (bluekingcoordinatey == redpieces[i, 2] && bluekingcoordinatex < redpieces[i, 1])
											{
												// red piece counter
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex; x <= redpieces[i, 1]; x += 3)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == bluekingcoordinatey)
																{
																	counter++;
																}
															}
														}
													}
												}
												// blue piece counter
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex + 3; x <= redpieces[i, 1]; x += 3)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 1] == x && bluepieces[j, 2] == bluekingcoordinatey)
															{
																counter++;
															}
														}

													}
												}
											}

											if (bluekingcoordinatey == redpieces[i, 2] && bluekingcoordinatex > redpieces[i, 1])
											{
												// red piece counter
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex; x >= redpieces[i, 1]; x -= 3)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == bluekingcoordinatey)
																{
																	counter++;
																}
															}
														}
													}
												}
												// blue piece counter 
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex - 3; x >= redpieces[i, 1]; x -= 3)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 1] == x && bluepieces[j, 2] == bluekingcoordinatey)
															{
																counter++;
															}
														}

													}
												}
											}
											if (counter == 0)
											{
												isbluekingchecked = true;
											}
										}

									}
									if (redPiecetype == "Q")
									{
										int counter = 0;
										if (bluekingcoordinatex == redpieces[i, 1] || bluekingcoordinatey == redpieces[i, 2] || Math.Abs(redpieces[i, 1] - bluekingcoordinatex) / 3 == Math.Abs(redpieces[i, 2] - bluekingcoordinatey) / 2)
										{
											if (bluekingcoordinatex > redpieces[i, 1] && bluekingcoordinatey > redpieces[i, 2])
											{
												// red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex, y = bluekingcoordinatey; x >= redpieces[i, 1]; x -= 3, y -= 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																{
																	counter++;
																}
															}
														}
													}
												}
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex - 3, y = bluekingcoordinatey - 2; x >= redpieces[i, 1]; x -= 3, y -= 2)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
															{
																counter++;
															}
														}

													}
												}
											}

											if (bluekingcoordinatex > redpieces[i, 1] && bluekingcoordinatey < redpieces[i, 2])
											{
												//red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex, y = bluekingcoordinatey; x >= redpieces[i, 1]; x -= 3, y += 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																{
																	counter++;
																}
															}

														}
													}
												}
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex - 3, y = bluekingcoordinatey + 2; x >= redpieces[i, 1]; x -= 3, y += 2)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
															{
																counter++;
															}
														}


													}
												}
											}

											if (bluekingcoordinatex < redpieces[i, 1] && bluekingcoordinatey > redpieces[i, 2])
											{
												// red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex, y = bluekingcoordinatey; x <= redpieces[i, 1]; x += 3, y -= 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																{
																	counter++;
																}
															}

														}
													}
												}
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex + 3, y = bluekingcoordinatey - 2; x <= redpieces[i, 1]; x += 3, y -= 2)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
															{
																counter++;
															}
														}


													}
												}
											}

											if (bluekingcoordinatex < redpieces[i, 1] && bluekingcoordinatey < redpieces[i, 2])
											{
												// red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex - 3, y = bluekingcoordinatey - 2; x <= redpieces[i, 1]; x += 3, y += 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																{
																	counter++;
																}
															}

														}
													}
												}
												// blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex + 3, y = bluekingcoordinatey + 2; x <= redpieces[i, 1]; x += 3, y += 2)
													{
														if (j != indexofselectedpiece)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																{
																	counter++;
																}
															}

														}
													}
												}
											}

											if (bluekingcoordinatex == redpieces[i, 1] && bluekingcoordinatey > redpieces[i, 2])
											{
												// red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int y = bluekingcoordinatey; y >= redpieces[i, 2]; y -= 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 2] == y && redpieces[j, 1] == bluekingcoordinatex)
																{
																	counter++;
																}
															}

														}
													}
												}
												// blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int y = bluekingcoordinatey - 2; y >= redpieces[indexofselectedpiece, 2]; y -= 2)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 2] == y && bluepieces[j, 1] == bluekingcoordinatex)
															{
																counter++;
															}
														}


													}
												}
											}

											if (bluekingcoordinatex == redpieces[i, 1] && bluekingcoordinatey < redpieces[i, 2])
											{
												// red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int y = bluekingcoordinatey; y <= redpieces[i, 2]; y += 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 2] == y && redpieces[j, 1] == bluekingcoordinatex)
																{
																	counter++;
																}
															}

														}
													}
												}
												// blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int y = bluekingcoordinatey + 2; y <= redpieces[i, 2]; y += 2)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 2] == y && bluepieces[j, 1] == bluekingcoordinatex)
															{
																counter++;
															}
														}


													}
												}
											}

											if (bluekingcoordinatey == redpieces[i, 2] && bluekingcoordinatex < redpieces[i, 1])
											{
												// red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex; x <= redpieces[i, 1]; x += 3)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == bluekingcoordinatey)
																{
																	counter++;
																}
															}

														}
													}
												}
												// blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex + 3; x <= redpieces[i, 1]; x += 3)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 1] == x && bluepieces[j, 2] == bluekingcoordinatey)
															{
																counter++;
															}
														}


													}
												}
											}

											if (bluekingcoordinatey == redpieces[i, 2] && bluekingcoordinatex > redpieces[i, 1])
											{
												// red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex; x >= redpieces[i, 1]; x -= 3)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == bluekingcoordinatey)
																{
																	counter++;
																}
															}

														}
													}
												}
												// blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = bluekingcoordinatex - 3; x >= redpieces[i, 1]; x -= 3)
													{

														if (bluepieces[j, 0] != -1)
														{
															if (bluepieces[j, 1] == x && bluepieces[j, 2] == bluekingcoordinatey)
															{
																counter++;
															}
														}


													}
												}
											}
											if (counter == 0)
											{
												isbluekingchecked = true;
											}
										}

									}
									

								}
							}
							;
							if (isbluekingchecked)
							{

								bluepieces[indexofselectedpiece, 1] = tempx;
								bluepieces[indexofselectedpiece, 2] = tempy;
								turn = "turnblue";
							}
							if (!isbluekingchecked)
							{
								if (!didbluemove)
									turn = "turnblue";
								else
								{
									turn = "turnred";
									goback_counter++;
								}
							}

							

							//turn blue end
						}

						if (goback_counter >= 1)
						{
							continue;
						}


						//red turn
						if (turn == "turnred")
						{
							int indexofselectedpiece = -1;
							string piecetype = "";
							int tempx = -1 ,tempy = -1;
							bool didredmove = true;
							for (int i = 0; i < redpieces.GetLength(0); i++)
							{
								if (redpieces[i, 1] == cursorx && redpieces[i, 2] == cursory && redpieces[i, 0] != -1)
								{
									indexofselectedpiece = i; break;
								}
							}

							if (indexofselectedpiece < 0 || redpieces[indexofselectedpiece, 0] == -1)
								continue;


							tempx = redpieces[indexofselectedpiece, 1];
							tempy = redpieces[indexofselectedpiece, 2];

							if (redpieces[indexofselectedpiece, 0] == 1)
								piecetype = "P";
							if (redpieces[indexofselectedpiece, 0] == 3)
								piecetype = "H";
							if (redpieces[indexofselectedpiece, 0] == 4)
								piecetype = "B";
							if (redpieces[indexofselectedpiece, 0] == 5)
								piecetype = "R";
							if (redpieces[indexofselectedpiece, 0] == 9)
								piecetype = "Q";
							if (redpieces[indexofselectedpiece, 0] == 10)
								piecetype = "K";

							//Console.Clear();
							//Console.WriteLine(piecetype);

							do
							{
								Console.SetCursorPosition(cursorx, cursory);
								ckey = Console.ReadKey(true);
								if (!Console.KeyAvailable)
								{
									if (ckey.Key == ConsoleKey.UpArrow && cursory > 2)
									{
										cursory -= 2;
										continue;
									}
									if (ckey.Key == ConsoleKey.DownArrow && cursory < 16)
									{
										cursory += 2;
										continue;
									}
									if (ckey.Key == ConsoleKey.LeftArrow && cursorx > 3)
									{
										cursorx -= 3;
										continue;
									}
									if (ckey.Key == ConsoleKey.RightArrow && cursorx < 24)
									{
										cursorx += 3;
										continue;
									}
									if (ckey.Key == ConsoleKey.Enter)
									{
										if (piecetype == "P")
										{
											bool canMove = true;
											bool canMakeStarterMove = true;
											bool canMoveDiagonalLeft = false, canMoveDiagonalRight = false;
											for (int i = 0; i < redpieces.GetLength(0); i++)
											{
												if (redpieces[i, 0] != -1)
												{
													if (i != indexofselectedpiece && (redpieces[indexofselectedpiece, 1] == redpieces[i, 1] && redpieces[indexofselectedpiece, 2] + 2 == redpieces[i, 2]))
													{
														canMove = false;
													}
												}
											}
											if (redpieces[indexofselectedpiece, 2] == 4)
											{
												for (int i = 0; i < redpieces.GetLength(0); i++)
												{
													if (redpieces[i, 0] != -1)
													{
														if (i != indexofselectedpiece && (redpieces[indexofselectedpiece, 1] == redpieces[i, 1] && redpieces[indexofselectedpiece, 2] + 4 == redpieces[i, 2]))
														{
															canMakeStarterMove = false;
														}
													}
												}
											}
											for (int i = 0; i < bluepieces.GetLength(0); i++)
											{
												if (bluepieces[i, 0] != -1)
												{
													if ((redpieces[indexofselectedpiece, 1] == bluepieces[i, 1]) && (redpieces[indexofselectedpiece, 2] + 2 == bluepieces[i, 2]))
													{
														canMove = false;
													}
												}
											}

											if (redpieces[indexofselectedpiece, 2] == 4)
											{
												for (int i = 0; i < redpieces.GetLength(0); i++)
												{
													if (redpieces[i, 0] != -1)
													{
														if ((redpieces[indexofselectedpiece, 1] == redpieces[i, 1]) && (redpieces[indexofselectedpiece, 2] + 4 == redpieces[i, 2] || redpieces[indexofselectedpiece, 2] + 2 == redpieces[i, 2]))
														{
															canMakeStarterMove = false;
														}
														if ((redpieces[indexofselectedpiece, 1] == bluepieces[i, 1]) && (redpieces[indexofselectedpiece, 2] + 4 == bluepieces[i, 2] || redpieces[indexofselectedpiece, 2] + 2 == bluepieces[i, 2]))
														{
															canMakeStarterMove = false;
														}
													}
												}
											}
											if (redpieces[indexofselectedpiece, 2] != 4)
											{
												canMakeStarterMove = false;
											}
											//diagonal move calculator
											for (int i = 0; i < bluepieces.GetLength(0); i++)
											{
												if (bluepieces[i, 0] != -1)
												{
													if (bluepieces[i, 1] == redpieces[indexofselectedpiece, 1] - 3 && bluepieces[i, 2] == redpieces[indexofselectedpiece, 2] + 2)
													{
														canMoveDiagonalLeft = true;
													}
													if (bluepieces[i, 1] == redpieces[indexofselectedpiece, 1] + 3 && bluepieces[i, 2] == redpieces[indexofselectedpiece, 2] + 2)
													{
														canMoveDiagonalRight = true;
													}
												}
											}
											//
											if (redpieces[indexofselectedpiece, 1] == cursorx && redpieces[indexofselectedpiece, 2] == cursory)
											{
												didredmove = false;
											}
											if (canMove && ((cursory == redpieces[indexofselectedpiece, 2] + 2) && (cursorx == redpieces[indexofselectedpiece, 1])))
											{
												redpieces[indexofselectedpiece, 2] = cursory;
												Console.Clear();
												Program.CreateBord();
												turn = "turnblue";
											}
											if (canMakeStarterMove && ((cursory == redpieces[indexofselectedpiece, 2] + 4) && (cursorx == redpieces[indexofselectedpiece, 1])))
											{
												redpieces[indexofselectedpiece, 2] = cursory;
												Console.Clear();
												Program.CreateBord();
												turn = "turnblue";
											}
											if (canMoveDiagonalLeft && ((cursory == redpieces[indexofselectedpiece, 2] + 2) && (cursorx == redpieces[indexofselectedpiece, 1] - 3)))
											{
												redpieces[indexofselectedpiece, 2] = cursory;
												redpieces[indexofselectedpiece, 1] = cursorx;
												for (int i = 0; i < redpieces.GetLength(0); i++)
												{
													if (bluepieces[i, 1] == cursorx && bluepieces[i, 2] == cursory && bluepieces[i, 0] != -1)
													{
														bluepieces[i, 0] = -1;
														break;
													}
												}
												Console.Clear();
												Program.CreateBord();
												turn = "turnblue";
											}
											if (canMoveDiagonalRight && ((cursory == redpieces[indexofselectedpiece, 2] + 2) && (cursorx == redpieces[indexofselectedpiece, 1] + 3)))
											{
												redpieces[indexofselectedpiece, 2] = cursory;
												redpieces[indexofselectedpiece, 1] = cursorx;
												for (int i = 0; i < bluepieces.GetLength(0); i++)
												{
													if (bluepieces[i, 1] == cursorx && bluepieces[i, 2] == cursory && bluepieces[i, 0] != -1)
													{
														bluepieces[i, 0] = -1;
														break;
													}
												}
												if (cursory == 16)
												{
													redpieces[indexofselectedpiece, 0] = 9;
												}
												Console.Clear();
												Program.CreateBord();
												turn = "turnblue";
											}
											break;
										}
										if (piecetype == "H")
										{
											bool canMove = true;
											if (
													(redpieces[indexofselectedpiece, 1] + 6 == cursorx && redpieces[indexofselectedpiece, 2] + 2 == cursory)
													||
													(redpieces[indexofselectedpiece, 1] + 6 == cursorx && redpieces[indexofselectedpiece, 2] - 2 == cursory)
													||
													(redpieces[indexofselectedpiece, 1] + 3 == cursorx && redpieces[indexofselectedpiece, 2] + 4 == cursory)
													||
													(redpieces[indexofselectedpiece, 1] + 3 == cursorx && redpieces[indexofselectedpiece, 2] - 4 == cursory)
													||
													(redpieces[indexofselectedpiece, 1] - 3 == cursorx && redpieces[indexofselectedpiece, 2] - 4 == cursory)
													||
													(redpieces[indexofselectedpiece, 1] - 3 == cursorx && redpieces[indexofselectedpiece, 2] + 4 == cursory)
													||
													(redpieces[indexofselectedpiece, 1] - 6 == cursorx && redpieces[indexofselectedpiece, 2] + 2 == cursory)
													||
													(redpieces[indexofselectedpiece, 1] - 6 == cursorx && redpieces[indexofselectedpiece, 2] - 2 == cursory)
													)
											{
												for (int i = 0; i < redpieces.GetLength(0); i++)
												{
													if (redpieces[i, 0] != -1)
													{
														if (redpieces[i, 1] == cursorx && redpieces[i, 2] == cursory)
														{
															canMove = false;
														}
													}
												}
												if (canMove)
												{
													redpieces[indexofselectedpiece, 2] = cursory;
													redpieces[indexofselectedpiece, 1] = cursorx;
													for (int i = 0; i < bluepieces.GetLength(0); i++)
													{
														if (bluepieces[i, 1] == cursorx && bluepieces[i, 2] == cursory && bluepieces[i, 0] != -1)
														{
															bluepieces[i, 0] = -1;
															break;
														}
													}
													Console.Clear();
													Program.CreateBord();
													turn = "turnblue";
												}
											}
											else
											{
												didredmove = false;
											}
											break;
										}
										if (piecetype == "B")
										{
											bool canMove = true;
											int counter = 0;
											if (Math.Abs(redpieces[indexofselectedpiece, 1] - cursorx) / 3 == Math.Abs(redpieces[indexofselectedpiece, 2] - cursory) / 2)
											{
												
												if (cursorx > redpieces[indexofselectedpiece, 1] && cursory > redpieces[indexofselectedpiece, 2])
												{
													// red calculator
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x >= redpieces[indexofselectedpiece, 1]; x -= 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// blue calculator
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx - 3, y = cursory - 2; x >= redpieces[indexofselectedpiece, 1]; x -= 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx > redpieces[indexofselectedpiece, 1] && cursory < redpieces[indexofselectedpiece, 2])
												{
													// red calcuator
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x >= redpieces[indexofselectedpiece, 1]; x -= 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}
															}
														}
													}
													// blue calculator
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx - 3, y = cursory + 2; x >= redpieces[indexofselectedpiece, 1]; x -= 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		counter++;
																	}
																}
															}
														}
													}
												}

												if (cursorx < redpieces[indexofselectedpiece, 1] && cursory > redpieces[indexofselectedpiece, 2])
												{
													// red calculator
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x <= redpieces[indexofselectedpiece, 1]; x += 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// blue calculator
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3, y = cursory - 2; x <= redpieces[indexofselectedpiece, 1]; x += 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx < redpieces[indexofselectedpiece, 1] && cursory < redpieces[indexofselectedpiece, 2])
												{
													// red calculator
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x <= redpieces[indexofselectedpiece, 1]; x += 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// blue calculatoe
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3, y = cursory + 2; x <= redpieces[indexofselectedpiece, 1]; x += 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}
											}
											else
											{
												canMove = false;
											}
											if (redpieces[indexofselectedpiece, 1] == cursorx && redpieces[indexofselectedpiece, 2] == cursory)
											{
												didredmove = false;
											}
											if (canMove && counter == 0)
											{
												redpieces[indexofselectedpiece, 2] = cursory;
												redpieces[indexofselectedpiece, 1] = cursorx;
												for (int i = 0; i < bluepieces.GetLength(0); i++)
												{
													if (bluepieces[i, 1] == cursorx && bluepieces[i, 2] == cursory && bluepieces[i, 0] != -1)
													{
														bluepieces[i, 0] = -1;
														break;
													}
												}
												Console.Clear();
												Program.CreateBord();
												turn = "turnblue";
											}
											break;
										}
										if (piecetype == "R")
										{
											bool canMove = true;
											int counter = 0;
											if (cursorx == redpieces[indexofselectedpiece, 1] || cursory == redpieces[indexofselectedpiece, 2])
											{
												if (cursorx == redpieces[indexofselectedpiece, 1] && cursory > redpieces[indexofselectedpiece, 2])
												{
													// red calculator
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int y = cursory; y >= redpieces[indexofselectedpiece, 2]; y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													//blue calculator
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int y = cursory - 2; y >= redpieces[indexofselectedpiece, 2]; y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx == redpieces[indexofselectedpiece, 1] && cursory < redpieces[indexofselectedpiece, 2])
												{
													// red calculator
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int y = cursory; y <= redpieces[indexofselectedpiece, 2]; y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// blue calculator
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int y = cursory + 2; y <= redpieces[indexofselectedpiece, 2]; y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursory == redpieces[indexofselectedpiece, 2] && cursorx < redpieces[indexofselectedpiece, 1])
												{
													// red calculator
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx; x <= redpieces[indexofselectedpiece, 1]; x += 3)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// blue calculator
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3; x <= redpieces[indexofselectedpiece, 1]; x += 3)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursory == redpieces[indexofselectedpiece, 2] && cursorx > redpieces[indexofselectedpiece, 1])
												{
													// red calculator
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx - 3; x >= redpieces[indexofselectedpiece, 1]; x -= 3)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// blue calculator 
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx; x >= bluepieces[indexofselectedpiece, 1]; x -= 3)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}
											}
											else
											{
												canMove = false;
											}
											if (redpieces[indexofselectedpiece, 1] == cursorx && redpieces[indexofselectedpiece, 2] == cursory)
											{
												didredmove = false;
											}

											if (canMove && counter == 0)
											{
												redpieces[indexofselectedpiece, 2] = cursory;
												redpieces[indexofselectedpiece, 1] = cursorx;
												for (int i = 0; i < bluepieces.GetLength(0); i++)
												{
													if (bluepieces[i, 1] == cursorx && bluepieces[i, 2] == cursory && bluepieces[i, 0] != -1)
													{
														bluepieces[i, 0] = -1;
														break;
													}
												}
												Console.Clear();
												Program.CreateBord();
												turn = "turnblue";
											}
											break;
										}
										if (piecetype == "Q")
										{
											bool canMove = true;
											int counter = 0;
											if (cursorx == redpieces[indexofselectedpiece, 1] || cursory == redpieces[indexofselectedpiece, 2] || Math.Abs(redpieces[indexofselectedpiece, 1] - cursorx) / 3 == Math.Abs(redpieces[indexofselectedpiece, 2] - cursory) / 2)
											{
												if (cursorx > redpieces[indexofselectedpiece, 1] && cursory > redpieces[indexofselectedpiece, 2])
												{
													//control red
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x >= redpieces[indexofselectedpiece, 1]; x -= 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// control blue 
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx - 3, y = cursory - 2; x >= redpieces[indexofselectedpiece, 1]; x -= 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx > redpieces[indexofselectedpiece, 1] && cursory < redpieces[indexofselectedpiece, 2])
												{
													// control red
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x >= redpieces[indexofselectedpiece, 1]; x -= 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// control blue
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx - 3, y = cursory + 2; x >= redpieces[indexofselectedpiece, 1]; x -= 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx < redpieces[indexofselectedpiece, 1] && cursory > redpieces[indexofselectedpiece, 2])
												{
													// control red
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x <= redpieces[indexofselectedpiece, 1]; x += 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// control blue
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3, y = cursory - 2; x <= redpieces[indexofselectedpiece, 1]; x += 3, y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx < redpieces[indexofselectedpiece, 1] && cursory < redpieces[indexofselectedpiece, 2])
												{
													// control red
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx, y = cursory; x <= redpieces[indexofselectedpiece, 1]; x += 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// contorl blue 
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3, y = cursory + 2; x <= redpieces[indexofselectedpiece, 1]; x += 3, y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx == redpieces[indexofselectedpiece, 1] && cursory > redpieces[indexofselectedpiece, 2])
												{
													// red counter
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int y = cursory; y >= redpieces[indexofselectedpiece, 2]; y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// blue conter
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int y = cursory - 2; y >= redpieces[indexofselectedpiece, 2]; y -= 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursorx == redpieces[indexofselectedpiece, 1] && cursory < redpieces[indexofselectedpiece, 2])
												{
													// blue conter 
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int y = cursory; y <= redpieces[indexofselectedpiece, 2]; y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// red counter
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int y = cursory + 2; y <= redpieces[indexofselectedpiece, 2]; y += 2)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursory == redpieces[indexofselectedpiece, 2] && cursorx < redpieces[indexofselectedpiece, 1])
												{
													// red counter
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx; x <= redpieces[indexofselectedpiece, 1]; x += 3)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// blue counter
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx + 3; x <= redpieces[indexofselectedpiece, 1]; x += 3)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

												if (cursory == redpieces[indexofselectedpiece, 2] && cursorx > redpieces[indexofselectedpiece, 1])
												{
													// red counter
													for (int j = 0; j < redpieces.GetLength(0); j++)
													{
														for (int x = cursorx; x >= redpieces[indexofselectedpiece, 1]; x -= 3)
														{
															if (j != indexofselectedpiece)
															{
																if (redpieces[j, 0] != -1)
																{
																	if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																	{
																		canMove = false;
																	}
																}

															}
														}
													}
													// blue counter
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														for (int x = cursorx - 3; x >= redpieces[indexofselectedpiece, 1]; x -= 3)
														{
															if (j != indexofselectedpiece)
															{
																if (bluepieces[j, 0] != -1)
																{
																	if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																	{
																		counter++;
																	}
																}

															}
														}
													}
												}

											}
											else
											{
												canMove = false;
											}
											if (redpieces[indexofselectedpiece, 1] == cursorx && redpieces[indexofselectedpiece, 2] == cursory)
											{
												didredmove = false;
											}
											if (canMove && counter == 0)
											{
												redpieces[indexofselectedpiece, 2] = cursory;
												redpieces[indexofselectedpiece, 1] = cursorx;
												for (int i = 0; i < bluepieces.GetLength(0); i++)
												{
													if (bluepieces[i, 1] == cursorx && bluepieces[i, 2] == cursory && bluepieces[i, 0] != -1)
													{
														bluepieces[i, 0] = -1;
														break;
													}
												}
												Console.Clear();
												Program.CreateBord();
												turn = "turnblue";
											}
											break;
										}
										if (piecetype == "K")
										{
											bool canMove = true;
											if (!(Math.Abs(redpieces[indexofselectedpiece, 1] - cursorx) <= 3 && Math.Abs(redpieces[indexofselectedpiece, 2] - cursory) <= 2))
											{
												canMove = false;
											}
											for (int i = 0; i < redpieces.GetLength(0); i++)
											{
												if (redpieces[i, 0] != -1)
												{
													if (redpieces[i, 1] == cursorx && redpieces[i, 2] == cursory)
													{
														canMove = false;
													}
												}
											}
											// finding king can eate piece 
											for (int i = 0; i < bluepieces.GetLength(0); i++)
											{
												//getting enemy piece type
												string bluePiecetype = "";
												if (bluepieces[i, 0] != -1)
												{
													if (bluepieces[i, 0] == 1)
													{
														bluePiecetype = "P";
													}
													if (bluepieces[i, 0] == 3)
													{
														bluePiecetype = "H";
													}
													if (bluepieces[i, 0] == 4)
													{
														bluePiecetype = "B";
													}
													if (bluepieces[i, 0] == 5)
													{
														bluePiecetype = "R";
													}
													if (bluepieces[i, 0] == 9)
													{
														bluePiecetype = "Q";
													}
													if (bluepieces[i, 0] == 10)
													{
														bluePiecetype = "K";
													}
												}
												//
												if (bluePiecetype == "P")
												{
													if ((bluepieces[i, 1] + 3 == cursorx && bluepieces[i, 2] - 2 == cursory) || bluepieces[i, 1] - 3 == cursorx && bluepieces[i, 2] - 2 == cursory)
													{
														canMove = false;
													}
												}
												if (bluePiecetype == "H")
												{
													if (
														(bluepieces[i, 1] + 6 == cursorx && bluepieces[i, 2] + 2 == cursory)
													||
													(bluepieces[i, 1] + 6 == cursorx && bluepieces[i, 2] - 2 == cursory)
													||
													(bluepieces[i, 1] + 3 == cursorx && bluepieces[i, 2] + 4 == cursory)
													||
													(bluepieces[i, 1] + 3 == cursorx && bluepieces[i, 2] - 4 == cursory)
													||
													(bluepieces[i, 1] - 3 == cursorx && bluepieces[i, 2] - 4 == cursory)
													||
													(bluepieces[i, 1] - 3 == cursorx && bluepieces[i, 2] + 4 == cursory)
													||
													(bluepieces[i, 1] - 6 == cursorx && bluepieces[i, 2] + 2 == cursory)
													||
													(bluepieces[i, 1] - 6 == cursorx && bluepieces[i, 2] - 2 == cursory)
														)
													{
														canMove = false;
													}
												}
												if (bluePiecetype == "B")
												{
													int counter = 0;
													if (Math.Abs(cursorx - bluepieces[i, 1]) / 3 == Math.Abs(cursory - bluepieces[i, 2]) / 2)
													{
														if (cursorx == bluepieces[i, 1] && cursory == bluepieces[i, 2])
														{
															counter++;
														}
														if (cursorx > bluepieces[i, 1] && cursory > bluepieces[i, 2])
														{
															//control blue piece
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x >= bluepieces[i, 1]; x -= 3, y -= 2)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}
																	}
																}
															}
															//conrorl red pieces
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3, y = cursory - 2; x >= bluepieces[i, 1]; x -= 3, y -= 2)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}

																}
															}

														}

														if (cursorx > bluepieces[i, 1] && cursory < bluepieces[i, 2])
														{
															//blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x >= bluepieces[i, 1]; x -= 3, y += 2)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}
																	}
																}
															}
															//red piece contorl 
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3, y = cursory + 2; x >= bluepieces[i, 1]; x -= 3, y += 2)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}

																}
															}
														}

														if (cursorx < bluepieces[i, 1] && cursory > bluepieces[i, 2])
														{
															//blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x <= bluepieces[i, 1]; x += 3, y -= 2)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}
																	}
																}
															}
															//red  piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx + 3, y = cursory - 2; x <= bluepieces[i, 1]; x += 3, y -= 2)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}

																}
															}
														}

														if (cursorx < bluepieces[i, 1] && cursory < bluepieces[i, 2])
														{
															//blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x <= bluepieces[i, 1]; x += 3, y += 2)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																			{
																				canMove = false;
																			}
																		}
																	}
																}
															}
															// red control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx + 3, y = cursory + 2; x <= bluepieces[i, 1]; x += 3, y += 2)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}

																}
															}
														}


														if (counter == 0)
														{
															canMove = false;
														}
													}
												}
												if (bluePiecetype == "R")
												{
													int counter = 0;
													if (cursorx == bluepieces[i, 1] || cursory == bluepieces[i, 2])
													{
														if (cursorx == bluepieces[i, 1] && cursory == bluepieces[i, 2])
														{
															counter++;
														}
														if (cursorx == bluepieces[i, 1] && cursory > bluepieces[i, 2])
														{
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int y = cursory; y >= redpieces[i, 2]; y -= 2)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															// red piece control 
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int y = cursory - 2; y >= bluepieces[i, 2]; y -= 2)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursorx == bluepieces[i, 1] && cursory < bluepieces[i, 2])
														{
															// red piece conter 
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int y = cursory; y <= bluepieces[i, 2]; y += 2)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															//blue piece counter 
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int y = cursory + 2; y <= bluepieces[i, 2]; y += 2)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursory == bluepieces[i, 2] && cursorx < bluepieces[i, 1])
														{
															// blue piece counter
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx; x <= bluepieces[i, 1]; x += 3)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																			{
																				counter++;
																			}
																		}
																	}
																}
															}
															// red piece counter
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx + 3; x <= bluepieces[i, 1]; x += 3)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																		{
																			counter++;
																		}
																	}

																}
															}
														}

														if (cursory == redpieces[i, 2] && cursorx > redpieces[i, 1])
														{
															// blue piece counter
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx; x >= bluepieces[i, 1]; x -= 3)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																			{
																				counter++;
																			}
																		}
																	}
																}
															}
															// red piece counter 
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3; x >= bluepieces[i, 1]; x -= 3)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																		{
																			counter++;
																		}
																	}

																}
															}
														}
														if (counter == 0)
														{
															canMove = false;
														}
													}


												}
												if (bluePiecetype == "Q")
												{
													int counter = 0;
													if (cursorx == bluepieces[i, 1] || cursory == bluepieces[i, 2] || Math.Abs(bluepieces[i, 1] - cursorx) / 3 == Math.Abs(bluepieces[i, 2] - cursory) / 2)
													{
														if (cursorx == bluepieces[i, 1] && cursory == bluepieces[i, 2])
														{
															counter++;
														}
														if (cursorx > bluepieces[i, 1] && cursory > bluepieces[i, 2])
														{
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x >= bluepieces[i, 1]; x -= 3, y -= 2)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}
																	}
																}
															}
															//red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3, y = cursory - 2; x >= bluepieces[i, 1]; x -= 3, y -= 2)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}

																}
															}
														}

														if (cursorx > bluepieces[i, 1] && cursory < bluepieces[i, 2])
														{
															//blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x >= bluepieces[i, 1]; x -= 3, y += 2)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															//red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3, y = cursory + 2; x >= bluepieces[i, 1]; x -= 3, y += 2)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursorx < bluepieces[i, 1] && cursory > bluepieces[i, 2])
														{
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx, y = cursory; x <= bluepieces[i, 1]; x += 3, y -= 2)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															//blue piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx + 3, y = cursory - 2; x <= bluepieces[i, 1]; x += 3, y -= 2)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursorx < bluepieces[i, 1] && cursory < bluepieces[i, 2])
														{
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3, y = cursory - 2; x <= bluepieces[i, 1]; x += 3, y += 2)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															// red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx + 3, y = cursory + 2; x <= bluepieces[i, 1]; x += 3, y += 2)
																{
																	if (j != i)
																	{
																		if (redpieces[j, 0] != -1)
																		{
																			if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
														}

														if (cursorx == bluepieces[i, 1] && cursory > bluepieces[i, 2])
														{
															// red piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int y = cursory; y >= bluepieces[i, 2]; y -= 2)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															// blue piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int y = cursory - 2; y >= bluepieces[i, 2]; y -= 2)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursorx == bluepieces[i, 1] && cursory < bluepieces[i, 2])
														{
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int y = cursory; y <= bluepieces[i, 2]; y += 2)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 2] == y && bluepieces[j, 1] == cursorx)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															// red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int y = cursory + 2; y <= bluepieces[i, 2]; y += 2)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 2] == y && redpieces[j, 1] == cursorx)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursory == bluepieces[i, 2] && cursorx < bluepieces[i, 1])
														{
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx; x <= bluepieces[i, 1]; x += 3)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															// red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx + 3; x <= bluepieces[i, 1]; x += 3)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																		{
																			counter++;
																		}
																	}


																}
															}
														}

														if (cursory == bluepieces[i, 2] && cursorx > bluepieces[i, 1])
														{
															// blue piece control
															for (int j = 0; j < bluepieces.GetLength(0); j++)
															{
																for (int x = cursorx; x >= bluepieces[i, 1]; x -= 3)
																{
																	if (j != i)
																	{
																		if (bluepieces[j, 0] != -1)
																		{
																			if (bluepieces[j, 1] == x && bluepieces[j, 2] == cursory)
																			{
																				counter++;
																			}
																		}

																	}
																}
															}
															// red piece control
															for (int j = 0; j < redpieces.GetLength(0); j++)
															{
																for (int x = cursorx - 3; x >= bluepieces[i, 1]; x -= 3)
																{

																	if (redpieces[j, 0] != -1)
																	{
																		if (redpieces[j, 1] == x && redpieces[j, 2] == cursory)
																		{
																			counter++;
																		}
																	}


																}
															}
														}
														if (counter == 0)
														{
															canMove = false;
														}
													}
												}
												if (bluePiecetype == "K")
												{
													int bluekingcoordinatex = -1, bluekingcoordinatey = -1;
													// finding red king x , y coordinates
													for (int j = 0; j < bluepieces.GetLength(0); j++)
													{
														if (bluepieces[i, 0] == 10)
														{
															bluekingcoordinatex = bluepieces[i, 1];
															bluekingcoordinatey = bluepieces[i, 2];
															break;
														}
													}

													if ((cursorx + 3 == bluekingcoordinatex && cursory == bluekingcoordinatey) ||
														(cursorx - 3 == bluekingcoordinatex && cursory == bluekingcoordinatey) ||
														(cursorx + 3 == bluekingcoordinatex && cursory == bluekingcoordinatey + 2) ||
														(cursorx + 3 == bluekingcoordinatex && cursory == bluekingcoordinatey - 2) ||
														(cursorx - 3 == bluekingcoordinatex && cursory == bluekingcoordinatey + 2) ||
														(cursorx - 3 == bluekingcoordinatex && cursory == bluekingcoordinatey - 2) ||
														(cursorx == bluekingcoordinatex && cursory == bluekingcoordinatey + 2) ||
														(cursorx == bluekingcoordinatex && cursory == bluekingcoordinatey - 2)
														)
													{
														canMove = false;
													}


												}

											}

											if (redpieces[indexofselectedpiece, 1] == cursorx && redpieces[indexofselectedpiece, 2] == cursory)
											{
												didredmove = false;
											}

											if (canMove)
											{
												redpieces[indexofselectedpiece, 2] = cursory;
												redpieces[indexofselectedpiece, 1] = cursorx;
												for (int i = 0; i < bluepieces.GetLength(0); i++)
												{
													if (bluepieces[i, 1] == cursorx && bluepieces[i, 2] == cursory && bluepieces[i, 0] != -1)
													{
														bluepieces[i, 0] = -1;
														break;
													}
												}
												Console.Clear();
												Program.CreateBord();
												turn = "turnblue";
											}
											else
											{
												didredmove = false;
											}
											break;
										}
									
									}
								}
							} while (true);
							
							//red king checked algorihtms
							if (true)
							{
								isredkingchecked = false;
								int redkingcoordinatex = -1, redkingcoordinatey = -1;
								// finding red king x , y coordinates
								for (int i = 0; i < redpieces.GetLength(0); i++)
								{
									if (redpieces[i, 0] == 10)
									{
										redkingcoordinatex = redpieces[i, 1];
										redkingcoordinatey = redpieces[i, 2];
										break;
									}
								}


								// finding is king in danger 
								for (int i = 0; i < bluepieces.GetLength(0); i++)
								{
									//getting enemy piece type
									string bluePiecetype = "";
									if (bluepieces[i, 0] != -1)
									{
										if (bluepieces[i, 0] == 1)
										{
											bluePiecetype = "P";
										}
										if (bluepieces[i, 0] == 3)
										{
											bluePiecetype = "H";
										}
										if (bluepieces[i, 0] == 4)
										{
											bluePiecetype = "B";
										}
										if (bluepieces[i, 0] == 5)
										{
											bluePiecetype = "R";
										}
										if (bluepieces[i, 0] == 9)
										{
											bluePiecetype = "Q";
										}
										if (bluepieces[i, 0] == 10)
										{
											bluePiecetype = "K";
										}
									}
									//
									if (bluePiecetype == "P")
									{
										if ((bluepieces[i, 1] + 3 == redkingcoordinatex && bluepieces[i, 2] - 2 == redkingcoordinatey) || bluepieces[i, 1] - 3 == redkingcoordinatex && bluepieces[i, 2] - 2 == redkingcoordinatey)
										{
											isredkingchecked = true;
										}
									}
									if (bluePiecetype == "H")
									{
										if (
											(bluepieces[i, 1] + 6 == redkingcoordinatex && bluepieces[i, 2] + 2 == redkingcoordinatey)
										||
										(bluepieces[i, 1] + 6 == redkingcoordinatex && bluepieces[i, 2] - 2 == redkingcoordinatey)
										||
										(bluepieces[i, 1] + 3 == redkingcoordinatex && bluepieces[i, 2] + 4 == redkingcoordinatey)
										||
										(bluepieces[i, 1] + 3 == redkingcoordinatex && bluepieces[i, 2] - 4 == redkingcoordinatey)
										||
										(bluepieces[i, 1] - 3 == redkingcoordinatex && bluepieces[i, 2] - 4 == redkingcoordinatey)
										||
										(bluepieces[i, 1] - 3 == redkingcoordinatex && bluepieces[i, 2] + 4 == redkingcoordinatey)
										||
										(bluepieces[i, 1] - 6 == redkingcoordinatex && bluepieces[i, 2] + 2 == redkingcoordinatey)
										||
										(bluepieces[i, 1] - 6 == redkingcoordinatex && bluepieces[i, 2] - 2 == redkingcoordinatey)
											)
										{
											isredkingchecked = true;
										}
									}
									if (bluePiecetype == "B")
									{
										int counter = 0;
										if (Math.Abs(redkingcoordinatex - bluepieces[i, 1]) / 3 == Math.Abs(redkingcoordinatey - bluepieces[i, 2]) / 2)
										{

											if (redkingcoordinatex > bluepieces[i, 1] && redkingcoordinatey > bluepieces[i, 2])
											{
												//control blue piece
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex, y = redkingcoordinatey; x >= bluepieces[i, 1]; x -= 3, y -= 2)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																{
																	counter++;
																}
															}
														}
													}
												}
												//conrorl red pieces
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex - 3, y = redkingcoordinatey - 2; x >= bluepieces[i, 1]; x -= 3, y -= 2)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 1] == x && redpieces[j, 2] == y)
															{
																counter++;
															}
														}

													}
												}

											}

											if (redkingcoordinatex > bluepieces[i, 1] && redkingcoordinatey < bluepieces[i, 2])
											{
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex, y = redkingcoordinatey; x >= bluepieces[i, 1]; x -= 3, y += 2)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																{
																	counter++;
																}
															}
														}
													}
												}
												//red piece contorl
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex - 3, y = redkingcoordinatey + 2; x >= bluepieces[i, 1]; x -= 3, y += 2)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 1] == x && redpieces[j, 2] == y)
															{
																counter++;
															}
														}

													}
												}
											}

											if (redkingcoordinatex < bluepieces[i, 1] && redkingcoordinatey > bluepieces[i, 2])
											{
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex, y = redkingcoordinatey; x <= bluepieces[i, 1]; x += 3, y -= 2)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																{
																	counter++;
																}
															}
														}
													}
												}
												//red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex + 3, y = redkingcoordinatey - 2; x <= bluepieces[i, 1]; x += 3, y -= 2)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 1] == x && redpieces[j, 2] == y)
															{
																counter++;
															}
														}

													}
												}
											}

											if (redkingcoordinatex < bluepieces[i, 1] && redkingcoordinatey < bluepieces[i, 2])
											{
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex, y = redkingcoordinatey; x <= bluepieces[i, 1]; x += 3, y += 2)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																{
																	counter++;
																}
															}
														}
													}
												}
												//red control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex + 3, y = redkingcoordinatey + 2; x <= bluepieces[i, 1]; x += 3, y += 2)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 1] == x && redpieces[j, 2] == y)
															{
																counter++;
															}
														}

													}
												}
											}


											if (counter == 0)
											{
												isredkingchecked = true;
											}
										}
									}
									if (bluePiecetype == "R")
									{
										int counter = 0;
										if (redkingcoordinatex == bluepieces[i, 1] || redkingcoordinatey == bluepieces[i, 2])
										{
											if (redkingcoordinatex == bluepieces[i, 1] && redkingcoordinatey > bluepieces[i, 2])
											{
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int y = redkingcoordinatey; y >= redpieces[i, 2]; y -= 2)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 2] == y && bluepieces[j, 1] == redkingcoordinatex)
																{
																	counter++;
																}
															}

														}
													}
												}
												//red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int y = redkingcoordinatey - 2; y >= bluepieces[i, 2]; y -= 2)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 2] == y && redpieces[j, 1] == redkingcoordinatex)
															{
																counter++;
															}
														}


													}
												}
											}

											if (redkingcoordinatex == bluepieces[i, 1] && redkingcoordinatey < bluepieces[i, 2])
											{
												//red piece conter
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int y = redkingcoordinatey; y <= bluepieces[i, 2]; y += 2)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 2] == y && bluepieces[j, 1] == redkingcoordinatex)
																{
																	counter++;
																}
															}

														}
													}
												}
												//blue piece counter
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int y = redkingcoordinatey + 2; y <= bluepieces[i, 2]; y += 2)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 2] == y && redpieces[j, 1] == redkingcoordinatex)
															{
																counter++;
															}
														}


													}
												}
											}

											if (redkingcoordinatey == bluepieces[i, 2] && redkingcoordinatex < bluepieces[i, 1])
											{
												//blue piece counter
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex; x <= bluepieces[i, 1]; x += 3)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == redkingcoordinatey)
																{
																	counter++;
																}
															}
														}
													}
												}
												//red piece counter
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex + 3; x <= bluepieces[i, 1]; x += 3)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 1] == x && redpieces[j, 2] == redkingcoordinatey)
															{
																counter++;
															}
														}

													}
												}
											}

											if (redkingcoordinatey == redpieces[i, 2] && redkingcoordinatex > redpieces[i, 1])
											{
												//blue piece counter
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex; x >= bluepieces[i, 1]; x -= 3)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == redkingcoordinatey)
																{
																	counter++;
																}
															}
														}
													}
												}
												//red piece counter
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex - 3; x >= bluepieces[i, 1]; x -= 3)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 1] == x && redpieces[j, 2] == redkingcoordinatey)
															{
																counter++;
															}
														}

													}
												}
											}
											if (counter == 0)
											{
												isredkingchecked = true;
											}
										}

									}
									if (bluePiecetype == "Q")
									{
										int counter = 0;
										if (redkingcoordinatex == bluepieces[i, 1] || redkingcoordinatey == bluepieces[i, 2] || Math.Abs(bluepieces[i, 1] - redkingcoordinatex) / 3 == Math.Abs(bluepieces[i, 2] - redkingcoordinatey) / 2)
										{
											if (redkingcoordinatex > bluepieces[i, 1] && redkingcoordinatey > bluepieces[i, 2])
											{
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex, y = redkingcoordinatey; x >= bluepieces[i, 1]; x -= 3, y -= 2)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																{
																	counter++;
																}
															}
														}
													}
												}
												//red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex - 3, y = redkingcoordinatey - 2; x >= bluepieces[i, 1]; x -= 3, y -= 2)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 1] == x && redpieces[j, 2] == y)
															{
																counter++;
															}
														}

													}
												}
											}

											if (redkingcoordinatex > bluepieces[i, 1] && redkingcoordinatey < bluepieces[i, 2])
											{
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex, y = redkingcoordinatey; x >= bluepieces[i, 1]; x -= 3, y += 2)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																{
																	counter++;
																}
															}

														}
													}
												}
												//red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex - 3, y = redkingcoordinatey + 2; x >= bluepieces[i, 1]; x -= 3, y += 2)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 1] == x && redpieces[j, 2] == y)
															{
																counter++;
															}
														}


													}
												}
											}

											if (redkingcoordinatex < bluepieces[i, 1] && redkingcoordinatey > bluepieces[i, 2])
											{
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex, y = redkingcoordinatey; x <= bluepieces[i, 1]; x += 3, y -= 2)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																{
																	counter++;
																}
															}

														}
													}
												}
												//blue piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex + 3, y = redkingcoordinatey - 2; x <= bluepieces[i, 1]; x += 3, y -= 2)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 1] == x && redpieces[j, 2] == y)
															{
																counter++;
															}
														}


													}
												}
											}

											if (redkingcoordinatex < bluepieces[i, 1] && redkingcoordinatey < bluepieces[i, 2])
											{
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex - 3, y = redkingcoordinatey - 2; x <= bluepieces[i, 1]; x += 3, y += 2)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == y)
																{
																	counter++;
																}
															}

														}
													}
												}
												//red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex + 3, y = redkingcoordinatey + 2; x <= bluepieces[i, 1]; x += 3, y += 2)
													{
														if (j != i)
														{
															if (redpieces[j, 0] != -1)
															{
																if (redpieces[j, 1] == x && redpieces[j, 2] == y)
																{
																	counter++;
																}
															}

														}
													}
												}
											}

											if (redkingcoordinatex == bluepieces[i, 1] && redkingcoordinatey > bluepieces[i, 2])
											{
												//red piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int y = redkingcoordinatey; y >= bluepieces[i, 2]; y -= 2)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 2] == y && bluepieces[j, 1] == redkingcoordinatex)
																{
																	counter++;
																}
															}

														}
													}
												}
												//blue piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int y = redkingcoordinatey - 2; y >= bluepieces[i, 2]; y -= 2)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 2] == y && redpieces[j, 1] == redkingcoordinatex)
															{
																counter++;
															}
														}


													}
												}
											}

											if (redkingcoordinatex == bluepieces[i, 1] && redkingcoordinatey < bluepieces[i, 2])
											{
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int y = redkingcoordinatey; y <= bluepieces[i, 2]; y += 2)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 2] == y && bluepieces[j, 1] == redkingcoordinatex)
																{
																	counter++;
																}
															}

														}
													}
												}
												//red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int y = redkingcoordinatey + 2; y <= bluepieces[i, 2]; y += 2)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 2] == y && redpieces[j, 1] == redkingcoordinatex)
															{
																counter++;
															}
														}


													}
												}
											}

											if (redkingcoordinatey == bluepieces[i, 2] && redkingcoordinatex < bluepieces[i, 1])
											{
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex; x <= bluepieces[i, 1]; x += 3)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == redkingcoordinatey)
																{
																	counter++;
																}
															}

														}
													}
												}
												//red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex + 3; x <= bluepieces[i, 1]; x += 3)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 1] == x && redpieces[j, 2] == redkingcoordinatey)
															{
																counter++;
															}
														}


													}
												}
											}

											if (redkingcoordinatey == bluepieces[i, 2] && redkingcoordinatex > bluepieces[i, 1])
											{
												//blue piece control
												for (int j = 0; j < bluepieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex; x >= bluepieces[i, 1]; x -= 3)
													{
														if (j != i)
														{
															if (bluepieces[j, 0] != -1)
															{
																if (bluepieces[j, 1] == x && bluepieces[j, 2] == redkingcoordinatey)
																{
																	counter++;
																}
															}

														}
													}
												}
												//red piece control
												for (int j = 0; j < redpieces.GetLength(0); j++)
												{
													for (int x = redkingcoordinatex - 3; x >= bluepieces[i, 1]; x -= 3)
													{

														if (redpieces[j, 0] != -1)
														{
															if (redpieces[j, 1] == x && redpieces[j, 2] == redkingcoordinatey)
															{
																counter++;
															}
														}


													}
												}
											}
											if (counter == 0)
											{
												isredkingchecked = true;
											}
										}
									}

								}
							}
							;
							if (isredkingchecked)
							{
								redpieces[indexofselectedpiece, 1] = tempx;
								redpieces[indexofselectedpiece, 2] = tempy;
								turn = "turnred";
							}
							if (!isredkingchecked)
							{
								if (!didredmove)
									turn = "turnred";
								else
									turn = "turnblue";
							}

							//turn RED end
						}
					}
				}
			} while (true);


		}
	}
}