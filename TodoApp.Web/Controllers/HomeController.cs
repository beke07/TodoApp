using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoApp.Bll.Commands;
using TodoApp.Bll.ViewModels;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(FilterDto filter)
        {
            var list = await mediator.Send(new GetTodoListCommand(filter));

            return View(list);
        }

        [HttpGet]
        public IActionResult PageDown(FilterDto filter)
        {
            filter.PageDown();

            return RedirectToAction(nameof(Index), filter);
        }

        [HttpGet]
        public IActionResult PageUp(FilterDto filter)
        {
            filter.PageUp();

            return RedirectToAction(nameof(Index), filter);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var todo = await mediator.Send(new GetTodoCommand(id));

            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateTodoCommand update)
        {
            await mediator.Send(update);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoCommand todo)
        {
            await mediator.Send(todo);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await mediator.Send(new DeleteTodoCommand(id));

            return RedirectToAction(nameof(Index));
        }
    }
}
