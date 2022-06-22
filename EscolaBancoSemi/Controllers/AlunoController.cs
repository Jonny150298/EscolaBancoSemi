using EscolaBancoSemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscolaBancoSemi.Controllers
{
    public class AlunoController : Controller
    {
        private readonly EscolaContext _context;

        public AlunoController(EscolaContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alunos.ToListAsync());
        }

        public IActionResult FormularioSalvar()
        {
            return View();
        }

        public async Task<IActionResult> Salvar(Aluno aluno)
        {
            Aluno existe = await _context.Alunos.FindAsync(aluno.Id);
            if (existe == null)
            {
                _context.Alunos.Add(aluno);
                await _context.SaveChangesAsync();

            }
            else
            {
                _context.Entry(existe).CurrentValues.SetValues(aluno);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Excluir(int Id)
        {
            Aluno excluir = await _context.Alunos.FindAsync(Id);
            _context.Alunos.Remove(excluir);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> FormularioEditar(int Id)
        {
            Aluno atualizar = await _context.Alunos.FindAsync(Id);
            return View("FormularioSalvar", atualizar);
        }
    }
}
