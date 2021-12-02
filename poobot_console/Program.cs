using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
public class Program{
    public static void Main(){
        new Program().MainAsync().GetAwaiter().GetResult();
    }

    private DiscordSocketClient _client;
    private CommandHandler _commhandler;

    public async Task MainAsync(){
        this._client = new DiscordSocketClient();

        this._commhandler = new CommandHandler(this._client, new CommandService());
        await this._commhandler.InstallCommandsAsync();

        this._client.Log += Log;

        //  You can assign your bot token to a string, and pass that in to connect.
        //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
        string token = "OTE1Njc5MTYzODUwMDUxNjA1.YafGrQ.nsh3zs-1RiqsMiCvNdOyCIbeJMo";

        // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
        // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
        // var token = File.ReadAllText("token.txt");
        // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        // Block this task until the program is closed.
        await Task.Delay(-1);

    }

    private Task Log(LogMessage msg)
    {
	    Console.WriteLine(msg.ToString());
	    return Task.CompletedTask;
    }
}

