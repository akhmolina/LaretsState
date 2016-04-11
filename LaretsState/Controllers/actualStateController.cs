using System.Web.Http;

namespace LaretsState
{
    public class actualStateController : ApiController
    {
        // GET api/actualState
        public actualState Get()
        {
            return state.actualState;
        }

    }
}