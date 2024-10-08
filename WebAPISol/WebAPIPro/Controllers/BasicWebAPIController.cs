using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicWebAPIController : ControllerBase
    {
        // Named Web APIs : Recommoanded

        [HttpGet]
        [Route("Show")]
        public void Show()
        {

        }

        [HttpGet]
        [Route("Showing")]
        public void Showing(int x)
        {

        }

        // http://localhost:19373/api/BasicWebAPI/Operations
        [HttpGet]
        [Route("Operations")]
        public IActionResult Operations([FromQuery]int x, int y, string opt)
        {
            try
            {
                int res = 0;
                switch (opt)
                {
                    case "+": { res = x + y; break; }
                    case "-": { res = x - y; break; }
                    case "*": { res = x * y; break; }
                    case "/": { res = x / y; break; }
                    case "%": { res = x % y; break; }
                    default: { res = 0; break; }
                }

                return Ok(res);
            }

            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }


        [HttpGet]
        [Route("Add")]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [HttpPost]
        [Route("Sub")]
        public int Sub(int x, int y)
        {
            return x - y;
        }

        [HttpPut]
        [Route("Mul")]
        public int Mul(int x, int y)
        {
            return x * y;
        }

        [HttpDelete]
        [Route("Div")]
        public IActionResult Div(int x, int y)
        {
            try
            {
                return Ok(x / y);
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }

        [HttpGet]
        [Route("Rem")]
        public int Rem(int x, int y)
        {
            return x % y;
        }

        [HttpGet]
        [Route("FindEvenOrOdd")]
        public IActionResult FindEvenOrOdd(int n)
        {
            try
            {
                string res = "";
                if (n % 2 == 0)
                {
                    res = "Even";
                }
                else
                {
                    res = "Odd";
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("Sorry for inconvineancs...!\nWe will solve this issue soon...!\n" + ex.Message);
            }
        }



        // Request Verb typed Web API Methods : [Not Recommaneded]
        // Create Method with Name as Request Type

        //[HttpGet]
        //public void Get()
        //{

        //}

        //[HttpGet]
        //public int Get(int x, int y)
        //{
        //    return x + y;
        //}

        //[HttpPost]
        //public string Post(string s1, string s2)
        //{
        //    return s1 + " " + s2;
        //}
    }
}
