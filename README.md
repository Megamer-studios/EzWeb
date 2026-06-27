
# EzWeb


## !DISCLAIMER!

THE SOFTWARE WILL ONLY WORK IN ADMINISTRATOR MODE!
---

EzWeb is a hosting tool, that allows developers to use
a shared layout in plain HTML websites.

---

You need 5 main files.

-index.html
-layout.html
-notFound.html
-DeniedPaths.txt
-accessDenied.html

All the layout and the <head> information
(except for title) should be in layout.html.
Inside the <body> of layout.html insert "{WebContent}"
to declare where the page content goes.
Inside page files (including not Found.html) start off
by opening a <head> tag and declaring the <title>.
Outside of the head tag you can add, what you would
normally add inside the <body> of that page.
To override the layout, you can simply remove the
"html" file extension from a page.
To restrict users from accessing a file, you can add
the path to a new line in "DeniedPaths.txt".
In the "accessDenied.html" and "notFound.html" files you
can define your own "page not found" and
"access denied" pages.

---
