using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cambalache.Entities;
using cambalache.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Hosting;

namespace cambalache.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;
        IHostingEnvironment env = null;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/values
        [EnableCors("MyPolicy")]
        [HttpGet]
        public async Task<IEnumerable<Product>> Get([FromQuery] string name,
                                                    [FromQuery] int? type,
                                                    [FromQuery] double? min,
                                                    [FromQuery] double? max)
        {
            var retu = await _productRepository.Get(name,type,max,min);
            return retu;
        }

        // GET api/values/5
        [EnableCors("MyPolicy")]
        [HttpGet("{id}")]
        public async Task<Product> GetAsync(int id)
        {
            return await _productRepository.Get(id);
        }

        // POST api/values
        [EnableCors("MyPolicy")]
        [HttpPost]
        public void Post([FromBody] Email email)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("Admin", email.emailContact);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("User", "joc_ortizc10@hotmail.com");
            message.To.Add(to);

            message.Subject = email.subject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = email.message;

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, false);
            client.Authenticate("prueba@gmail.com", "mazkom-wubty6-hYtrep");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

        }
        // DELETE api/values/5
        [EnableCors("MyPolicy")]
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _productRepository.Delete(id);
        }
    }
}
