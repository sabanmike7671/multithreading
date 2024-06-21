


//Standardbefehle werden aufgerufen:
using System;
using System.Windows;
using Microsoft.Win32;
using System.Security.Cryptography.X509Certificates;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//Zeilennummer ab 90 verwendet diese library für dateiverwaltung
//Ausführung für Peripheriegeräte damit man dateien speichern kann:
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Net;       //HTML Datei runterladen und speichern
using System.Net.Http;




//Ausgabeverzögerung von Daten mit ThreadSleep(1000); für eine Sekunde:
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Channels;

//.NET 5 benötigt eine weiterer Systembibliothek für List(); wobei (); hier Funktion bedeutet
using System.Text;
using System.Data;
using System.Reflection.Metadata.Ecma335;


//using System.Memory;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;



//Dictionary-Befehl und kvp key value product wird aufgerufen:
using System.Collections;
using System.Collections.Generic;
using System.Xml;
//using System.Collections.Generic.IEnumerables;

//Salzburg, am 17. Juni 2024 von Mirza Sabanovic
//Zweck und Änderungen werden in Zeilennummern nach Hauptprogramm mit ///-XML oder /* geschildert
//Desweiteren wird das individuelle Programm danach dokumentiert
//suche nach funktion welche noch inhalt in die datei hinzufügt ab Zeilennummer 220
// Environment.Exit(230); bedeutet Rückgabewert auch Zeilennummer ab 230

namespace step2coder_consoleApp21_multithreading
{
    internal class Program
    {

        //funktionen wo globale variablen
        static public void schreibegrossbuchstaben()
        {
            //zählvariable i kurz index vom datentyp integer
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine((char)('A' + i)); //26 buchstaben vom alphabet laut ascii

                //es wird eine halbe sekunde gezögert was auch threading bedeutet
                Thread.Sleep(500);
                //Thread.Sleep(250); bedeutet 250ms millisekunden
            }

            //Ende schreibegrossbuchstaben()
        }

        //funktionen wo globale variablen
        static public void schreibekleinbuchstaben()
        {
            //zählvariable i kurz index vom datentyp integer
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine((char)('a' + i)); //26 buchstaben vom alphabet laut ascii

                //es wird eine sekunde gezögert was auch threading bedeutet
                Thread.Sleep(1000);
            }

