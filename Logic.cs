using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class Logic {
   static bool flag;
   static Words words = new Words();
   static string key;
   static string value;
   
  
   public static void SetFlag(bool val) {flag = val;}
   public static void DetermineFlag(int val) {
      if (val == 1) {
         //Англо-русский == false
         flag = false;
      }
      if(val == 2) {
         // Русо-Англиский == true
         flag = true;
      }
   }
   public static void InitDictionary() {
      words.Init();
   }
   public static void Add() {
      if (flag == false) {
         Console.WriteLine("Введите слово на ENG");
         key = Console.ReadLine();
         Console.WriteLine("Введите перевод на RUS");
         value = Console.ReadLine();
         words.AddEngRusWord(key,value);
      }
      if (flag == true) {
         Console.WriteLine("Введите слово на RUS");
         key = Console.ReadLine();
         Console.WriteLine("Введите перевод на ENG");
         value = Console.ReadLine();
         words.AddRusEndWord(key, value);
      }
   }
   public static void Print() {
      if (flag == false) {
         Console.WriteLine("Введите слово на ENG");
         key = Console.ReadLine() ;
         words.PrintEngRus(key);
      }
      if (flag == true) {
         Console.WriteLine("Введите слово на RUS");
         key = Console.ReadLine();
         words.PrintRusEng(key);
      }
   }
   public static void Delete() {
      if (flag == false) {
         Console.WriteLine("Введите слово на ENG");
         key = Console.ReadLine();
         words.DeleteEngRus(key);
      }   
      if(flag == true) {
         Console.WriteLine("Введите слово на RUS");
         key = Console.ReadLine();
         words.DeleteRusEng(key);
      }
   }

   public static void PrintAll() {
      if (flag == false) {
         words.PrintEngRus();
      }
      if (flag == true) {
         words.PrintRusEng();
      }
   }

   public static void AddInFile() {
      if (flag == false) {
         words.AddInFail_EngRus(key);
      }
      if (flag==true) { 
         words.AddInFail_RusEng(key);
      }
   }

   public static void ReadInFile() {
      if (flag == false) {
         words.ReadInFile_EngRus();
      }
      if (flag == true) { 
         words.ReadInFile_RusEng();
      }
   }
}

