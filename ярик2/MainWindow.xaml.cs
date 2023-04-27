using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ярик2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public Dictionary<int, Dictionary<string, string>> baza = new Dictionary<int, Dictionary<string, string>>() { };
        //public List<int> steps = new List<int>();
        //public List<string> citys = new List<string>();
        //public List<string> countries = new List<string>();
        //public List<string> names = new List<string>();
        //public List<string> emails = new List<string>();
        //public List<string> peoples = new List<string>();
        //public List<string> nights = new List<string>();
        //public List<string> days = new List<string>();
        //public int step = 0;
        //public int jep = 0;
        //public int pep = 0;
        List<Ticket> tickets = new List<Ticket>();//список с данными по броин билетов, каждый билет уникальный и не может повторяться
        public MainWindow()
        {//стартовый выпадающий список, без выбора страны, остальные действия будут ограничены
            InitializeComponent();
            Countrys.ItemsSource = new Country[]
           {
                new Country { Name = "Россия"},
                new Country { Name = "Турция" },
                new Country { Name = "Египет"},
                new Country { Name = "Кипр"},
                new Country { Name = "Греция"},
                new Country { Name = "Испания"}
           };
        }
        //обработчик собыйтий кнопки выбрать, после выбора страны открывается доступ к выбору города, количсетва людей, ночей
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Peoples.ItemsSource = new City[]
                {
                    new City { Name = "1 человек" },
                    new City { Name = "2 человека" },
                    new City { Name = "3 человека" },
                    new City { Name = "4 человека" },
                    new City { Name = "5 человек" },
                    new City { Name = "6 человек" }
                };
            Nights.ItemsSource = new City[]
            {
                    new City { Name = "5 ночей" },
                    new City { Name = "7 ночей" },
                    new City { Name = "12 ночей" },
                    new City { Name = "14 ночей" },
                    new City { Name = "20 ночей" },
                    new City { Name = "30 ночей" }
            };
            //тут идет проверка страны, при выборе определённой страны, появится выпадающий список для выбранной страны и никак по другому
            if (Countrys.Text == "Россия")
            {
                cityes.ItemsSource = new City[]
                {
                    new City { Name = "Краснодар" },
                    new City { Name = "Алтай" },
                    new City { Name = "Сибирь" },
                    new City { Name = "Москва" },
                    new City { Name = "Санкт петербург" },
                    new City { Name = "Крым" }
                };
            }
            else if (Countrys.Text == "Турция")
            {
                cityes.ItemsSource = new City[]
                {
                    new City { Name = "Анкара" },
                    new City { Name = "Анталья" },
                    new City { Name = "Стамбул" },
                    new City { Name = "Измир" },
                    new City { Name = "Аланьяг" },
                    new City { Name = "Кемер" }
                };
            }
            else if (Countrys.Text == "Египет")
            {
                cityes.ItemsSource = new City[]
                {
                    new City { Name = "Каир" },
                    new City { Name = "Кургада" },
                    new City { Name = "Шарм-эш-Шейх" },
                    new City { Name = "Луксор" },
                    new City { Name = "Гиза" },
                    new City { Name = "Асуан" }
                };
            }
            else if (Countrys.Text == "Кипр")
            {
                cityes.ItemsSource = new City[]
                {
                    new City { Name = "Лимассол" },
                    new City { Name = "Пафос" },
                    new City { Name = "Ларнака" },
                    new City { Name = "Никосия" },
                    new City { Name = "Кириния" },
                    new City { Name = "Фамагуста" }
                };
            }
            else if (Countrys.Text == "Греция")
            {
                cityes.ItemsSource = new City[]
                {
                    new City { Name = "Афины" },
                    new City { Name = "Салоники" },
                    new City { Name = "Ираклион" },
                    new City { Name = "Ханья" },
                    new City { Name = "Нафплион" },
                    new City { Name = "Патры" }
                };
            }
            else if (Countrys.Text == "Испания")
            {
                cityes.ItemsSource = new City[]
                {
                    new City { Name = "Барселона" },
                    new City { Name = "Мадрид" },
                    new City { Name = "Севилья" },
                    new City { Name = "Аликанте" },
                    new City { Name = "Валенсия" },
                    new City { Name = "Толедо" }
                };
            }
        }
        //этот обработчик не пригодился
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        //тут самое сложное, проходит проверка всех вводимых данных получаемых из выпадающих списков и текстблоков в xaml, данные 
        //оттуда записываются в переменные, которые проверяются методом Any на правильность, и после успешной проверки заносится в спи-
        //сок из начала программы, в случае если проверку не проходит, все данные просто не засчитываются
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Ticket newTicket = new Ticket { Day = Dates.Text, City = cityes.Text, Country = Countrys.Text, Name = Names.Text, Email = Emails.Text, Night = Nights.Text};

            if (!tickets.Any(t => t.Day == newTicket.Day && t.City == newTicket.City && t.Country == newTicket.Country && t.Name == newTicket.Name && t.Email == newTicket.Email && t.Night == newTicket.Night))
            {
                tickets.Add(newTicket);
                //при успешной проверке появится уведомление об удачной брони
                MessageBox.Show("Ваши данные учтены, путёвка зарезервирована!");
            }
            else
            {
                //при неудачной проверке, сообщит о том, что такая бронь уже есть
                MessageBox.Show("Такая путёвка уже продана, попробуйте выбрать другую!");
                // Билет уже существует
            }

           
        }
    }
    //этот класс принимает значения из переменных
    class Ticket
    {
        public string Day { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Night { get; set; }
    }
    public class Country
    {//получает значения из списков со значениями для выпадающих списков
        public string Name { get; set; } = "";
        //public string Company { get; set; } = "";
        public override string ToString() => $"{Name}";
    }
    public class City
    {//получает значения из списков со значениями для выпадающих списков
        public string Name { get; set; } = "";
        //public string Company { get; set; } = "";
        public override string ToString() => $"{Name}";
    }
}
