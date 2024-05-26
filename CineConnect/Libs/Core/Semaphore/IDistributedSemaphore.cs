namespace Core.Semaphore;

public interface IDistributedSemaphore
{
    Task<bool> WaitAsync(string key, TimeSpan timeout);
    Task ReleaseAsync(string key);
}