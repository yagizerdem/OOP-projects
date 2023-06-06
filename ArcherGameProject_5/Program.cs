using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace ArcherGame
{
	internal class ArcherGame
	{
		static void Main(string[] args)
		{
			int Ax ,Bx , Cx , Ay ,By , Cy;
			int Aset, Bset, Cset;
			int Ascore, Bscore, Cscore; 
			string Acondition = "survived", Bcondition="survived" , Ccondition = "survived";

			Console.WriteLine("Enter cordinates");
			Console.Write("Ax : ");
			if(!int.TryParse(Console.ReadLine(),out Ax))
			{
				Console.WriteLine("your entry in invalid");
				return;
			}
			Console.WriteLine();	
			Console.Write("Ay : ");
			if (!int.TryParse(Console.ReadLine(), out Ay))
			{
				Console.WriteLine("your entry in invalid");
				return;
			}
			Console.Clear();

			if(Ax <-5 || Ax > 5)
			{
				Console.WriteLine("Invalid etnyr");
				return;
			}
			if (Ay < -5 || Ay > 5)
			{
				Console.WriteLine("Invalid etnyr");
				return;
			}


			Random rnd = new Random();
			Aset = rnd.Next(1, 4);
			Bset = rnd.Next(1, 4);
			Cset = rnd.Next(1, 4);

			Bx = rnd.Next(-5, 6);
			Cx = rnd.Next(-5, 6);
			By = rnd.Next(-5, 6);
			Cy = rnd.Next(-5, 6);

			double distanceAB = Math.Sqrt(Math.Pow((Ax - Bx), 2) + Math.Pow((Ay - By), 2));
			double distanceAC = Math.Sqrt(Math.Pow((Ax - Cx), 2) + Math.Pow((Ay - Cy), 2));
			double distanceBC = Math.Sqrt(Math.Pow((Bx - Cx), 2) + Math.Pow((By - Cy), 2));

			double Ahealth = rnd.Next(1, 6) * 10;
			double Bhealth = rnd.Next(1, 6) * 10;
			double Chealth = rnd.Next(1, 6) * 10;

			Console.WriteLine("A: (" + Ax + ',' + Ay + ")  Set " + Aset + "  Health: " + Ahealth);
			Console.WriteLine("B: (" + Bx + ',' + By + ")  Set " + Bset + "  Health: " + Bhealth);
			Console.WriteLine("C: (" + Cx + ',' + Cy + ")  Set " + Cset + "  Health: " + Chealth);

			Thread.Sleep(5000);
			Console.Clear();

			Console.WriteLine("-------------+------------");
			Console.WriteLine("5| . . . . . | . . . . . |");
			Console.WriteLine("4| . . . . . | . . . . . |");
			Console.WriteLine("3| . . . . . | . . . . . |");
			Console.WriteLine("2| . . . . . | . . . . . |");
			Console.WriteLine("1| . . . . . | . . . . . |");
			Console.WriteLine("0|-----------+-----------|");
			Console.WriteLine("1| . . . . . | . . . . . |");
			Console.WriteLine("2| . . . . . | . . . . . |");
			Console.WriteLine("3| . . . . . | . . . . . |");
			Console.WriteLine("4| . . . . . | . . . . . |");
			Console.WriteLine("5| . . . . . | . . . . . |");
			Console.WriteLine("-------------+-------------");
			Console.WriteLine("   5 4 3 2 1   1 2 3 4 5");
			
			double maxdistance = Math.Sqrt(98);

			if (distanceAB < distanceAC && distanceAB < distanceBC)
			{
				if (distanceAB > maxdistance)
				{
					Console.WriteLine("Archer are too far no attack");
				}
				else
				{
					if (Aset > Bset)
					{
						int damage = (Aset - Bset) * 10;
						Bhealth -= damage;
						if (Bhealth <= 0)
						{
							Bcondition = "died";
							Bhealth = 0;
						}
					}
					if (Bset > Aset)
					{
						int damage = (Bset - Aset) * 10;
						Ahealth -= damage;
						if (Ahealth <= 0)
						{
							Acondition = "died";
							Ahealth = 0;
						}
					}
					if (Bset == Aset)
					{
						int damage = (Bset) * 10;
						Ahealth -= damage;
						Bhealth -= damage;
						if (Ahealth <= 0)
						{
							Acondition = "died";
							Ahealth = 0;	
						}
						if (Bhealth <= 0)
						{
							Bcondition = "died";
							Bhealth = 0;
						}
					}
				}

			}
			else if (distanceAC < distanceAB && distanceAC < distanceBC)
			{
				if (distanceAC > maxdistance)
				{
					Console.WriteLine("Archer are too far no attack");
				}
				else
				{
					if (Aset > Cset)
					{
						int damage = (Aset - Cset) * 10;
						Chealth -= damage;
						if (Chealth <= 0)
						{
							Ccondition = "died";
							Chealth = 0;
						}
					}
					if (Cset > Aset)
					{
						int damage = (Cset - Aset) * 10;
						Ahealth -= damage;
						if (Ahealth <= 0)
						{
							Acondition = "died";
							Ahealth = 0;
						}
					}
					if (Cset == Aset)
					{
						int damage = (Cset) * 10;
						Ahealth -= damage;
						Chealth -= damage;
						if (Ahealth <= 0)
						{
							Acondition = "died";
							Ahealth = 0;
						}
						if (Chealth <= 0)
						{
							Ccondition = "died";
							Chealth = 0;	
						}
					}
				}
			}
			else
			{
				if (distanceBC > maxdistance)
				{
					Console.WriteLine("Archer are too far no attack");
				}
				else
				{
					if (Bset > Cset)
					{
						int damage = (Bset - Cset) * 10;
						Chealth -= damage;
						if (Chealth <= 0)
						{
							Ccondition = "died";
							Chealth = 0;
						}
					}
					if (Cset > Bset)
					{
						int damage = (Cset - Bset) * 10;
						Bhealth -= damage;
						if (Bhealth <= 0)
						{
							Bcondition = "died";
							Bhealth = 0;
						}
					}
					if (Cset == Bset)
					{
						int damage = (Cset) * 10;
						Bhealth -= damage;
						Chealth -= damage;
						if (Bhealth <= 0)
						{
							Bcondition = "died";
							Bhealth = 0;
						}
						if (Chealth <= 0)
						{
							Ccondition = "died";
							Chealth = 0;
						}
					}
				}
			}

			Console.WriteLine("round 1 results :");
			Console.WriteLine("A: (" + Ax + ',' + Ay + ")  Set " + Aset + "  Health: " + Ahealth + " " + Acondition);
			Console.WriteLine("B: (" + Bx + ',' + By + ")  Set " + Bset + "  Health: " + Bhealth + " " + Bcondition);
			Console.WriteLine("C: (" + Cx + ',' + Cy + ")  Set " + Cset + "  Health: " + Chealth + " " + Ccondition);
			Thread.Sleep(5000);
			Console.WriteLine("Round2");
			Thread.Sleep(10000);
			Console.Clear();

			Console.WriteLine("-------------+------------");
			Console.WriteLine("5| . . . . . | . . . . . |");
			Console.WriteLine("4| . . . . . | . . . . . |");
			Console.WriteLine("3| . . . . . | . . . . . |");
			Console.WriteLine("2| . . . . . | . . . . . |");
			Console.WriteLine("1| . . . . . | . . . . . |");
			Console.WriteLine("0|-----------+-----------|");
			Console.WriteLine("1| . . . . . | . . . . . |");
			Console.WriteLine("2| . . . . . | . . . . . |");
			Console.WriteLine("3| . . . . . | . . . . . |");
			Console.WriteLine("4| . . . . . | . . . . . |");
			Console.WriteLine("5| . . . . . | . . . . . |");
			Console.WriteLine("-------------+-------------");
			Console.WriteLine("   5 4 3 2 1   1 2 3 4 5");

			int survivedCounter = 0;
			if (Acondition == "survived" && Bcondition == "survived" && Ccondition == "survived")
			{
				survivedCounter = 3;
			}
			else if(Acondition == "died" && Bcondition == "survived" && Ccondition == "survived")
			{
				survivedCounter = 2;
			}
			else if (Acondition == "survived" && Bcondition == "died" && Ccondition == "survived")
			{
				survivedCounter = 2;
			}
			else if (Acondition == "survived" && Bcondition == "survived" && Ccondition == "died")
			{
				survivedCounter = 2;
			}
			else if (Acondition == "died" && Bcondition == "died" && Ccondition == "survived")
			{
				survivedCounter = 1;
			}
			else if (Acondition == "died" && Bcondition == "survived" && Ccondition == "died")
			{
				survivedCounter = 1;
			}
			else if (Acondition == "survived" && Bcondition == "died" && Ccondition == "died")
			{
				survivedCounter = 1;
			}

			if (survivedCounter == 1)
			{
				Console.Clear();
				Console.WriteLine("Game over");
				if (Ahealth > 0)
					Console.WriteLine("A wins");
				if (Bhealth > 0)
					Console.WriteLine("A wins");
				if (Bhealth > 0)
					Console.WriteLine("A wins");
			}
			else if(survivedCounter == 2)
			{
				if(Ahealth > 0 && Bhealth > 0)
				{
					Aset = rnd.Next(1, 4);
					Bset = rnd.Next(1, 4);
					if (distanceAB > maxdistance)
					{
						Console.WriteLine("Archer are too far no attack");
					}
					else
					{
						if (Aset > Bset)
						{
							int damage = (Aset - Bset) * 10;
							Bhealth -= damage;
							if (Bhealth <= 0)
							{
								Bcondition = "died";
								Bhealth = 0;
							}
						}
						if (Bset > Aset)
						{
							int damage = (Bset - Aset) * 10;
							Ahealth -= damage;
							if (Ahealth <= 0)
							{
								Acondition = "died";
								Ahealth = 0;
							}
						}
						if (Bset == Aset)
						{
							int damage = (Bset) * 10;
							Ahealth -= damage;
							Bhealth -= damage;
							if (Ahealth <= 0)
							{
								Acondition = "died";
								Ahealth = 0;
							}
							if (Bhealth <= 0)
							{
								Bcondition = "died";
								Bhealth = 0;
							}
						}
					}
				}
				if (Ahealth > 0 && Chealth > 0)
				{
					Aset = rnd.Next(1, 4);
					Cset = rnd.Next(1, 4);
					if (distanceAC > maxdistance)
					{
						Console.WriteLine("Archer are too far no attack");
					}
					else
					{
						if (Aset > Cset)
						{
							int damage = (Aset - Cset) * 10;
							Chealth -= damage;
							if (Chealth <= 0)
							{
								Ccondition = "died";
								Chealth = 0;
							}
						}
						if (Cset > Aset)
						{
							int damage = (Cset - Aset) * 10;
							Ahealth -= damage;
							if (Ahealth <= 0)
							{
								Acondition = "died";
								Ahealth = 0;
							}
						}
						if (Cset == Aset)
						{
							int damage = (Cset) * 10;
							Ahealth -= damage;
							Chealth -= damage;
							if (Ahealth <= 0)
							{
								Acondition = "died";
								Ahealth = 0;
							}
							if (Chealth <= 0)
							{
								Ccondition = "died";
								Chealth = 0;
							}
						}
					}
				}
				if (Bhealth > 0 && Chealth > 0)
				{
					Bset = rnd.Next(1, 4);
					Cset = rnd.Next(1, 4);
					if (distanceBC > maxdistance)
					{
						Console.WriteLine("Archer are too far no attack");
					}
					else
					{
						if (Bset > Cset)
						{
							int damage = (Bset - Cset) * 10;
							Chealth -= damage;
							if (Chealth <= 0)
							{
								Ccondition = "died";
								Chealth = 0;
							}
						}
						if (Cset > Bset)
						{
							int damage = (Cset - Bset) * 10;
							Bhealth -= damage;
							if (Bhealth <= 0)
							{
								Bcondition = "died";
								Bhealth = 0;
							}
						}
						if (Cset == Bset)
						{
							int damage = (Cset) * 10;
							Bhealth -= damage;
							Chealth -= damage;
							if (Bhealth <= 0)
							{
								Bcondition = "died";
								Bhealth = 0;
							}
							if (Chealth <= 0)
							{
								Ccondition = "died";
								Chealth = 0;
							}
						}
					}
				}
			}
			else if(survivedCounter == 3)
			{
				Aset = rnd.Next(1, 4);
				Bset = rnd.Next(1, 4);
				Cset = rnd.Next(1, 4);

				Bx = rnd.Next(-5, 6);
				Cx = rnd.Next(-5, 6);
				By = rnd.Next(-5, 6);
				Cy = rnd.Next(-5, 6);

				distanceAB = Math.Sqrt(Math.Pow((Ax - Bx), 2) + Math.Pow((Ay - By), 2));
				distanceAC = Math.Sqrt(Math.Pow((Ax - Cx), 2) + Math.Pow((Ay - Cy), 2));
				distanceBC = Math.Sqrt(Math.Pow((Bx - Cx), 2) + Math.Pow((By - Cy), 2));

				if (distanceAB < distanceAC && distanceAB < distanceBC)
				{
					if (distanceAB > maxdistance)
					{
						Console.WriteLine("Archer are too far no attack");
					}
					else
					{
						if (Aset > Bset)
						{
							int damage = (Aset - Bset) * 10;
							Bhealth -= damage;
							if (Bhealth <= 0)
							{
								Bcondition = "died";
								Bhealth = 0;
							}
						}
						if (Bset > Aset)
						{
							int damage = (Bset - Aset) * 10;
							Ahealth -= damage;
							if (Ahealth <= 0)
							{
								Acondition = "died";
								Ahealth = 0;
							}
						}
						if (Bset == Aset)
						{
							int damage = (Bset) * 10;
							Ahealth -= damage;
							Bhealth -= damage;
							if (Ahealth <= 0)
							{
								Acondition = "died";
								Ahealth = 0;
							}
							if (Bhealth <= 0)
							{
								Bcondition = "died";
								Bhealth = 0;
							}
						}
					}

				}
				else if (distanceAC < distanceAB && distanceAC < distanceBC)
				{
					if (distanceAC > maxdistance)
					{
						Console.WriteLine("Archer are too far no attack");
					}
					else
					{
						if (Aset > Cset)
						{
							int damage = (Aset - Cset) * 10;
							Chealth -= damage;
							if (Chealth <= 0)
							{
								Ccondition = "died";
								Chealth = 0;
							}
						}
						if (Cset > Aset)
						{
							int damage = (Cset - Aset) * 10;
							Ahealth -= damage;
							if (Ahealth <= 0)
							{
								Acondition = "died";
								Ahealth = 0;
							}
						}
						if (Cset == Aset)
						{
							int damage = (Cset) * 10;
							Ahealth -= damage;
							Chealth -= damage;
							if (Ahealth <= 0)
							{
								Acondition = "died";
								Ahealth = 0;
							}
							if (Chealth <= 0)
							{
								Ccondition = "died";
								Chealth = 0;
							}
						}
					}
				}
				else
				{
					if (distanceBC > maxdistance)
					{
						Console.WriteLine("Archer are too far no attack");
					}
					else
					{
						if (Bset > Cset)
						{
							int damage = (Bset - Cset) * 10;
							Chealth -= damage;
							if (Chealth <= 0)
							{
								Ccondition = "died";
								Chealth = 0;
							}
						}
						if (Cset > Bset)
						{
							int damage = (Cset - Bset) * 10;
							Bhealth -= damage;
							if (Bhealth <= 0)
							{
								Bcondition = "died";
								Bhealth = 0;
							}
						}
						if (Cset == Bset)
						{
							int damage = (Cset) * 10;
							Bhealth -= damage;
							Chealth -= damage;
							if (Bhealth <= 0)
							{
								Bcondition = "died";
								Bhealth = 0;
							}
							if (Chealth <= 0)
							{
								Ccondition = "died";
								Chealth = 0;
							}
						}
					}
				}
			}

			Console.WriteLine("round 2 results :");
			Console.WriteLine("A: (" + Ax + ',' + Ay + ")  Set " + Aset + "  Health: " + Ahealth + " " + Acondition);
			Console.WriteLine("B: (" + Bx + ',' + By + ")  Set " + Bset + "  Health: " + Bhealth + " " + Bcondition);
			Console.WriteLine("C: (" + Cx + ',' + Cy + ")  Set " + Cset + "  Health: " + Chealth + " " + Ccondition);
			Thread.Sleep(15000);


		}
	}
}