            //Ende schreibekleinbuchstaben()
        }

        async Task impressum()
        {
            using (HttpClient client = new HttpClient())
            {
                string pageContent = await client.GetStringAsync("https://careerfoliospaces.wordpress.com/impressum/Impressum_.html");
                //Verarbeite den HTML-Inhalt hier
                //XmlWriteMode(pageContent);
                //XmlWriter(pageContent);
            }
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            
            

            //Definition und Deklaration der lokalen Variable
            string suche = "";

            string testdatei = "";
            //das ist typtisch c# um daten in datei zu speichern
            string pfad = @"D:\seminar.txt";
            //ReadAllText wo pfad nicht funktioniert kann fehler machen

            try //wie if
            {   //variable inhalt ist hier eine Laufvariable wird direkt im Programmtext deklariert und definiert
                //Error handling, exception handling
                //try, catch, throw
                string inhalt = File.ReadAllText(pfad);
                Console.WriteLine("\n\n\n\t     Dateiinhalt\n\n\n");
                Console.WriteLine(inhalt);

            }//arbeite mit dateien deswegen diese exception
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file at path '{pfad}' was not found.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: You do not have permission to access the file at path:");
                Console.WriteLine($"'{pfad}'.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An IO error occured: {ex.Message}");
            }
            catch (Exception ex) // wie else
            {
                Console.WriteLine($"Befehl funktioniert nicht {ex.Message} !");
                //Console.WriteLine($"An unexpected error occurred {ex.Message} !");
            }

            //zeilennummer ab 10 ruft man using System.IO; aus


            if (File.Exists("D:\\test.txt") == true)
            {
                //filePath ist hier eine Laufvariable wird direkt im Programmtext deklariert und definiert
                string filePath1 = @"D:\test.txt";
                File.ReadAllText(filePath1);
            }
            else
            {
                Console.WriteLine("Die Datei test.txt wurde nicht gefunden !");
            }
            if (File.Exists("D:\\output.txt") == true)
            {
                string filePath2 = @"D:\output.txt";
                File.ReadAllText(filePath2);

                //in die datei output einen text schreiben mit neue zeile erste version
                string createText = "Sie haben folgende Zeichenkette (z.B.: Wort) gesucht:" + Environment.NewLine;

                Console.WriteLine("Was suchen Sie in der Datei test.txt ?");
                suche = Convert.ToString(Console.ReadLine().ToLower());


                //suche wird in der datei output.txt gespeichert
                //File.WriteAllText(filePath2, "\n\n\n"); nächste Befehl überschrieben siehe output.txt
                File.WriteAllText(filePath2, createText + "\n\n\n" + suche + "\n\n\n");
                //neue zeile zweite version


               
                //filePath ist hier eine Laufvariable wird direkt im Programmtext deklariert und definiert
                string filePath3 = @"D:\test.txt";
                testdatei = File.ReadAllText(filePath3).ToLower();
               
                //testdatei. nach punkt funktionen auflisten wie diese stringvariable bearbeitet
                
                if (testdatei.Contains(suche) == true)
                {
                    string filePath4 = @"D:\seminar.txt";
                    File.ReadAllText(filePath4);

                    Console.WriteLine("Die Zeichenkette (z.B.Wort)\t  " + suche + "\t  wurde gefunden !");

                    string appendText = "Die Zeichenkette (z.B.Wort)\t " + suche + "wurde gefunden !" 
                                         + Environment.NewLine;
                    File.WriteAllText(filePath4, createText + "\n\n\n" + suche + "\n\n\n" + appendText);
                }
                else
                {
                    Console.WriteLine("test.txt beinhaltet keinen Suchvorschlag !");

                }

            }//suche nach funktion welche noch inhalt in die datei hinzufügt 
            else
            {
                Console.WriteLine("Die Datei output.txt wurde nicht gefunden !");
            }


            //dateisuche in textdatei und ausgabe in eigene datei



            //aufrufen der funktionen hier sequentiell
            //schreibekleinbuchstaben();
            //schreibegrossbuchstaben();

            Console.WriteLine("\n\n \t  Aufrufen der beiden Funktionen mit Themen von Multithreading:\n\n");
            //aufrufen der funktionen hier parallel mit klasse thread
            Thread prozess1 = new Thread(new ThreadStart(schreibekleinbuchstaben));
            Thread prozess2 = new Thread(new ThreadStart(schreibegrossbuchstaben));

            //starten der threading
            prozess1.Start();
            prozess2.Start();


            //wartet bis beendigung using System.Threading.Channels;
            prozess1.Join();
            prozess2.Join();

        //methode von klasse thread mit fehlermeldung siehe abbildung von learn.microsoft.com
        //prozess1.Abort();

        beginning:
            try
            {
                Console.Clear();

                Console.WriteLine("\n\n\n\t     Auswahl des Hauptprogrammes zum Thema Dateiverwaltung:\n\n\n");
                Console.WriteLine("1.\t     HTML runterladen und in C# einlesen");
                Console.WriteLine("2.\t     Excel als Datei in C# einlesen und ausgeben");
                Console.WriteLine("3.\t     EXIT mit einer Multithreadingfunktion");

                //es wird drei sekunden gezögert was auch threading bedeutet
                Thread.Sleep(3000);

                Console.WriteLine("Enter a number (1,2 or 3)");
                string input = Console.ReadLine();
                int number = int.Parse(input);
                string outputHTML = "";

                switch (number)
                {
                    case 1:
                        Console.WriteLine("You entered one.");
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile("https://careerfoliospaces.wordpress.com/impressum/Impressum_.html", @"D:\lokaldatei.html");
                        }

                        string filePath5 = @"D:\lokaldatei.html";
                        outputHTML = File.ReadAllText(filePath5);

                        Console.WriteLine("Laufwerk D und die Dateil lokaldatei.html wurde eingelesen !");
                        //Console.WriteLine(outputHTML);

                        break;

                    case 2:

                        Console.WriteLine("You entered two.");

                        string pfad2 = @"D:\excel.csv";
                        string inhalt2 = File.ReadAllText(pfad2);    //Zeilennummer ab 110 variable pfad 


                        Console.WriteLine("\n\n\n\t   EXCEL-Dateiinhalt\n\n\n");
                        Console.WriteLine(inhalt2);


                    break;

                    case 3:

                        Console.WriteLine("You entered three.");
                        // Oder den Inhalt ohne Speichern abrufen
                        string htmlCode;
                        using (WebClient client = new WebClient())
                        {
                            htmlCode = client.DownloadString("https://careerfoliospaces.wordpress.com/impressum/Impressum_.html");
                        }

                        //impressum(htmlCode);
                        
                        Thread.Sleep(5000);     //Simulate Work for 5 sec
                        Environment.Exit(250);
                        break;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: The file at path '{pfad}' was not found.");
                goto beginning;
            }
            catch (Exception ex) // wie else
            {
                Console.WriteLine($"Das Programm wird nicht ordnungsgemäß beendet: {ex.Message} !");
                //Console.WriteLine($"An unexpected error occurred {ex.Message} !");

                Thread.Sleep(5000); //Simulate Work for 5 sec

                Environment.Exit(300);  //Rückgabewert für nicht ordnungsgemäß beendet
            }


            Task task1 = new Task(() => { schreibegrossbuchstaben(); });
            Task task2 = new Task(() => { schreibekleinbuchstaben(); });

            task1.Start();
            task2.Start();

            Task.WaitAll(task1);
            task1.Wait();
            task2.Wait();


            int ergebnis;

            Func<int, int> quadrieren = x => x * x;

            ergebnis = quadrieren(5); //lambda expression function innerhalb main also hauptprogramm
            Console.WriteLine(ergebnis);



            //Ende static void Main
        }


        //Ende internal class Program
    }

    //Ende namespace
}


