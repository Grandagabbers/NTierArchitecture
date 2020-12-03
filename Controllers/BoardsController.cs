using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using RetroTool.Models;

namespace RetroTool.Controllers
{

    //Use autorize to check if the user is logged in
    [Authorize]
    public class BoardsController : Controller
    {
        //The url to communicate with
        private string BaseAddress = "https://retrobusiness.azurewebsites.net/";

        // GET: Boards
        public async Task<IActionResult> Index()
        {
            //Make a new httpclient
            var client = new HttpClient();
            //set the baseadress of the client
            client.BaseAddress = new Uri(BaseAddress + "api/Board");
            //use this line of code to add authorisation by using oath. Send the accesstoken given from the log in to authenticate the user
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            try
            {
                //send the request and put the result in a variable (res)
                var response = await client.GetAsync(client.BaseAddress);
                var res = response.Content.ReadAsStringAsync().Result;
                //deserialiaze the res in a list of board and return this as a view
                List<Board> board = JsonConvert.DeserializeObject<List<Board>>(res);
                //put response in model
                return View(board);
            }
            catch
            {
                return null;
            }
            
        }

        // POST: Boards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Board board)
        {
            //serialize the board the user has send
            var json = JsonConvert.SerializeObject(board);
            //make a new httpclient
            var client = new HttpClient();
            //the baseadress of the client
            client.BaseAddress = new Uri(BaseAddress + "api/Board");
            //use this line of code to add authorisation by using oath. Send the accesstoken given from the log in to authenticate the user
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //make the stringcontent and make the mediatypeheader json, because we use this and send this
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                //make the postcall
                var response = await client.PostAsync(client.BaseAddress, content);
                return View();
            }
            catch
            {
                return null;
            }
        }

        //For further development basic api calls

        // GET: Boards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View();
        }

        // GET: Boards/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // GET: Boards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: Boards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,B_Name")] Board board)
        {
            if (id != board.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardExists(board.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(board);
        }

        // GET: Boards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        private bool BoardExists(int id)
        {
            return false;
        }
    }
}
