namespace ConsoleApp20
{
    class Program
    {
        static void Main(string[] args)
        {
            mainmenu maain = new mainmenu();
            int a;
            List<teacher> ta = maain.zapolnenie();
            do
            {
                maain.menu();
                a = Convert.ToInt32(Console.ReadLine());
                if (a >= 1 && a <= 5)
                {
                    switch (a)
                    {
                        case 1:
                            Console.Clear();
                            maain.predm(ta);
                            break;
                        case 2:
                            maain.poclmesto(ta);
                            Console.Clear();
                            break;
                        case 3:
                            maain.obcstag(ta);
                            Console.Clear();
                            break;
                        case 4:
                            maain.vsesotrud(ta);
                            Console.Clear();
                            break;
                        case 5:
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка");
                }
            }
            while (a != 5);
        }
    }
    public class teacher
    {
        public string? FIO;
        public string? data;
        public string? vuz;
        public List<string> rabota = new List<string>();
        public string? predmet;
    }
    public class mainmenu
    {
        public void menu()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Выборки:");
            Console.WriteLine("1.По предмету.");
            Console.WriteLine("2.По стажу работы в последнему месте.");
            Console.WriteLine("3.Общий стаж работы.");
            Console.WriteLine("4.Все сотрудники.");
            Console.WriteLine("5.Выход.");
            Console.WriteLine("===================================");
        }
        public List<teacher> zapolnenie()
        {
            Console.WriteLine("Введите кол-во учителей:");
            List<teacher> teach = new List<teacher>();
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                teacher tea = new teacher();
                Console.WriteLine("Введите ФИО учителя:");
                tea.FIO = Console.ReadLine();
                Console.WriteLine("Введите дату рождения учителя(день.месяц.год):");
                tea.data = Console.ReadLine();
                string? rabot = "0";
                List<string> rab = new List<string>();
                Console.WriteLine("---------------------------------------");
                while (true)
                {
                    Console.WriteLine("Место работы:");
                    rabot = Console.ReadLine();
                    if (rabot == "")
                    {
                        Console.WriteLine("---------------------------------------");
                        break;
                    }
                    Console.WriteLine("Дата устройства(год.месяц.день):");
                    string? dataystr = Console.ReadLine();
                    Console.WriteLine("Дата увольнения(год.месяц.день):");
                    string? datauv = Console.ReadLine();
                    string? raboti = rabot + " " + dataystr + " " + datauv;
                    rab.Add(raboti);
                    Console.WriteLine("---------------------------------------");
                }
                tea.rabota = rab;
                Console.WriteLine("Введите предмет, который ведет учитель:");
                tea.predmet = Console.ReadLine();
                teach.Add(tea);
                Console.Clear();
            }
            return teach;
        }
        public void predm(List<teacher> teach)
        {
            Console.WriteLine("Введите предмет:");
            string? prd = Console.ReadLine();
            Console.WriteLine("===================================");
            foreach (teacher c in teach)
            {
                if (c.predmet == prd)
                {
                    Console.WriteLine($"ФИО:{c.FIO}");
                    Console.WriteLine($"Дата рождения:{c.data}");
                    Console.WriteLine("Место работы:");
                    foreach (string a in c.rabota)
                    {
                        Console.WriteLine(a);
                    }
                    Console.WriteLine($"Предмет:{c.predmet}");
                    Console.WriteLine("===================================");
                }
            }
        }
        public void poclmesto(List<teacher> teach)
        {
            Console.WriteLine("Введите кол-во дней:");
            int stagdney = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите кол-во месяцев:");
            int stagmes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите кол-во лет:");
            int staggod = Convert.ToInt32(Console.ReadLine());
            int stagall = stagdney + stagmes * 30 + staggod * 30 * 12;
            foreach (teacher c in teach)
            {
                string[] poclmesto = c.rabota[c.rabota.Count - 1].Split(" ");
                DateTime ustr = DateTime.Parse(poclmesto[1]);
                DateTime uvol = DateTime.Parse(poclmesto[2]);
                TimeSpan stag = (uvol - ustr);
                int stag1 = int.Parse(stag.Days.ToString());
                if (stagall == stag1)
                {
                    Console.WriteLine($"ФИО:{c.FIO}");
                    Console.WriteLine($"Дата рождения:{c.data}");
                    Console.WriteLine("Место работы:");
                    foreach (string a in c.rabota)
                    {
                        Console.WriteLine(a);
                    }
                    Console.WriteLine($"Предмет:{c.predmet}");
                    Console.WriteLine("===================================");
                }
            }
        }
        public void obcstag(List<teacher> teach)
        {
            int stagall = 0;
            int obcstagg = 0;
            Console.WriteLine("Введите кол-во дней:");
            int stagdney = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите кол-во месяцев:");
            int stagmes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите кол-во лет:");
            int staggod = Convert.ToInt32(Console.ReadLine());
            stagall = stagdney + stagmes * 30 + staggod * 30 * 12;
            foreach (teacher f in teach)
            {

                foreach (string c in f.rabota)
                {
                    string[] stagg = c.Split(" ");
                    DateTime ustr = DateTime.Parse(stagg[1]);
                    DateTime uvol = DateTime.Parse(stagg[2]);
                    TimeSpan stag = (uvol - ustr);
                    obcstagg += int.Parse(stag.Days.ToString());
                }
                Console.WriteLine("===================================");
                if (stagall == obcstagg)
                {
                    Console.WriteLine($"ФИО:{f.FIO}");
                    Console.WriteLine($"Дата рождения:{f.data}");
                    Console.WriteLine("Место работы:");
                    foreach (string a in f.rabota)
                    {
                        Console.WriteLine(a);
                    }
                    Console.WriteLine($"Предмет:{f.predmet}");
                    Console.WriteLine("===================================");
                }
                obcstagg = 0;
            }
        }
        public void vsesotrud(List<teacher> teach)
        {
            foreach (teacher c in teach)
            {
                Console.WriteLine($"ФИО:{c.FIO}");
                Console.WriteLine($"Дата рождения:{c.data}");
                Console.WriteLine("Место работы:");
                foreach (string a in c.rabota)
                {
                    Console.WriteLine(a);
                }
                Console.WriteLine($"Предмет:{c.predmet}");
                Console.WriteLine("===================================");
            }
        }
    }
}