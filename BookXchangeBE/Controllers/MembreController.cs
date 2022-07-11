using BookXchangeBE.BLL.Services;
using BookXchangeBE.Models;
using BookXchangeBE.Models.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BookXchangeBE.Controllers
{
    public class MembreController : Controller
    {

        private MembreService membreService;

        public MembreController(MembreService membreService)
        {
            this.membreService = membreService;
        }

        public IActionResult MemberList()
        {
            IEnumerable<Membre> membres = membreService.GetAll()
                .Select(b => b.ToModel())
                .OrderBy(b => b.Pseudo);

            return View(membres);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([FromForm] MembreRegister membreRegister)
        {
            if (!ModelState.IsValid)
            {
                return View(membreRegister);
            }

            // Check if Member exists
            if (membreService.CheckMemberExists(membreRegister.Pseudo, membreRegister.Email))
            {
                ModelState.AddModelError("", "Le compte existe déjà.");
                return View(membreRegister);
            }


            // Save Member in DB
            Membre membre = membreService.Insert(
                membreRegister.Pseudo,
                membreRegister.Email,
                membreRegister.Password,
                membreRegister.Role
            ).ToModel();

            // TODO Store Member in Session
            Console.WriteLine($"Member create with id {membre.IdMembre}");

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromForm] MembreLogin membreLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(membreLogin);
            }


            // Validation du hashage du mot de passe
            if (!membreService.CheckCredentials(membreLogin.Pseudo, membreLogin.Password))
            {
                ModelState.AddModelError("", "Les credentials ne sont pas valide");
                return View(membreLogin);
            }

            // Récuperation du compte via son pseudo
            Membre membre = membreService.GetByPseudo(membreLogin.Pseudo).ToModel();

            // TODO Store Member in Session
            Console.WriteLine($"Member login with id {membre.IdMembre}");



            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            return View();
        }

    }
}
