using AutoMapper;
using Client;
using EShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using ISession = EShop.Helpers.ISession;

namespace EShop.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUserAccess _userAccess;
        protected readonly ISession _session;
        protected readonly IMapper _mapper;
        protected ClientHelper _client;

        public BaseController(IUserAccess userAccess, ISession session, IMapper mapper)
        {
            _userAccess = userAccess;
            _session = session;
            _mapper = mapper;
            _client = new ClientHelper();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _client != null)
            {
                _client.Dispose();
                _client = null;
            }
        }
    }
}
