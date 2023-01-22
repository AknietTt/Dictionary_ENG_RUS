using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
class Words {
   private Dictionary<string,List<string>> en_ru = new Dictionary<string,List<string>>();
   private Dictionary<string,List<string>> ru_en = new Dictionary<string,List<string>>();
   string filePath_EngRus = "SavedDictionaryEng_Rus.txt";
   string filePath_RusEng = "SavedDictionaryRus_Eng.txt";
   string Init_EngRus = "DataDictionaryEng_Rus.txt";
   string Init_RusEng = "DataDictionaryRus_Eng.txt";
   // русско - анг
   public void AddEngRusWord(string key,string value) {
      if (en_ru.ContainsKey(key)) {
         en_ru[key].Add(value);
      }
      else {
         en_ru[key] = new List<string>();
         en_ru[key].Add(value);
      }
   }
   // англо русски
   public void AddRusEndWord(string key, string value) {
      if (ru_en.ContainsKey(key)) {
         ru_en[key].Add(value);
      }
      else {
         ru_en[key] = new List<string>();
         ru_en[key].Add(value);
      }
   }



   // англо русски
   public void PrintEngRus(string key) {
      foreach (var item in en_ru) {
         if (item.Key == key) {
            for (int i = 0; i < en_ru[key].Count; i++) {
               Console.WriteLine(en_ru[key][i]);
            }
         }
      }
   }
   public void PrintEngRus() {
      foreach (var iter in en_ru) {
         for (int i = 0; i < iter.Value.Count; i++) {
            Console.WriteLine($"слово: {iter.Key}  перевод: {iter.Value[i]}");
         }
      }
   }
   // русско - анг
   public void PrintRusEng(string key) {
      foreach (var item in ru_en) {
         if (item.Key == key) {
            for (int i = 0; i < ru_en[key].Count; i++) {
               Console.WriteLine(ru_en[key][i]);
            }
         }
      }
   }
   public void PrintRusEng() {
      foreach (var iter in ru_en) {
         for (int i = 0; i < iter.Value.Count; i++) {
            Console.WriteLine($"слово: {iter.Key}  перевод: {iter.Value[i]}");
         }
      }
   }

   // англо русски
   public void DeleteEngRus(string key) {en_ru.Remove(key);}
   // русско - анг
   public void DeleteRusEng(string key) { ru_en.Remove(key); }

   public void AddInFail_EngRus(string key) {
      using (FileStream fs = new FileStream(filePath_EngRus, FileMode.Append, FileAccess.Write, FileShare.None)) {
         using (StreamWriter writer = new StreamWriter(fs, Encoding.Unicode)) {
            writer.Write(key+"/");
            for (int i = 0; i < en_ru[key].Count; i++) {
               writer.Write(en_ru[key][i]+",");
            }
            writer.Write("\n");
            Console.WriteLine("Information recorded!");
         }
      }
   }

   public void ReadInFile_EngRus() {
      string s;
      using (var f = new StreamReader(filePath_EngRus, Encoding.Unicode)) {
         while ((s = f.ReadLine()) != null) {
            Console.WriteLine(s);
         }
      }
   }


   public void AddInFail_RusEng(string key) {
      using (FileStream fs = new FileStream(filePath_RusEng, FileMode.Append, FileAccess.Write, FileShare.None)) {
         using (StreamWriter writer = new StreamWriter(fs, Encoding.Unicode)) {
            writer.Write(key+"/");
            for (int i = 0; i < ru_en[key].Count; i++) {
               writer.Write(ru_en[key][i]+",");
            }
            writer.Write("\n");
            Console.WriteLine("Information recorded!");
         }
      }
   }

   public void ReadInFile_RusEng() {
      string s;
      using (var f = new StreamReader(filePath_RusEng, Encoding.Unicode)) {
         while ((s = f.ReadLine()) != null) {
            Console.WriteLine(s);
         }
      }
   }

   public void Init() {
      StreamReader f = new StreamReader(Init_EngRus);
      while (!f.EndOfStream) {
         string s = f.ReadLine();
         string[] arr = s.Split(':');
         string value = arr[1];
         if (arr.Length > 2) {
            en_ru.Add(arr[0], new List<string>(arr[1].Split(',')));
         }
         else {
            en_ru.Add(arr[0], new List<string> { value });
         }
      }
      f.Close();


      StreamReader f2 = new StreamReader(Init_RusEng);
      while (!f2.EndOfStream) {
         string s = f2.ReadLine();
         string[] arr = s.Split(':');
         string value = arr[1];
         if (arr.Length > 2) {
            ru_en.Add(arr[0], new List<string>(arr[1].Split(',')));
         }
         else {
            ru_en.Add(arr[0], new List<string> { value });
         }
      }
      f2.Close();
   }
}
