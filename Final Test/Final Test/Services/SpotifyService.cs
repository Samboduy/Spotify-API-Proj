using System.Net;
using Final_Test.Helper.StringExtension;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Final_Test.Services;

public class SpotifyService
{
    
    public void Callback( string code,string state)
    {
        Console.WriteLine(code + " state:" + state);
    }
}