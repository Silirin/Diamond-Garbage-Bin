﻿using GameStore.Models;
using GameStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        private Repository repository = new Repository();
        private int pageSize = 4;

        protected int CurrentPage
        {
            get
            {
                int page;
                page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((decimal)repository.Games.Count() / pageSize);
            }
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ?? Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

        protected IEnumerable<Game> GetGames()
        {
            return repository.Games.OrderBy(g => g.GameId).Skip((CurrentPage - 1) * pageSize).Take(pageSize);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}