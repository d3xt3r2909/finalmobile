using ESBX_API.Helper;
using ESBX_db.Helper;
using ESBX_db.Models;
using ESBX_db.ViewModel;
using Newtonsoft.Json; 
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ESBX_API.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Login(AccountLoginVm account)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
            Korisnici korisnikLogin = AccountHelper.CheckLogin(account);

            if (korisnikLogin == null)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized); 
            }

            return Request.CreateResponse(HttpStatusCode.Accepted, korisnikLogin); 
        }

        [HttpGet]
        [Route(WebApiRoutes.GET_ULOGA_BY_KORISNIK + "{id}")]
        public HttpResponseMessage GetUlogaByKorisnikId(int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Uloge uloga = AccountHelper.GetUlogaByKorisnikId(id);

            if (uloga == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, uloga);
        }

        [HttpPost]
        [Route(WebApiRoutes.POST_REGISTER)]
        public HttpResponseMessage Registration(AccountRegistrationVm account)
        {
            List<string> errors = new List<string>();
            if (!ModelState.IsValid)
            {
                
                foreach (var pair in ModelState)
                    if (pair.Value.Errors.Count > 0)
                        errors.Add(pair.Value.Errors.Select(error => error.ErrorMessage).FirstOrDefault().ToString());

                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }

            HttpStatusCode response = AccountHelper.CreateAccount(account, AccountHelper.GetUloge(Constants.ULOGA_KORISNIK));

            if (HttpStatusCode.Conflict == response)
            {
                errors.Add("Korisnicki nalog vec postoji");
                return Request.CreateResponse(HttpStatusCode.Conflict, errors);
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("api/account/message")]
        public HttpResponseMessage MessageUser(EmailVm emailInfo)
        {
            bool result = AccountHelper.Sendemail(emailInfo);
            HttpStatusCode status = result ? HttpStatusCode.OK : HttpStatusCode.Forbidden; 

            return Request.CreateResponse(status, result);
        }

    }
}
