using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Junior
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			checkingString();
		}
		static string Coin;
		private static void checkingString()
		{

			//Pobranie liczb od użytkownika
			Console.WriteLine("Wypisz liczby po przecinku: ");
			Coin = Console.ReadLine();
			// Sprawdzenie czy ciąg jest poprawny czyli obsługa błędu
			try
			{
				converting();
			}
			catch (FormatException ex)
			{
				Console.Clear();
				Console.WriteLine("Podano błędną wartość w ciągu ");
				checkingString();
			}
		}

		private static void converting()
		{
			//Usunięcie białych znaków i wstawienie ich do tablicy stringów
			Coin.Trim();
			string[] numbersInString = Coin.Split(',');
			int[] numbersArray = new int[numbersInString.Length];


			//przekonwertowanie tablicy stringów na tablice intów
			for (int i = 0; i < numbersInString.Length; i++)
			{
				numbersArray[i] = int.Parse(numbersInString[i]);
			}
			//Wywołanie metody dzielącej liczby na parsyste oraz nieparzyste i wyświetlanie ich wg polecenia
			displayNumbers(numbersArray);
		}

		private static void displayNumbers(int[] numbersArray)
		{
			int result = 0;
			int[] evenNumbers = new int[0];
			int[] oddNumbers = new int[0];
			// Przypisanie liczb parzystych i nieparzystych do powyższych tablic
			for (int i = 0; i < numbersArray.Length; i++)
			{
				if (numbersArray[i] % 2 == 0)
				{
					Array.Resize<int>(ref evenNumbers, evenNumbers.Length + 1);
					evenNumbers[evenNumbers.Length - 1] = numbersArray[i];
				}
				else
				{
					Array.Resize<int>(ref oddNumbers, oddNumbers.Length + 1);
					oddNumbers[oddNumbers.Length - 1] = numbersArray[i];
				}
			}

			//Wyświetlenie na ekranie
			Console.Write("Wszystkie podane liczby to: ");
			foreach (var item in numbersArray)
			{
				Console.Write("{0}, ", item);
			}
			Console.WriteLine();
			Console.Write("Parzyste liczby to: ");
			foreach (var item in evenNumbers)
			{
				Console.Write("{0}, ", item);
			}
			Console.WriteLine();
			Console.Write("Nieparzyste liczby to:");
			foreach (var item in oddNumbers)
			{
				Console.Write("{0}, ", item);
			}
			Console.WriteLine();
			//Obliczenie sumy wszystkich liczb i określenie jej parzystości
			foreach (var item in numbersArray)
			{
				result += item;
			}
			Console.WriteLine();
			if (result % 2 == 0)
			{
				Console.WriteLine("Suma wszystkich liczb to: {0}, liczba jest parzysta ", result);
			}
			else
			{
				Console.WriteLine("Suma wszystkich liczb to: {0}, liczba jest nieparzysta ", result);
			}

			Menu();
		}
		//Menu czyli obsługa klawiszy
		private static void Menu()
		{

			Console.WriteLine("Czy spróbować ponownie? - Wpisz Y  \nCzy zamknąć program? - Wpisz N");
			Console.ReadKey();
			if (Keyboard.IsKeyDown(Key.Y))
			{
				Console.Clear();
				checkingString();
			}
			else if (Keyboard.IsKeyDown(Key.N))
			{
				Environment.Exit(0);				
			}
			else if (!Keyboard.IsKeyDown(Key.Y) && !Keyboard.IsKeyDown(Key.N))
			{
				Console.Clear();
				Console.WriteLine("Błąd! Nie rozpoznano klawisza");
				Menu();
			}
		}


	}

}
