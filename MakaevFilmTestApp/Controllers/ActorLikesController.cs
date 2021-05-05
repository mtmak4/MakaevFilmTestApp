using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakaevFilmTestApp.Data;
using MakaevFilmTestApp.ViewModels;
using Microsoft.AspNet.Identity;

using System.Security.Claims;
using MakaevFilmTestApp.Models;

namespace MakaevFilmTestApp.Controllers
{
    public class ActorLikesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string userId;
        private List<ActorLike> actorLikes = new List<ActorLike>();
        public ActorLikesController(ApplicationDbContext context)
        {
            _context = context;

        }


        public bool checkOnLike(string userId, int actorId)
        {
            var likeOnActor = (_context.ActorLike.FirstOrDefault(x => x.ActorId == actorId && x.UserId == userId));
            if (likeOnActor == null)
            {
                return false;
            }
            else
            {
               
                return likeOnActor.Like;
            }
        }
        // GET: ActorLikes

        public async Task<IActionResult> Index()
        {
            try
            {
                userId = (User.Identity.GetUserId());

            }
            catch
            {
                userId = null;
            }
            ViewData["userId"] = userId;
            var actors = _context.Actors;
            foreach (var item in actors)
            {
                //like - value like it on actor or not
                bool like = checkOnLike(userId, item.Id);
                int rate = _context.ActorLike.Where(x => x.ActorId == item.Id && x.Like == true).Count();
                item.Rate = rate;
                actorLikes.Add(new ActorLike { ActorId = item.Id, Actor = item, Like = like });
            }
            return View("Index",actorLikes.OrderBy(x => x.Actor.Lastname));
        }

   
        public async Task<IActionResult> ViewByPopular()
        {
            try
            {
                userId = (User.Identity.GetUserId());

            }
            catch
            {
                userId = null;
            }
            ViewData["userId"] = userId;
            var actors = _context.Actors;
            foreach (var item in actors)
            {
                //like - value like it on actor or not
                bool like = checkOnLike(userId, item.Id);
                int rate = _context.ActorLike.Where(x => x.ActorId == item.Id).Count();
                item.Rate = rate;
                actorLikes.Add(new ActorLike { ActorId = item.Id, Actor = item, Like = like });
            }
            return View("Index",actorLikes.OrderByDescending(x => x.Actor.Rate));
        }
        // GET: ActorLikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorLike = await _context.Actors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorLike == null)
            {
                return NotFound();
            }

            return View("~/Views/Actors/Details.cshtml",actorLike);
        }

        // GET: ActorLikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActorLikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActorId,UserId,Like")] ActorLike actorLike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actorLike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actorLike);
        }

        // GET: ActorLikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorLike = await _context.ActorLike.FindAsync(id);
            if (actorLike == null)
            {
                return NotFound();
            }
            return View(actorLike);
        }

        // POST: ActorLikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActorId,UserId,Like")] ActorLike actorLike)
        {
            if (id != actorLike.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actorLike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorLikeExists(actorLike.Id))
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
            return View(actorLike);
        }

        // GET: ActorLikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actorLike = await _context.ActorLike
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorLike == null)
            {
                return NotFound();
            }

            return View(actorLike);
        }

        // POST: ActorLikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorLike = await _context.ActorLike.FindAsync(id);
            _context.ActorLike.Remove(actorLike);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public ActionResult LikeSet(int actorId)
        {
            userId = (User.Identity.GetUserId());
            var actor = _context.Actors.FirstOrDefault(x => x.Id == actorId);
            var searchingRecord = _context.ActorLike.FirstOrDefault(x => x.ActorId == actorId && x.UserId == userId);
            if (searchingRecord == null)
            {
                ActorLike actorLike = new ActorLike { ActorId = actorId,Actor=actor, UserId = userId, Like = true };
                _context.ActorLike.Add(actorLike);
                int iii = actorLike.Id;
                _context.SaveChanges();
            }
            else
            {
                searchingRecord.Like = !searchingRecord.Like;
            }
            _context.SaveChangesAsync();

            return View("Index");
        }
        [HttpPost]
        public string AjaxTest(ActorLike obj)
        {

            int actorId = obj.ActorId;
            LikeSet(actorId);
            return "Test";
        }
        private bool ActorLikeExists(int id)
        {
            return _context.ActorLike.Any(e => e.Id == id);
        }
    }
    public class LogOnModel
    {
        public string Mobile { get; set; }
        public string EmailID { get; set; }
    }

}
