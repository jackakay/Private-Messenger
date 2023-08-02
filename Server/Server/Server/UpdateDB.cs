using Newtonsoft.Json;

namespace Server
{
    public static class UpdateDB
    {
        public static void Update(Root db)
        {
            string json = JsonConvert.SerializeObject(db, Formatting.Indented);
            File.WriteAllText("db.json", json);
        }
    }
}