/*
 * 
 * 
+++++
Zeilennummer ab 300
Multithreading wurd mit C# besser gelöst als C++

C++ für Hardware
C#  GUI und objektorientierte Entwicklungsumgebung

//learn.microsoft.com/de-de/search/?scope=.NET&terms=file%20read%20all%20text
//learn.microsoft.com/de-de/dotnet/api/system.collections.generic.queue-1.contains?view=net-8.0

try
{
    // Your code that might throw an exception
}
catch (Exception ex)
{
    // Print a custom message for the user
    Console.WriteLine($"Befehl funktioniert nicht: {ex.Message} !");
    
    // Optional: Log the detailed exception message for debugging
    // Uncomment the line below if you want to print the detailed message to the console
    // Console.WriteLine($"An unexpected error occurred: {ex.Message}");

    // Example of logging the error to a file (assuming you have a method LogError)
    LogError(ex);
}

void LogError(Exception ex)
{
    // Simple logging to a text file (you might want to use a proper logging framework)
    string logFilePath = "error.log";
    string logMessage = $"{DateTime.Now}: {ex.ToString()}\n";
    System.IO.File.AppendAllText(logFilePath, logMessage);
}

***
*
*learn.microsoft.com/en-us/dotnet/api/system.threading.thread?view=net-8.0
*
*c-sharpcorner.com/article/task-and-thread-in-c-sharp/#:~:text=in%20C%23%3F-,.,task%20gives%20you%20the%20result.
*
*youtube.com/watch?v=2moh18sh5p4
***

//stackoverflow.com/questions/6183809/using-streamreader-to-check-if-a-file-contains-a-string

 Synchronization

When multiple threads access shared resources, you need to synchronize them to avoid conflicts. 
The lock statement is commonly used for this purpose:


using System;
using System.Threading;

class Program
{
    private static readonly object _lock = new object();

    static void Main()
    {
        Thread thread1 = new Thread(DoWork);
        Thread thread2 = new Thread(DoWork);
        thread1.Start();
        thread2.Start();
    }

    static void DoWork()
    {
        lock (_lock)
        {
            // Critical section of code
            Console.WriteLine("Thread {0} is working.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000); // Simulate work
        }
    }
}




The line of code `Console.WriteLine((char)'A' + i);` is attempting to convert the character `'A'` to its integer ASCII value, add the integer `i` to this value, and then print the resulting character. However, due to operator precedence, it won't behave as expected.

Let's break down what this code is doing and then correct it to achieve the intended functionality.

### Breakdown
1. `(char)'A'` converts the character `'A'` to its integer ASCII value, which is 65.
2. `65 + i` adds the integer `i` to 65, resulting in an integer.
3. `Console.WriteLine` attempts to print the result of this addition, which is still an integer, not a character.

This results in the output being the integer sum, not the character corresponding to the new ASCII value.

### Corrected Code
To print the character corresponding to the new ASCII value, we need to cast the result back to `char` after the addition:

```csharp
Console.WriteLine((char)('A' + i));
```

### Explanation
- `'A' + i` calculates the integer sum.
- `(char)(...)` converts this integer back to a character.
- `Console.WriteLine` prints this character.

### Example
For example, if `i` is 1:
- `'A' + 1` results in 66.
- `(char)66` converts 66 back to the character `'B'`.
- `Console.WriteLine` prints `'B'`.

### Full Example with a Loop
To demonstrate this in a loop:

```csharp
for (int i = 0; i < 26; i++)
{
    Console.WriteLine((char)('A' + i));
}
```

This code will print the characters from 'A' to 'Z'.

*****
*
*
*********
*
*
*****************
*
*






*/