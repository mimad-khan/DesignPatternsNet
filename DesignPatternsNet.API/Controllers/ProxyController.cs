using DesignPatternsNet.Structural.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace DesignPatternsNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProxyController : ControllerBase
    {
        private static readonly RealSubject _realSubject = new RealSubject();
        private static readonly Proxy _proxy = new Proxy(_realSubject, TimeSpan.FromSeconds(10));

        [HttpGet("direct")]
        public IActionResult DirectRequest()
        {
            var stopwatch = Stopwatch.StartNew();
            var result = _realSubject.Request();
            stopwatch.Stop();

            return Ok(new
            {
                Result = result,
                ExecutionTime = $"{stopwatch.ElapsedMilliseconds}ms",
                Message = "Request handled directly by the RealSubject."
            });
        }

        [HttpGet("proxy")]
        public IActionResult ProxyRequest()
        {
            var stopwatch = Stopwatch.StartNew();
            var result = _proxy.Request();
            stopwatch.Stop();

            return Ok(new
            {
                Result = result,
                ExecutionTime = $"{stopwatch.ElapsedMilliseconds}ms",
                Message = "Request handled through the Proxy (with caching)."
            });
        }

        [HttpGet("compare")]
        public IActionResult CompareRequests()
        {
            // First direct request
            var directStopwatch = Stopwatch.StartNew();
            var directResult = _realSubject.Request();
            directStopwatch.Stop();
            var directTime = directStopwatch.ElapsedMilliseconds;

            // First proxy request (cache miss)
            var proxyStopwatch1 = Stopwatch.StartNew();
            var proxyResult1 = _proxy.Request();
            proxyStopwatch1.Stop();
            var proxyTime1 = proxyStopwatch1.ElapsedMilliseconds;

            // Second proxy request (cache hit)
            var proxyStopwatch2 = Stopwatch.StartNew();
            var proxyResult2 = _proxy.Request();
            proxyStopwatch2.Stop();
            var proxyTime2 = proxyStopwatch2.ElapsedMilliseconds;

            return Ok(new
            {
                DirectRequest = new
                {
                    Result = directResult,
                    ExecutionTime = $"{directTime}ms"
                },
                FirstProxyRequest = new
                {
                    Result = proxyResult1,
                    ExecutionTime = $"{proxyTime1}ms",
                    IsCached = false
                },
                SecondProxyRequest = new
                {
                    Result = proxyResult2,
                    ExecutionTime = $"{proxyTime2}ms",
                    IsCached = true
                },
                Message = "Proxy pattern successfully demonstrated with caching."
            });
        }
    }
}
