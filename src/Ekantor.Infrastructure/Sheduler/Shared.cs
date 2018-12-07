namespace Exchange.Infrastructure.Sheduler
{
    public sealed class Shared
    {
        private static Shared instance = null;
        private static readonly object padlock = new object();
        public bool ApiIsAlive { get; set; }

        private Shared()
        {
        }

        public static Shared Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Shared();
                    }
                    return instance;
                }
            }
        }
    }
}