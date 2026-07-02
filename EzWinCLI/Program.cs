using System.Diagnostics;
using System.Net;

namespace EzWinCLI
{
    internal class Program
    {
        static HttpListener listener = new HttpListener();
        static string pathc = "";
        static string cmnds = "";
        static void Main(string[] args)
        {
            bool hosting = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("======================================================\r\n___________        __      _______________________ \r\n\\_   _____/_______/  \\    /  \\_   _____/\\______   \\\r\n |    __)_\\___   /\\   \\/\\/   /|    __)_  |    |  _/\r\n |        \\/    /  \\        / |        \\ |    |   \\\r\n/_______  /_____ \\  \\__/\\  / /_______  / |______  /\r\n        \\/      \\/       \\/          \\/         \\/ \r\n======================================================");
            Console.WriteLine("Welcome to EzWeb! \nV1.1.0(CLI)");
            Console.WriteLine("======================================================\r\n\r\nEzWeb is a hosting tool, that allows developers to use\r\na shared layout in plain HTML websites.\r\n\r\n======================================================");
            Console.ResetColor();
            Console.WriteLine("Please input the desired PORT!");
            int port = int.Parse(Console.ReadLine());
            Console.WriteLine($"PORT set to {port}");
            Console.WriteLine("Please input the website path!");
            pathc = Console.ReadLine();
            Console.WriteLine($"Path set to {pathc}");
            Console.WriteLine($"Path: {pathc}, PORT: {port}");
            try
            {
                hosting = true;

                listener.Prefixes.Add($"http://*:{port}/");
                newLine($"Starting server on port {port}...");
                listener.Start();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = $"http://localhost:{port}/",
                    UseShellExecute = true
                };
                Process.Start(startInfo);
                newLine($"Listening for connections on http://+:{port}/");
                newLine($"Hosted on http://localhost:{port}/");
                hosting = true;


                while (hosting)
                {
                    Host();
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                newLine(ex.Message);
                Console.ResetColor();

            }
            Console.ReadKey();
            Console.WriteLine("Quitting program...");
            Console.ReadKey();

        }
        static async Task Host()
        {
            try
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                string path = request.Url.AbsolutePath;
                string rootFolder = pathc;
                string deniedPath = Path.Combine(rootFolder, "DeniedPaths.txt");
                string templatePath = Path.Combine(rootFolder, "layout.html");
                string notFoundPath = Path.Combine(rootFolder, "notFound.html");
                string accessDeniedPath = Path.Combine(rootFolder, "accessDenied.html");
                bool isConsole = false;
                List<string> deniedPaths = new List<string>();
                if (File.Exists(deniedPath))
                {

                    deniedPaths = File.ReadAllLines(deniedPath).ToList();
                }







                string targetFilePath;
                string targetedFilePath;
                if (!deniedPaths.Contains(path))
                {

                    if (path == "/")
                    {
                        targetFilePath = Path.Combine(rootFolder, "index.html");
                        targetedFilePath = targetFilePath;
                    }
                    else if (path == "/EZcnsl")
                    {
                        targetedFilePath = Path.Combine(rootFolder, "index.html");
                        isConsole = true;

                    }
                    else if (path == "/DeniedPaths.txt")
                    {
                        targetFilePath = accessDeniedPath;
                        targetedFilePath = targetFilePath;
                    }
                    else
                    {
                        targetFilePath = Path.Combine(rootFolder, path.TrimStart('/'));
                        targetedFilePath = targetFilePath;

                        if (!File.Exists(targetFilePath) && File.Exists(targetFilePath + ".html"))
                        {

                            targetFilePath += ".html";
                            targetedFilePath = targetFilePath;
                        }
                    }
                }
                else
                {
                    targetFilePath = accessDeniedPath;
                    targetedFilePath = targetFilePath;
                }

                string pageContent = "";
                string webContent = "";

                byte[] buffer = Array.Empty<byte>();
                if (!isConsole)
                {
                    string extension = Path.GetExtension(targetedFilePath).ToLower();

                    try
                    {


                        if (extension == ".html")
                        {

                            try
                            {
                                string layoutText = File.ReadAllText(templatePath);

                                if (targetedFilePath != templatePath)
                                {
                                    if (File.Exists(targetedFilePath))
                                    {
                                        pageContent = File.ReadAllText(targetedFilePath);

                                    }
                                    else if (File.Exists(notFoundPath))
                                    {
                                        pageContent = File.ReadAllText(notFoundPath);
                                        response.StatusCode = 404;
                                    }
                                    else
                                    {
                                        pageContent = "<h1>404 Not Found</h1>";
                                        response.StatusCode = 404;
                                    }
                                }
                                else
                                {
                                    pageContent = File.ReadAllText(notFoundPath);
                                }







                            }
                            catch (Exception ex)
                            {
                                webContent = $"<h1>Internal Server Error</h1><p>{ex.Message}</p>";
                                newLine($"Error reading files: {ex.Message}");
                            }
                            if (File.Exists(templatePath))
                            {
                                webContent = File.ReadAllText(templatePath).Replace("{WebContent}", pageContent);
                            }
                            else
                            {
                                webContent = pageContent;
                            }
                            buffer = System.Text.Encoding.UTF8.GetBytes(webContent);
                            response.ContentType = "text/html";
                        }
                        else
                        {


                            buffer = File.ReadAllBytes(targetedFilePath);
                        }

                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Could not find file"))
                        {
                            if (!File.Exists(targetedFilePath))
                            {
                                if (File.Exists(templatePath))
                                {


                                    if (File.Exists(notFoundPath))
                                    {
                                        pageContent = File.ReadAllText(notFoundPath);
                                        response.StatusCode = 404;

                                    }
                                    else
                                    {
                                        pageContent = "<h1>404 Not Found</h1>";
                                        response.StatusCode = 404;
                                    }
                                    webContent = File.ReadAllText(templatePath).Replace("{WebContent}", pageContent);
                                    buffer = System.Text.Encoding.UTF8.GetBytes(webContent);
                                    response.ContentType = "text/html";
                                }
                                else
                                {

                                    webContent = "<h1>404 Not Found</h1>";
                                    response.StatusCode = 404;
                                    buffer = System.Text.Encoding.UTF8.GetBytes(webContent);
                                    response.ContentType = "text/html";
                                }
                            }
                            else
                            {
                                webContent = $"<h1>Internal Server Error</h1><p>{ex.Message}</p>";
                                buffer = System.Text.Encoding.UTF8.GetBytes(webContent);
                                response.ContentType = "text/html";
                            }
                        }
                        else
                        {
                            webContent = $"<h1>Internal Server Error</h1><p>{ex.Message}</p>";
                            buffer = System.Text.Encoding.UTF8.GetBytes(webContent);
                            response.ContentType = "text/html";
                            newLine($"Error: {ex.Message}");
                        }



                    }

                }
                else
                {
                    webContent = cmnds.Replace("\n", "<br>");
                    buffer = System.Text.Encoding.UTF8.GetBytes(webContent);
                    response.ContentType = "text/html";
                }



                //string currentPath = Path.Combine(folderBrowserDialog1.SelectedPath, "/" + path.TrimStart('/'));
                //newLine(currentPath);
                //string webContent = "";

                //    string a = File.ReadAllText(templatePath);
                //    string b = File.ReadAllText(folderBrowserDialog1.SelectedPath + path.TrimStart('/'));
                //    string extension = Path.GetExtension(currentPath).ToLower();
                //    if (extension == ".html")
                //    {
                //        b = File.ReadAllText(folderBrowserDialog1.SelectedPath + '/' + path.TrimStart('/') + ".html");
                //    }
                //    if (path == "/")
                //    {
                //        b = File.ReadAllText(folderBrowserDialog1.SelectedPath + "/index.html");
                //    }
                //    if (!File.Exists(currentPath))
                //   {
                //    b = File.ReadAllText(folderBrowserDialog1.SelectedPath + "/notFound.html");
                //}
                //    webContent = a.Replace("{WebContent}", b);
                //    newLine(webContent);





                try
                {
                    response.ContentLength64 = buffer.Length;

                    System.IO.Stream output = response.OutputStream;
                    await output.WriteAsync(buffer, 0, buffer.Length);
                    output.Close();
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
             
            }
        }

        static void newLine(string a)
        {
            Console.WriteLine( $"{DateTime.Now}: {a}");
            cmnds += (Environment.NewLine + $"{DateTime.Now}: {a}");
        }

    }

}

