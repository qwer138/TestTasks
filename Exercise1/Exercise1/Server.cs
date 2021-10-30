using System;

namespace Exercise1
{
    public static class Server
    {
        private static readonly RWLock locker;
        private static int _count;

        static Server()
        {
            locker = new RWLock();
            _count = 0;
        }

        /// <summary>
        /// Принимает запросы на чтение
        /// </summary>
        public static int GetCount()
        {
            using (locker.ReadLock())
            {
                int count = _count;
#if DEBUG
                Console.WriteLine("Count received");
#endif
                return count;
            }
        }

        /// <summary>
        /// Принимает запросы на запись
        /// </summary>
        public static void AddToCount(int value)
        {
            using (locker.WriteLock())
            {
                _count += value;
#if DEBUG
                Console.WriteLine("Count increased");
#endif
            }
        }
    }
}
