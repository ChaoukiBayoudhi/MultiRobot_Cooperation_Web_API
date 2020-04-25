using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiRobot_Cooperation_API.Models;
using static System.Net.Mime.MediaTypeNames;

namespace MultiRobot_Cooperation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //This attribute indicates that the controller responds to web API requests
    public class RobotsController : ControllerBase
    {
        private readonly RobotContext _context;

        public RobotsController(RobotContext context)
        {
            _context = context;
        }

        // GET: api/Robots
        [HttpGet]
        /*
         *The [HttpGet] attribute denotes a method that responds to an HTTP GET request. The URL path for each method is constructed as follows:
            Start with the template string in the controller's Route attribute:
            Replace [controller] with the name of the controller, which by convention is the controller class name minus the "Controller" suffix.
            If the [HttpGet] attribute has a route template (for example, [HttpGet("products")]), append that to the path. This sample doesn't use a template.
         * */
        public async Task<ActionResult<IEnumerable<Robot>>> GetRobotSet()
        {
            return await _context.RobotSet.ToListAsync();
        }

        // GET: api/Robots/5
        [HttpGet("{id}")]
        // ActionResult return types can represent a wide range of HTTP status codes.
        // If no item matches the requested ID, the method returns a 404 NotFound error code.
        // Otherwise, the method returns 200 with a JSON response body. Returning item results in an HTTP 200 response.
        public async Task<ActionResult<Robot>> GetRobot(int id)
        {
            var robot = await _context.RobotSet.FindAsync(id);

            if (robot == null)
            {
                return NotFound();
            }

            return robot;
        }

        // PUT: api/Robots/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        /*
         *The response is 204 (No Content). According to the HTTP specification, 
         * a PUT request requires the client to send the entire updated entity, not just the changes. 
         */
        public async Task<IActionResult> PutRobot(int id, Robot robot)
        {
            if (id != robot.IdRobot)
            {
                return BadRequest();
            }

            _context.Entry(robot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RobotExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Robots
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
       /*
        * The CreatedAtAction method:

        Returns an HTTP 201 status code if successful. 
        HTTP 201 is the standard response for an HTTP POST method that creates a new resource on the server.
        Adds a Location header to the response. 
        The Location header specifies the URI of the newly created to-do item. 
        For more information, see 10.2.2 201 Created.
        References the GetTodoItem action to create the Location header's URI. 
        The C# nameof keyword is used to avoid hard-coding the action name in the CreatedAtAction call.
        */
        public async Task<ActionResult<Robot>> PostRobot(Robot robot)
        {
            _context.RobotSet.Add(robot);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRobot), new { id = robot.IdRobot }, robot);
        }


        // DELETE: api/Robots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Robot>> DeleteRobot(int id)
        {
            var robot = await _context.RobotSet.FindAsync(id);
            if (robot == null)
            {
                return NotFound();
            }

            _context.RobotSet.Remove(robot);
            await _context.SaveChangesAsync();

            return robot;
        }

        private bool RobotExists(int id)
        {
            return _context.RobotSet.Any(e => e.IdRobot == id);
        }
    }
}
