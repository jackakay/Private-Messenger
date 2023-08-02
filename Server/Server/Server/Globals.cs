using Newtonsoft.Json;

namespace Server
{
    public static class Globals
    {
        public static Root db;
        public static void Init()
        {
            db = JsonConvert.DeserializeObject<Root>(File.ReadAllText("db.json"));
            Console.WriteLine("Success");
    }
    }
}
