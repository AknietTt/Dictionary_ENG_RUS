class Program {
   public static void Main(String[] args) {
      bool parse;
      int choice;
      Logic.InitDictionary();
      Console.WriteLine("Выберите ");
      Console.WriteLine("1) Англо-русский ");
      Console.WriteLine("2) Русо-Англиский ");
      parse = int.TryParse(Console.ReadLine(), out choice);
      Logic.DetermineFlag(choice);
      if (parse) {
         while (true) {
            Console.WriteLine("1)Добавить");
            Console.WriteLine("2)Найти");
            Console.WriteLine("3)Удалить");
            Console.WriteLine("4)Посмотреть словарь");
            Console.WriteLine("5)Изменить словарь");
            Console.WriteLine("6)Посмотреть сохраненные слова");
            parse = int.TryParse(Console.ReadLine(), out choice);
            if (parse) {
               //choice = int.Parse(Console.ReadLine());
               if (choice == 1) {
                  Logic.Add();
               }
               if (choice == 2) {
                  Logic.Print();

                  Console.WriteLine("1)Сохранить  в файл");
                  choice = int.Parse(Console.ReadLine());
                  if (choice == 1) {
                     Logic.AddInFile();
                  }
               }
               if (choice == 3) {
                  Logic.Delete();
               }
               if (choice == 4) {
                  Logic.PrintAll();
                 
                  Console.WriteLine("Введите любую цифру ");
                  choice = int.Parse(Console.ReadLine());
               }
               if (choice == 5) {
                  Console.WriteLine("1) Англо-русский ");
                  Console.WriteLine("2) Русо-Англиский ");
                  choice = int.Parse(Console.ReadLine());
                  Logic.DetermineFlag(choice);
               }
               if (choice == 6) {
                  Logic.ReadInFile();
                  Console.WriteLine("Введите любую цифру ");
                  choice = int.Parse(Console.ReadLine());
               }
               else {
                  Console.WriteLine("Вы ввели не каректно ");
                 
               }
               Console.Clear();
            }

          
         }
      }
      else {
         Console.WriteLine("Вы вели не каректно ");
      }
   }
}