using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPG.Models;

namespace RPG.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class Personagens : ControllerBase
    {
        private static List<Personagem> listaP = new List<Personagem>
        {
            new Personagem
            {
                Id = 1,
                Nome = "Peter",
                Sobrenome = "Parker",
                Fantasia = "Homem-Aranha",
                Local = "NY City"
            },
            new Personagem
            {
                Id = 2,
                Nome = "Bruce",
                Sobrenome = "Wayne",
                Fantasia = "Batmam",
                Local = "Gotham"
            },
            new Personagem
            {
                Id = 3,
                Nome = "Thorfinn",
                Sobrenome = "Thorsson",
                Fantasia = "Gurreiro",
                Local = "Viland"
            },
            new Personagem
            {
                Id = 4,
                Nome = "Virgil",
                Sobrenome = "Ovid",
                Fantasia = "Super-Choque",
                Local = "Dakota"
            },
            new Personagem
            {
                Id = 5,
                Nome = "Barry",
                Sobrenome = "Allen",
                Fantasia = "Flash",
                Local = "Central City"
            },
        };

        [HttpGet]
        public async Task<ActionResult<List<Personagem>>> TodosPersonagens()
        {
            return Ok(listaP);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<Personagem>>> UnicoPersonagem(int id)
        {
            var personagem = listaP.Find(x => x.Id == id);

            if (personagem is null)
                return NotFound("Personagem não encontrado");

            return Ok(personagem);
        }

        [HttpGet("cidade/{local}")]

        public async Task<ActionResult<List<Personagem>>> LocalPersonagem(string local)
        {
            var personagem = listaP.FindAll(x => x.Local == local);

            if (personagem is null)
                return NotFound("Personagem não encontrado");

            return Ok(personagem);
        }

        [HttpPost]

        public async Task<ActionResult<List<Personagem>>> AddPersonagem(Personagem novo)
        {
            int idFinal = listaP[listaP.Count - 1].Id;
            novo.Id = idFinal + 1;
            listaP.Add(novo);
            return Ok(listaP);
        }

        [HttpPut]

        public async Task<ActionResult<List<Personagem>>> EditPersonagem(int id, Personagem editado)
        {
            var pesquisa = listaP.Find(x => x.Id == id);

            if (pesquisa is null)
                return NotFound("Personagem não existe");

            pesquisa.Nome = editado.Nome is null ? pesquisa.Nome : editado.Nome;
            pesquisa.Sobrenome = editado.Sobrenome is null ? pesquisa.Sobrenome : editado.Sobrenome;
            pesquisa.Fantasia = editado.Fantasia is null ? pesquisa.Fantasia : editado.Fantasia;
            pesquisa.Local = editado.Local is null ? pesquisa.Local : editado.Local;

            return  Ok(pesquisa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Personagem>>> RemovePersonagem(int id)
        {
            var deleta = listaP.Find(x => x.Id == id);

            if (deleta is null)
                return NotFound("Personagem não existe");

            listaP.Remove(deleta);
            return Ok(listaP);
        }

    }
}
