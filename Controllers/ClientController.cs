using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Data;

namespace canalsat.Controllers;

public class ClientController : Controller
{
    private readonly MyAppContext _dbContext;
    private readonly DbAccessor _DbAccessor;

    public ClientController(MyAppContext dbContext, DbAccessor dbAccessor)
    {
        _dbContext = dbContext;
        _DbAccessor = dbAccessor;
    }

    public IActionResult Abonnement_perso(string idclient) {
        List<Chaine> chaines = _dbContext.Chaines.ToList() as List<Chaine>;
        Client client = new Client().getClientById(idclient);
        List<Chaine> chainesDispo = client.GetChainesDispo(chaines);
        ViewData["allChaines"] = chaines;
        ViewData["chainesDispo"] = chainesDispo;
        ViewData["client"] = client;
        return View();
    }

    public IActionResult Abonnement(string idclient, string idab)
    {
        Client client = new Client().getClientById(idclient);
        Abonnement ab = new Abonnement().getAbonnementById(idab);
        Abonnement abEnCours = client.GetAbonnementEncours();
        DateTime dateDeb = DateTime.Now;
        DateTime dateFin = dateDeb.AddDays(30);
        AbonnementClient newAB = new AbonnementClient(
            client,
            ab,
            dateDeb,
            dateFin
        );

        if(abEnCours != null) {
            AbonnementClient lastAbonnement = client.GetLastAbonnement();
            dateDeb = lastAbonnement.dateFin.AddDays(1); //ajout d'1 jour de la fin du last pour le début
            dateFin = dateDeb.AddDays(30);
            newAB = new AbonnementClient(
                client,
                ab,
                dateDeb,
                dateFin
            );
        }

        //newAB.Insert();

        //RETOURNE LA VIEW DETAIL
        int id = int.Parse(idclient);
        var details = _DbAccessor.GetClientDetails(id);
        client.id = id;
        client = client.getClientById();
        ViewData["details"] = details;
        ViewData["client"] = client;
        var abs = _DbAccessor.AbonnementDispos(id);
        if(abEnCours == null) {
            ViewData["abs"] = abs;
        }
        else {
            List<AbonnementDispo> absDispo = new List<AbonnementDispo>();
            foreach (AbonnementDispo abd in abs)
            {
                if(abd.abonnement.getPrixRemise() >= abEnCours.getPrixRemise()) {
                    absDispo.Add(abd);
                }
            }
            ViewData["abs"] = absDispo;
        }
        ViewData["abEnCours"] = abEnCours;
        return View("Detail");
        //return View(clients);
    }

    /*public IActionResult reAB()
    {
        var abs = _dbContext.Abonnements.ToList();
        ViewData["abs"] = abs;
        return View();
        //return View(clients);
    }*/

    public IActionResult Detail(int id)
    {
        //var clients = _dbContext.Clients.ToList();
        var details = _DbAccessor.GetClientDetails(id);
        var client = new Client();
        client.id = id;
        client = client.getClientById();
        ViewData["details"] = details;
        ViewData["client"] = client;
        Abonnement abEnCours = client.GetAbonnementEncours();
        var abs = _DbAccessor.AbonnementDispos(id);
        if(abEnCours == null) {
            ViewData["abs"] = abs;
        }
        else {
            List<AbonnementDispo> absDispo = new List<AbonnementDispo>();
            foreach (AbonnementDispo ab in abs)
            {
                if(ab.abonnement.getPrixRemise() >= abEnCours.getPrixRemise()) {
                    absDispo.Add(ab);
                }
            }
            ViewData["abs"] = absDispo;
        }
        ViewData["abEnCours"] = abEnCours;
        return View();
        //return View(clients);
    }

    public IActionResult Index()
    {
        //var clients = _dbContext.Clients.ToList();
        var ClientListes = new Client().getAllClients();
        ViewData["ClientListes"] = ClientListes;
        return View();
        //return View(clients);
    }
}

