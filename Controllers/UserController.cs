using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http.HttpResults;
namespace RestSample.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    private readonly IDocumentCollection<Users> _users;

    /* UpdateUsers *//* 
    public async Task<Users?>  UpdateUserAsync (int id, Users users)
    {
        var user = _users.AsQueryable().FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return null;
        }

        users.Name = user.Name;
        users.Id = user.Id;

        await _users.ReplaceOneAsync(u => u.Id == id, user);

        return user;


    } 
    /* Controller */
    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;

        var store = new DataStore("db.json");
        _users = store.GetCollection<Users>();
    }

    [HttpPut]

    public async Task<IActionResult> UpdateUser(int id, [FromBody] Users users)
    {
        var user = _users.AsQueryable().FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound($"ไม่พบผู้ใช้ที่มี ID: {id}");
        }

        user.Name = users.Name;

        await _users.UpdateOneAsync(u => u.Id == id, user);

        return Ok(user);
    }

    [HttpPost]
    public void Post([FromBody] Users users)
    {
        _users.InsertOne(users);
    }

    [HttpGet]
    public IEnumerable<Users> Get()
    {
        return _users.AsQueryable().ToList();
    }

    [HttpGet("{id:int}")]

    public async Task<Users?> UpdateUserAsync(int id, Users users)
    {
        var user = _users.AsQueryable().FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return null;
        }

        users.Name = user.Name;
        users.Id = user.Id;

        await _users.ReplaceOneAsync(u => u.Id == id, user);

        return user;
    }

    [HttpDelete("{id}")]
   
    public async Task<IActionResult>DeleteUser(int id)
    {
        var user = _users.AsQueryable().FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound($"ไม่พบผู้ใช้ที่มี ID: {id}");
        }

        var isDeleted = await _users.DeleteOneAsync(u => u.Id == id);
        if (isDeleted)
        {
            return Ok($"ผู้ใช้ที่มี ID: {id} ถูกลบเรียบร้อยแล้ว");
        }

        else
        {
            return StatusCode(500, "เกิดข้อผิดพลาดในการลบผู้ใช้");
        }
    }
}

/* Model */
public class Users
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}

