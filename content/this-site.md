---
title: Why & How This Website Exists
---

### Why?

Why create a personal website? What's the benefit in writing to the internet
void? Why not have a clean professional website which only lists my projects and
work experience like many other software developers have?

The main answer I give is that this is what interests me.

### How?

The technical aspect of this website is intentionally simple.

The bulk of the website is Markdown-formatted writing. Pandoc is used to convert
and then inject the Markdown into a small HTML template file for a consistent
look across pages. A small shell script is used to automate this process for all
the markdown files. This script also passes variables into Pandoc such as the
Markdown file's last modified date to be displayed on the page. The script then
copies all needed assets such as fonts and stylesheets into a common folder
along with the Markdown-derived HTML.

Another script is used which integrates Rclone to copy the generated website to
Cloudflare R2. Cloudflare CDN fronts the website, so the script clears the CDN's
cache to prevent stale content from being served. GitHub Actions uses this
script to upload the website when it receives a commit, ensuring the website is
kept up to date.
