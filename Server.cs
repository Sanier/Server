public static class Server
{
    private static int count;
    private static ReaderWriterLock s_lock = new ReaderWriterLock();

    public static int GetCount()
    {
        s_lock.AcquireReaderLock(Timeout.InfiniteTimeSpan);
        try
        {
            return count;
        }
        finally
        {
            s_lock.ReleaseReaderLock();
        }
    }

    public static void AddToCount(int value)
    {
        s_lock.AcquireWriterLock(Timeout.InfiniteTimeSpan);
        count += value;
        s_lock.ReleaseWriterLock();
    }
}

