using Newtonsoft.Json;

namespace Server
{
    public static class Globals
    {
        public static Root? db;
        public static void Init()
        {
            string json = File.ReadAllText("db.json");

            
            db = JsonConvert.DeserializeObject<Root>(json);
            Console.WriteLine(json);
            Console.WriteLine("Success");
    }
    }
}
