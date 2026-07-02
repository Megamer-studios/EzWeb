<div align="center">

<img src="/EzWebBanner.png" />

**Web hosting done simple.**

*A lightweight Windows hosting tool that lets developers share a single layout across plain HTML websites.*

[![License](https://img.shields.io/badge/license-Open%20Source-brightgreen)](https://ezweb.aquaweb.cc/source)
[![Version](https://img.shields.io/badge/version-1.1.0-blue)](https://ezweb.aquaweb.cc/Compiles/EzWeb-V1.1.0.zip)
[![Contributions](https://img.shields.io/badge/contributions-open-orange)](https://ezweb.aquaweb.cc/source)
[![Platform](https://img.shields.io/badge/platform-Windows-lightgrey)](https://ezweb.aquaweb.cc/downloads)

</div>

---

## What is EzWeb?

EzWeb is a Windows desktop tool that runs a local HTTP server, automatically injecting a shared `layout.html` into every page of your static website. Write your content in plain HTML files — EzWeb handles the wrapper so you never repeat your navigation, header, or footer again.

---

## ⚠️ Requirements

> **EzWeb must be run in Administrator mode.**
> The HTTP listener requires elevated privileges to bind to a port. Right-click the executable and choose *Run as administrator*.

---

## Download

### GUI (Win)
| Version | Link |
|---------|------|
| **V1.1.0** *(Latest)* | [Download](https://ezweb.aquaweb.cc/Compiles/EzWeb-V1.1.0.zip) |
| V1.0.3 | [Download](https://ezweb.aquaweb.cc/Compiles/EzWeb-V1.0.3.zip) |
| V1.0.2| [Download](https://ezweb.aquaweb.cc/Compiles/EzWeb-V1.0.2.zip) |
| V1.0.1| [Download](https://ezweb.aquaweb.cc/Compiles/EzWeb-V1.0.1.zip) |
| V1.0.0 | [Download](https://ezweb.aquaweb.cc/Compiles/EzWeb-V1.0.0.zip) |

### CLI (Win)
| Version | Link |
|---------|------|
| **V1.1.0** *(Latest)* | [Download](https://ezweb.aquaweb.cc/Compiles/CLI/EzWebCLI-Win-V1.1.0.zip) |
| V1.0.1| [Download](https://ezweb.aquaweb.cc/Compiles/CLI/EzWebCLI-Win-V1.0.1.zip) |

### CLI (Linux)
| Version | Link |
|---------|------|
| **V1.1.0** *(Latest)* | [Download](https://ezweb.aquaweb.cc/Compiles/CLI/EzWebCLI-Lin-V1.1.0.zip) |
| V1.0.1| [Download](https://ezweb.aquaweb.cc/Compiles/CLI/EzWebCLI-Lin-V1.0.1.zip) |

---

## Getting Started

### 1 — Required file structure

Your website folder must contain these five files:

```
my-site/
├── index.html          ← Homepage content
├── layout.html         ← Shared layout/template
├── notFound.html       ← Custom 404 page
├── accessDenied.html   ← Custom 403 page
└── DeniedPaths.txt     ← Paths to block from public access
```

### 2 — Set up your layout

`layout.html` holds everything that wraps every page: your `<head>` metadata (except `<title>`), navigation, footer, etc. Place the placeholder `{WebContent}` wherever your per-page content should be injected:

```html
<!DOCTYPE html>
<html>
<head>
  <meta charset="UTF-8">
  <!-- shared styles, scripts, meta tags here -->
</head>
<body>
  <nav><!-- your shared nav --></nav>

  {WebContent}   <!-- page content is injected here -->

  <footer><!-- your shared footer --></footer>
</body>
</html>
```

### 3 — Write your pages

Each page file only needs a `<head>` tag (for its own `<title>`) and its body content — no `<html>` or `<body>` wrappers needed:

```html
<head>
  <title>About - My Site</title>
</head>

<h1>About Us</h1>
<p>Welcome to my site!</p>
```

### 4 — Override the layout (optional)

To serve a file **without** wrapping it in `layout.html`, simply omit the `.html` extension from the filename. EzWeb will serve it as-is.

### 5 — Restrict access

Add file paths (one per line) to `DeniedPaths.txt` to block those paths from being served to visitors:

```
/DeniedPaths.txt
/admin/secret.html
/internal/config
```

Requests to a denied path are redirected to `accessDenied.html`.

---

## Running the Server

1. Launch **EzWeb** as Administrator.
2. Select your website folder using the folder browser.
3. Set your desired port number.
4. Click **Start** — EzWeb will open your site in the browser automatically.
5. Click **Stop** when done.

---

## How It Works

EzWeb uses `System.Net.HttpListener` to handle incoming requests. For each `.html` request it:

1. Reads `layout.html`
2. Reads the target page file
3. Replaces `{WebContent}` in the layout with the page content
4. Serves the combined result

Non-HTML files (images, CSS, JS, etc.) are served as raw bytes. Missing pages fall back to `notFound.html` with a `404` status code.

---

## Source Code

The full C# source is available on the [EzWeb website](https://ezweb.aquaweb.cc/source). Contributions are open.

---

## Credits

| Role | Credit |
|------|--------|
| Code & Art/Media | [Akumarin Kukino](https://akumarin.neocities.org/) |
| Publisher | Megamer Studios |

---

<div align="center">

© 2026 Megamer Studios — EzWeb · All code and art/media by Akumarin Kukino

*[Just use HTML.](https://justfuckingusehtml.com/)*

</div>
