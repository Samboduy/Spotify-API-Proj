using Microsoft.AspNetCore.Mvc;
using Final_Test.Helper.StringExtension;
using Final_Test.Services;

namespace Final_Test.Controllers;

[ApiController]
[Route("spotify/api")]
public class SpotifyController : Controller
{
     private IConfiguration _config;
    private IHttpClientFactory _clientFactory;
    private string _state;
    private SpotifyService _spotifyService;
    private string _clientId;
    private string _redirectUri;

    

    public SpotifyController( IConfiguration config, IHttpClientFactory httpClientFactory)
    {
        _config = config;
        _clientFactory = httpClientFactory;
        _spotifyService = new SpotifyService();
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        var redirectUri = _redirectUri;
        string state = StringExtension.RandomString(16);
        _state = state;
        var scopes = "user-read-private user-read-email";

        var url = $"https://accounts.spotify.com/authorize?client_id={_clientId}" +
                  $"&response_type=code&redirect_uri={Uri.EscapeDataString(redirectUri)}" +
                  $"&scope={Uri.EscapeDataString(scopes)}"
                  + $"&state={Uri.EscapeDataString(state)}";
        return Redirect(url);
    }
    
    [HttpGet("/spotify")]
    public Task<IActionResult> Callback([FromQuery] string code,[FromQuery] string state)
    {
        _spotifyService.Callback(code,state);
        return Task.FromResult<IActionResult>(Ok());
    }
    
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("Spotify backend is alive!");
    }
}