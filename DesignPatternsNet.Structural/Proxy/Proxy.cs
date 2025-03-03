using System;

namespace DesignPatternsNet.Structural.Proxy
{
    /// <summary>
    /// The Proxy has an interface identical to the RealSubject.
    /// </summary>
    public class Proxy : ISubject
    {
        private readonly RealSubject _realSubject;
        private string _cachedResult;
        private DateTime _cacheTime;
        private readonly TimeSpan _cacheDuration;

        public Proxy(RealSubject realSubject, TimeSpan cacheDuration)
        {
            _realSubject = realSubject;
            _cacheDuration = cacheDuration;
        }

        /// <summary>
        /// The most common applications of the Proxy pattern are lazy loading,
        /// caching, controlling the access, logging, etc. A Proxy can perform one of
        /// these things and then, depending on the result, pass the execution to the
        /// same method in a linked RealSubject object.
        /// </summary>
        public string Request()
        {
            if (string.IsNullOrEmpty(_cachedResult) || 
                DateTime.Now - _cacheTime > _cacheDuration)
            {
                // The first time or when cache expires, execute the real request
                Console.WriteLine("Proxy: Cache miss, executing real request...");
                _cachedResult = _realSubject.Request();
                _cacheTime = DateTime.Now;
                return $"{_cachedResult} (Fresh result)";
            }
            else
            {
                Console.WriteLine("Proxy: Returning cached result...");
                return $"{_cachedResult} (Cached result from {_cacheTime})";
            }
        }
    }
}
