using Microsoft.AspNetCore.Mvc;

namespace Geekcode.Document.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Document("测试类")]
public class TestController : ControllerBase
{
    [Document("心跳")]
    [HttpGet(Name = "Invoke")]
    public string Invoke() => "OK";
    
    [Document("测试方法1")]
    [HttpGet(Name = "Method1")]
    public string Method1() => "Method1";
}