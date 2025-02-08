using System;
using System.IO;
using System.Security.AccessControl;
using System.Xml.Linq;

namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello to our library system,please choose one mode (1 for user mode or 2 for librarian mode ):");
            string s=Console.ReadLine();
            bool run = true;
            while (run)
            {

                switch (Convert.ToInt32(s))
                {
                    case 1:
                        User b = new User();
                        b.user_();
                        string w = Console.ReadLine();
                        switch (Convert.ToInt32(w))
                        {
                            case 1:
                                Console.Clear();

                                b.CreateLibraryCard();
                                break;
                            case 2:
                                Console.Clear();

                                Console.WriteLine("Enter the title of book that you want to borrow:");
                                string w1 = Console.ReadLine();
                                b.borrow(w1);
                                break;
                            case 3:
                                Console.Clear();

                                Console.WriteLine("Enter the title of book that you want to return:");
                                string w2 = Console.ReadLine();
                                b.returnbook(w2);
                                break;
                            case 4:

                                Console.Clear();
                                b.displaybooks();
                                break;


                        }
                        break;

                    case 2:
                        Console.Clear();
                        librarian a = new librarian();
                        a.librarian_();

                        string s1 = Console.ReadLine();
                        switch (Convert.ToInt32(s1))
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Enter the book you want to Add and the name of the Auther");
                                string s3 = Console.ReadLine();
                                string s4 = Console.ReadLine();
                                a.add(s3, s4);
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Enter the book you want to Remove:");
                                string s5 = Console.ReadLine();
                                a.remove(s5);
                                break;
                            case 3:
                                Console.Clear();

                                a.displaybooks();
                                break;
                        }

                        break;

                }

                Console.WriteLine("\nDo you want to continue ? y/n ");
                string answer= Console.ReadLine();
                if (answer == "n")
                {
                    run = false;

                }
                else { Console.Clear();}
            }
            
        }
        
    }

    public class books
    {
        public string name;

        public string Auther;

        public string dateofborrow;

        public string dateofreturn;

        public bool available = false;
        public int numofbooksavaillable = 0;
        public string Price;
        public  static List<books> booklist = new List<books>();
        public void remove(string Name)
        {
            string filePath = @"D:\backend\available books.txt";
            string tempFilePath = @"D:\backend\tempFile.txt";

            bool bookExists = false;

            foreach (books book in booklist)
            {
                if (book.name == Name)
                {
                    bookExists = true;
                    break;
                }
            }

            if (bookExists)
            {
                booklist.RemoveAll(x => x.name == Name);

                using (StreamReader sr = new StreamReader(filePath))
                using (StreamWriter sw = new StreamWriter(tempFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != Name)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }

                File.Delete(filePath);
                File.Move(tempFilePath, filePath);

                numofbooksavaillable--;
                Console.WriteLine($"The book {Name} has been removed successfully.");
            }
            else
            {
                Console.WriteLine("Sorry, this book does not exist.");
            }
        }
        public void add(string Name, string auther)
        {

            books book = new books();
            book.name = Name;
            book.Auther = auther;
            book.available = true;

            booklist.Add(book);
            numofbooksavaillable++;

            string filePath = @"D:\backend\available books.txt";


            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(book.name);
            }
            Console.WriteLine($"the {book.name} book added successfully:)");
        }


    }
  


    public class librarian : books
    {
       
   
        public void displaybooks()
        {
           
            foreach (books book in booklist)
            {
                Console.WriteLine("book you added on this session:");
                Console.WriteLine($"name :{ book.name}\nAuther :{book.Auther}" +
                    $"\nis Avillable? {book.available}");
                Console.WriteLine("---------------------------------");

               


            } 
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Here are all availlable books in our library:");
            
           

            using (StreamReader sr = new StreamReader(@"D:\backend\available books.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        Console.WriteLine(line);

                    }
                }
        }
        public void librarian_()
        {
            Console.WriteLine("Now you entered as  a librarian please choose one option and start :");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1-add a book");
            Console.WriteLine("2-Remove a book");
            Console.WriteLine("3- display list of the books ");
        }
    } 
    
    public class User : books
    { 
        public void user_()
        {
            Console.WriteLine("Now you entered as  a user please choose one option and start :");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1-Create a library card");
            Console.WriteLine("2-Borrow a book");
            Console.WriteLine("3-Return a book ");
            Console.WriteLine("4- display list of the books ");



        }

        public void CreateLibraryCard()
        {
            Console.WriteLine("Okay, please enter your name:");
            string name = Console.ReadLine();

            string filePath = @"D:\backend\cardnumbers.txt";
            int lastCardNumber = 0;

            // Read the last card number from the file
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        if (int.TryParse(line, out int number))
                        {
                            lastCardNumber = number;
                        }

                    }
                }
            }


            int newCardNumber = lastCardNumber + 1;

            // Append the new card number to the file
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(newCardNumber);
            }

            Console.WriteLine($"Thanks {name} for visiting our library, your library card number is {newCardNumber}");
        }
        public void borrow(string s)
        {
            string filePath = @"D:\backend\available books.txt";
            string[] arr = File.ReadAllLines(filePath);
            bool bookExists = false;

            foreach (var line in arr)
            {
                if (line == s)
                {
                    Console.WriteLine("Ok, now you borrowed this book, have a great time :)");
                    bookExists = true;

                    booklist.RemoveAll(book => book.name == s);

                    string tempFilePath = @"D:\backend\tempFile.txt";
                    using (StreamReader sr = new StreamReader(filePath))
                    using (StreamWriter sw = new StreamWriter(tempFilePath))
                    {
                        string lineFile;
                        while ((lineFile = sr.ReadLine()) != null)
                        {
                            if (lineFile != s)
                            {
                                sw.WriteLine(lineFile);
                            }
                        }
                    }

                    File.Delete(filePath);
                    File.Move(tempFilePath, filePath);

                    break;
                }
            }

            if (!bookExists)
            {
                Console.WriteLine("Sorry, this book is not available right now.");
            }
        }

        public void returnbook(string s)
        {
            string filePath = @"D:\backend\available books.txt";

            books book = new books();
            book.name = s;
            book.Auther = "Unknown";
            book.available = true;
            booklist.Add(book);

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(s);
            }

            Console.WriteLine($"The book {s} has been returned successfully.");
        }
        public void displaybooks()
        {
            Console.WriteLine("Here are all availlable books in our library:\n");



            using (StreamReader sr = new StreamReader(@"D:\backend\available books.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    Console.WriteLine(line);

                }
            }
        }
    }
   
}

