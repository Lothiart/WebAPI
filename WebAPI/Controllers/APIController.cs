using Business.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Repositories;
using Entities;
using System.Diagnostics;

namespace WebAPI.Controllers
{
	[Route("api/[controller][action]")]
	[ApiController]
	public class APIController : ControllerBase
	{

		//Projet ASP.NET Core API
		//Entité + context => BDD
		//Repository => en mode dossier

		//API :
		//GetAll
		//GetById
		//Search
		//Post
		//Put
		//Delete

		private IClientBusiness _clientBusiness;
        private IArticleBusiness _articleBusiness;

        public APIController(IClientBusiness clientBusiness, IArticleBusiness articleBusiness)
        {
            this._clientBusiness = clientBusiness;
            this._articleBusiness = articleBusiness;
        }
        /// <summary>
        ///  Fonction qui créer un client
        /// </summary>
		/// <param name="name">Nom du client</param>
		/// <param name="description">description</param>
		
        [HttpPost]
		public async Task<ActionResult> Create(string name, string description)
		{
			Client client = new Client() { Name = name, Description = description };
			if (await _clientBusiness.Create(client))
			{
				return Ok(client);
			}
			else
			{
				return StatusCode(402, "client non créé");
			}
		}
        /// <summary>
        ///  Fonction qui supprime un client
        /// </summary>
        /// <param name="id">Id du Client</param>
        [HttpGet]
		public async Task<ActionResult> Delete(int id)
		{
			if (await _clientBusiness.Delete(id))
			{
				return Ok("client supprimé");
			}
			else
			{
				return StatusCode(402, "client non supprimé");
			}
		}
        /// <summary>
        ///  Fonction qui récupère un cient par so Id
        /// </summary>
        /// <param name="id">id du client</param>
        [HttpGet]
		public async Task<ActionResult> GetById(int id)
		{
			Client client = await _clientBusiness.Read(id);
			if (client != null)
			{
				return Ok(client);
			}
			else
			{
				return StatusCode(402, "client n'existe pas");
			}
		}
        /// <summary>
        ///  Fonction qui récupère tout les clients
        /// </summary>
        [HttpGet]
		public async Task<ActionResult> GetAll()
		{
			List<Client> clients = await _clientBusiness.GetClients();
			if (clients != null)
			{
				return Ok(clients);
			}
			else
			{
				return StatusCode(402, "pas de clients");
			}
		}
        /// <summary>
        ///  Fonction qui récupère tout les clients en DTO
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAllDTO()
        {
            Task<List<ClientDTO>> clients =  _clientBusiness.GetClientsDTO();
            if (clients != null)
            {
                return Ok(clients);
            }
            
            else
            {
                return StatusCode(402, "pas de clients");
            }
        }
        /// <summary>
        ///  Fonction qui cherche un client
        /// </summary>
        /// <param name="str">Recherche</param>
        [HttpGet]
		public async Task<ActionResult> Search(string str)
		{
			List<Client> clients = await _clientBusiness.Search(str);
			if (clients != null)
			{
				return Ok(clients);
			}
			else
			{
				return StatusCode(402, "pas de clients");
			}
		}
        /// <summary>
        ///  Fonction qui met à jour un client
        /// </summary>
		/// <param name="client">Id du client à modifier</param>
		
		[HttpPut]
		public async Task<ActionResult> Update(Client client)
		{
			Client clt = await _clientBusiness.Read(client.Id);

			if (clt != null)
			{
				clt.Name = client.Name;
				clt.Description = client.Description;
				if (await _clientBusiness.Update(clt))
				{

					return Ok(client);
				}
				else
				{
					return StatusCode(402, "impossible de mettre à jour");
				}
			}
			else
			{
				return StatusCode(402, "pas de client" + client.Id);
			}
			}
        /// <summary>
        ///  Fonction qui créer un Article
        /// </summary>
		/// <param name="contenu">contenu de l'article</param>
		/// <param name="id">Id du client</param>
        [HttpPost]
        public async Task<ActionResult> CreateArticle(string contenu, int id)
        {
            
			Article article = new Article() { Contenu = contenu, ClientId = id };

            Client clt = await _clientBusiness.Read(id);

			if (clt != null)
			{
				

			
				if (await _articleBusiness.Create(article))
				{

					return Ok(clt);
				}
				else
				{
					return StatusCode(402, "création impossible ");
				}
			}
                return StatusCode(402, "création impossible le client n'exsite pas");
            }
        /// <summary>
        ///  Fonction qui permet de supprimer un client
        /// </summary>
		/// <param name="id">Id du client</param>
        [HttpGet]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            if (await _articleBusiness.Delete(id))
            {
                return Ok("Article supprimé");
            }
            else
            {
                return StatusCode(402, "Article non supprimé");
            }
        }
        /// <summary>
        ///  Fonction qui permet de récuperer un article par son id
        /// </summary>
		/// <param name="id">id de l'article</param>
        [HttpGet]
        public async Task<ActionResult> GetByIdArticle(int id)
        {
            Article article = await _articleBusiness.Read(id);
            if (article != null)
            {
                return Ok(article);
            }
            else
            {
                return StatusCode(402, "l'article n'existe pas");
            }
        }
        /// <summary>
        ///  Fonction qui rapporte tous les articles
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> GetAllArticles()
        {
            List<Article> articles = await _articleBusiness.GetArticles();
            if (articles != null)
            {
                return Ok(articles);
            }
            else
            {
                return StatusCode(402, "pas d'articles");
            }
        }
        /// <summary>
        ///  Fonction qui recherche un article
        /// </summary>
		/// <param name="str">Recherche</param>
        [HttpGet]
        public async Task<ActionResult> SearchArticle(string str)
        {
            List<Article> articles = await _articleBusiness.Search(str);
            if (articles != null)
            {
                return Ok(articles);
            }
            else
            {
                return StatusCode(402, "pas de clients");
            }
        }
        /// <summary>
        ///  Fonction qui met à jour un article
        /// </summary>
		/// <param name="article">Id de l'arcticle</param>
        [HttpPut]
        public async Task<ActionResult> UpdateArticle(Article article)
        {
            Article art = await _articleBusiness.Read(article.Id);

            if (art != null)
            {
                art.Contenu = article.Contenu;
                art.ClientId = article.ClientId;
                if (await _articleBusiness.Update(art))
                {

                    return Ok(article);
                }
                else
                {
                    return StatusCode(402, "impossible de mettre à jour");
                }
            }
            else
            {
                return StatusCode(402, "pas d'article" + article.Id);
            }
        }
    }
	}
