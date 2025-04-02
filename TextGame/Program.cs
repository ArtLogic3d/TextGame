class CommonVariables // main parameters for game Common variables
{
    public static byte choise_x = 0; // check
    public static byte time = 72;
    public static bool key = false; //
    public static bool strenght = false;  //
}
class Cat // parameters cat
{
    public static string name = "";
    public byte weight = 4;
    public static byte healh = 100;
    public static byte stamina = 100;
    public static bool alive = true;
    public static byte strength = 4;
    public static byte Carefulness = 10;

}
class Metods // methods often used
{
    public static int GetRandomNumber(int min, int max) // Metod Ranodm
    {
        Random rnd = new Random();
        int rnd_check = rnd.Next(min, max + 1);  // creates a number between min and max
        return rnd_check;
    }
    public static void GetAnswers(bool press) // universal metod for answers
    {
        Console.WriteLine("Напиши цифру от 1 до 5.");
        while (press == true)
        {
            switch (Byte.Parse(Console.ReadLine()))
            {
                case 1: CommonVariables.choise_x = 1; Console.WriteLine("Ваш выбор - " + CommonVariables.choise_x); press = false; break;
                case 2: CommonVariables.choise_x = 2; Console.WriteLine("Ваш выбор - " + CommonVariables.choise_x); press = false; break;
                case 3: CommonVariables.choise_x = 3; Console.WriteLine("Ваш выбор - " + CommonVariables.choise_x); press = false; break;
                case 4: CommonVariables.choise_x = 4; Console.WriteLine("Ваш выбор - " + CommonVariables.choise_x); press = false; break;
                case 5: CommonVariables.choise_x = 5; Console.WriteLine("Ваш выборм - " + CommonVariables.choise_x); press = false; break;
                default: press = true; Console.WriteLine("Неверно, напиши цифру от 1 до 5."); continue;
            }
        }

    }
    public static byte CheckStrength(byte x) // Метод проверки силы
    {
        byte min = 1;
        if (x > 5) min = (byte)(x / 2);
        else min = (byte)(x / 3);
        int result = GetRandomNumber(min, x);
        Console.WriteLine("Сила котика - " + Cat.strength);
        Console.WriteLine("Проверка силы - " + result);
        return (byte)result;
    }
    public static void PressAnyKey()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения.");
        Console.ReadKey();
    }
}
class Events // other events this game
{
    public static void StartStory() // start theme and story
    {
        Console.WriteLine(@"         Текствый квест от ArtLogic. 
      ---Отважный кот---
      Вы виртуально управляете котиком, который остался один в загородном доме.
    Так случилось, что хозяин очень спешил и забыл оставить котику еду
    и закрыть входную дверь, так как у него случилась беда.
    Когда он вспомнил, что забыл это сделать, ему стало еще хуже,
    но он питал надежду на сообразительность и смекалку котика.
      
      Стартовые условия:");
        Console.WriteLine(@"
      Хозяин уехал на три дня.

      Время года - Осень.

      Характеристики котика:

      - Возраст: 2 года
      - Порода: Сфинкс Эльф.
      - Вес: около 5 кг.
      - Характер: Активный, любопытный, немножко трусливый.
      - Здоровье: Здоровый, нормально телосложения.
      - Привычки: любит вкусняхи, спит в теплых местах, играется со звонкими предметами.

      За это время котик сильно проголодается, но не истощиться,  так как в доме есть несколько
    мисок с водой, которых хватит больше, чем на 3 дня, если они будет не перевернуты.

      Если котик не будет пить, у него с каждым днем будет падать выносливость и силы,
    что влияет на проверку навыка.

      Если котик не будет есть, у него с каждый днем будет уменьшаться запас здоровья и
    внимательность, это важно, так как получив повреждение и не поев, можно погибнуть и также
    влияет на проверку навыка.

      Так как дом - загородный, очень опасно выходить за открытую дверь, а также существует
    вероятность, что в дом может пробраться какой либо зверь, но если быть предельно осторожным,
    можно найти как еду, так и различные приключения.

      Ваша цель найти еду и остаться в живых до приезда хозяина.
      
      Удачи!
      
      ");
        Console.WriteLine("Введите имя котика:");
        Cat.name = Console.ReadLine();
        Console.WriteLine("Вашего котика зовут: " + Cat.name);
        Metods.PressAnyKey();
    }
}
class Program
{
    public static void Main(string[] args) // BODY GAME
    {
        Events.StartStory();

        Console.WriteLine("Тебе нужно открыть дверь.");
        Console.WriteLine("Твои действия:");
        Console.WriteLine("1 - Достать ключ и открыть дверь, 2 - Попытаться выбить, 3 - Вскрыть отмычкой, 4 - Вернуться в другую комнату, 5 - Выйти из игры");

        for (byte i = 0; i < 3; i++) // 3 попытки решить задачу, если с первог раза не проходит
        {
            Metods.GetAnswers(true); // Вызов метода для ответов
            switch (CommonVariables.choise_x)
            {
                case 1: //key
                    {
                        Console.WriteLine("У вас есть ключ?");
                        Console.WriteLine("1 - Да, 2 - Нет");
                        switch (Byte.Parse(Console.ReadLine()))
                        {
                            case 1: CommonVariables.key = true; break;
                            case 2: CommonVariables.key = false; break;
                        }
                        if (CommonVariables.key == true) // проверка на ключ
                        {
                            i = 3; Console.WriteLine("Door is open"); // выход из цикла
                        }
                        else Console.WriteLine("Door is not open, your key is wrong.");
                        break;

                    }
                case 2: // strh
                    {
                        for (byte ci = 1; i < 4; ci++)
                        {
                            if (Metods.CheckStrength((byte)(Cat.strength)) > 2)
                            {
                                Console.WriteLine("Сломать дверь удалось");
                                Metods.PressAnyKey();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Сломать дверь не удалось");
                                continue;
                            }

                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Lock is crash, door is open.");

                        break;
                    }
                case 4: Console.WriteLine("We back room"); break;
                case 5: Console.WriteLine("Goodbay"); break;

            }
        }
    }
}