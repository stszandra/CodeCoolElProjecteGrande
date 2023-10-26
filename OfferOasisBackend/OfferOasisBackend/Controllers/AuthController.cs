using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferOasisBackend.Contract;
using OfferOasisBackend.Service.Authentication;
using SolarWatch.Contracts;

namespace OfferOasisBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
    {
        Console.WriteLine(request);
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }
        
         var result = await _authService.RegisterAsync(request.Email, request.Username, request.Password);
        
        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }
        
        return CreatedAtAction(nameof(Register), new RegistrationResponse(result.Email, result.UserName));
        //   return Ok(request);
    }
    
    [HttpPost("Login")]
    public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _authService.LoginAsync(request.Email, request.Password);

        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }

        return Ok(new AuthResponse(result.Email, result.UserName, result.Token));
    }

    private void AddErrors(AuthResult result)
    {
        foreach (var error in result.ErrorMessages)
        {
            ModelState.AddModelError(error.Key, error.Value);
        }
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost("add-role")]
    public async Task<ActionResult<UserRoleModificationRequest>> AddRoleToUser([FromBody] UserRoleModificationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _authService.ManageUserRoleAsync(request.Email, request.RoleName, true);

        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("remove-role")]
    public async Task<ActionResult<UserRoleModificationRequest>> RemoveRoleFromUser([FromBody] UserRoleModificationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _authService.ManageUserRoleAsync(request.Email, request.RoleName, false);

        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }

        return Ok(result);
    }
}