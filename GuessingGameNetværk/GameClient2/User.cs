namespace GameClient
{
    class User
    {
        public string Name { get; set; }
        public bool IsReady { get; set; }

        public override string ToString()
        {
            string s = IsReady ? "Ready" : "Not ready";

            return $"{Name}: {s}";
        }


    }
}