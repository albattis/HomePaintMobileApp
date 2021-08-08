using System;
using System.Collections.Generic;
using System.Text;

namespace HomePaint.Views.Languange
{
   public class LangSelect
    {
        Dictionary<string, string> HunEng = new Dictionary<string, string>();
        public LangSelect() { }
        void LoadWordInDictionary()
        {
            HunEng.Add("Kezdés", "Start");
            HunEng.Add("Üdvözli a Home Paint 1.0", "Welcome Home Paint 1.0");
            HunEng.Add("Home Paint 1.0", "Home Paint 1.0");
            HunEng.Add("Eddig hozzáadva:", "Added so far");
            HunEng.Add("Szoba oldalainak adatai", "Room Data");
            HunEng.Add("Új ajtó hozzáadása", "Add new door");
            HunEng.Add("Új téglalap ablak hozzáadása", "");

        }

        public string fordit(string forditando)
        {
            foreach (var item in HunEng)
            {
                if (item.Key == forditando)
                {
                    return item.Value;
                }
            }
            return "";
        }

    }
}
