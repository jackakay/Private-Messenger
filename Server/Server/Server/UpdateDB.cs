using Newtonsoft.Json;

namespace Server
{
    public static class UpdateDB
    {
        public static void Update(DB db)
        {
            string json = JsonConvert.SerializeObject(db, Formatting.Indented);
            File.WriteAllText("db.json", json);
        }
    }
}
