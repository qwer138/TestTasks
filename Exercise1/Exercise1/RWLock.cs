using System;
using System.Threading;

namespace Exercise1
{
    public class RWLock
    {
        public struct WriteLockToken : IDisposable
        {
            private readonly ReaderWriterLockSlim writeLocker;
            public WriteLockToken(ReaderWriterLockSlim locker)
            {
                writeLocker = locker;
                locker.EnterWriteLock();
            }
            public void Dispose()
            {
                writeLocker.ExitWriteLock();
            }
        }

        public struct ReadLockToken : IDisposable
        {
            private readonly ReaderWriterLockSlim readLocker;
            public ReadLockToken(ReaderWriterLockSlim locker)
            {
                readLocker = locker;
                locker.EnterReadLock();
            }
            public void Dispose()
            {
                readLocker.ExitReadLock();
            }
        }

        private readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

        public ReadLockToken ReadLock()
        {
            return new ReadLockToken(locker);
        }

        public WriteLockToken WriteLock()
        {
            return new WriteLockToken(locker);
        }

        public void Dispose()
        {
            locker.Dispose();
        }
    }
}
