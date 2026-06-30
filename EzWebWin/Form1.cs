using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace EzWebWin
{
    public partial class Form1 : Form
    {

        int port;
        bool hosting = false;
        HttpListener listener = new HttpListener();
        public Form1()
        {
            InitializeComponent();
        }

        void newLine(string a)
        {
            textBox1.AppendText(Environment.NewLine + a);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            try
            {
                port = (int)numericUpDown2.Value;


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
                numericUpDown2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = true;


                while (hosting)
                {

                    HttpListenerContext context = await listener.GetContextAsync();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;
                    string path = request.Url.AbsolutePath;
                    string rootFolder = folderBrowserDialog1.SelectedPath;
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
                            targetFilePath = Path.Combine(rootFolder, "index.html");
                            targetedFilePath = targetFilePath;
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
                    string extension = Path.GetExtension(targetedFilePath).ToLower();
                    byte[] buffer;
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
                            if (!File.Exists(targetedFilePath) )
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

                    if (isConsole)
                    {
                        webContent = textBox1.Text.Replace("\n", "<br>");
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






                    response.ContentLength64 = buffer.Length;

                    System.IO.Stream output = response.OutputStream;
                    await output.WriteAsync(buffer, 0, buffer.Length);
                    output.Close();

                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                if (hosting)
                {
                    newLine($"Error: {ex.Message}");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown2.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            hosting = false;
            listener.Stop();
            newLine($"Server stopped.");

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        private void basicTutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

