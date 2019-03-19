using System.Web.Http;

namespace MettHub.WebApp.Api.Controllers
{
    [RoutePrefix("Api")]
    public class MettCalculationController : ApiController
    {
        // GET api/mettcalculation?people={people}
        [Route("MettCalculation")]
        public int Get([FromUri] int people)
        {
            var gramPerPerson = 80;
            return people * gramPerPerson;
        }
    }
}