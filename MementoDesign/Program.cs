using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new Book()
            {
                Isbn="12345",
                Title="Sefiller",
                Author="Victor hugo"
            };

            books.ShowBook();
            
            CareTaker careTaker= new CareTaker();
            careTaker.Memento = books.CreateUndo();

            books.Isbn = "54321";
            books.Title = "VICTOR HUGO";

            books.ShowBook();

            books.RestoreFromUndo(careTaker.Memento);
            books.ShowBook();

            Console.ReadLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        DateTime _lastEdited;

        public string Title
        {
            get//değeri okuma
            {
                return _title;
            }
            set//değeri yazma
            {
                _title = value;
                SetLastEdited();
            }
        }
        public string Author { get => _author; set => _author = value; }
        public string Isbn { get => _isbn; set => _isbn = value; }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn, _title, _author, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title= memento.Title;
            _author= memento.Author;
            _isbn= memento.Isbn;
            _lastEdited= DateTime.UtcNow;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0}, {1}, {2} edited : {3}",Isbn,Title,Author,_lastEdited);
        }
    }

    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn, string title, string author, DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
