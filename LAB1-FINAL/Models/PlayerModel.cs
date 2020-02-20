using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using LAB1_FINAL.Helpers;

namespace LAB1_FINAL.Models
{
    public class PlayerModel : IComparable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Club { get; set; }
        public int Salary { get; set; }

        public static bool First = true;
        public static string LogMostrar = "prueba";

        public static void C_Save(PlayerModel player)
        {
            Storage.Instance.C_playerList.Insert(player);
        }

        public static void S_Save(PlayerModel player)
        {
            Storage.Instance.S_playerList.AddLast(player);
        }

        public static void C_Delete(PlayerModel player)
        {
            Storage.Instance.C_playerList.Delete(player);
        }

        public static void Log(string time_elapsed, string operation)
        {
            string Path = System.AppContext.BaseDirectory + "Log.txt" ;
            if (PlayerModel.First)
            {
                PlayerModel.First = false;
                StreamWriter B = new StreamWriter(Path, false);
                B.Write("");
                B.Close();
            }
            if (!File.Exists(Path))
            {
                File.Create(Path);
            }
            StreamWriter ES = new StreamWriter(Path, true);
            ES.WriteLine("| Tiempo: " + time_elapsed + "ticks. | Operación realizada:" + operation + " |");
            ES.Close();
        }

        public int CompareTo(object obj)
        {
            var comparable = (PlayerModel)obj;
            int x;
            
            x = Name.CompareTo(comparable.Name);
            if (x != 0)
            {
                return x;
            }
            x = LastName.CompareTo(comparable.LastName);
            if (x != 0)
            {
                return x;
            }
            x = Club.CompareTo(comparable.Club);
            if (x != 0)
            {
                return x;
            }
            return x;
        }
    }
}