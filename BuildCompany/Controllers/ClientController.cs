using BuildCompanyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BuildCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private DataContext db;
        public ClientController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return db.Clients.ToList();
        }
        [HttpGet("{id}")]
        public Client GetClient(int id)
        {
            return db.Clients.Where(p => p.IdClient == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveClient([FromBody] Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateClient([FromBody] Client client)
        {
            db.Clients.Update(client);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteClient(long id)
        {
            db.Clients.Remove(db.Clients.Where(p => p.IdClient == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
